using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Configuration;
using System.Web;

namespace Redson_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FilesController : GenericC
    {
        public FilesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "File";
        }

        [HttpGet]
        public IEnumerable<Redson_backend.Models.File> Get()
        {
            return (List<Redson_backend.Models.File>)GetAllEntities();
        }

        protected override Object afterGetAll(Object entityList)
        {

            var fileList = (IEnumerable<Redson_backend.Models.File>)entityList;

            var s3Manager = new RedsonS3Manager();

            foreach (var file in fileList)
            {
                file.ContentUrl = s3Manager.GetURL(file.As3Key);
            }

            return fileList;
        }

        [HttpGet("{id}")]
        public Redson_backend.Models.File Details(int id)
        {
            return (Redson_backend.Models.File)GetEntity(id);
        }

        protected override EntityBaseNoId afterGet(EntityBaseNoId entity)
        {
            var file = (Redson_backend.Models.File)entity;
            var s3Manager = new RedsonS3Manager();
            file.ContentUrl = s3Manager.GetURL(file.As3Key);

            return file;
        }

        /*[HttpPost]
        public IActionResult Create([FromBody] File entity)
        {
            return CreateEntity(entity);
        }*/

        [HttpPost]
        public IActionResult PostFile()
        {
            //var filePath = Path.GetTempFileName();
            var filePath = Path.GetFullPath("Files");
            
            var redsonFile = new Redson_backend.Models.File();

            foreach (var formFile in Request.Form.Files)
            {
                if (formFile.Length > 0)
                {
                    var s3Manager = new RedsonS3Manager();
                    var key = s3Manager.Transfer(formFile);

                    redsonFile.Filename = formFile.FileName;
                    redsonFile.Size = (short)(formFile.Length / 1024);
                    redsonFile.MimeType = MimeTypes.GetMimeType(formFile.FileName);
                    redsonFile.As3Key = key;

                    redsonFile.ContentUrl = s3Manager.GetURL(key);
                }
            }


            return CreateEntity(redsonFile);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Redson_backend.Models.File entity)
        {
            return UpdateEntity(entity);
        }

    }
}
