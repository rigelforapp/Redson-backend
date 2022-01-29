using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using Microsoft.AspNetCore.Authorization;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp;

namespace Redson_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PDFOrdersController : GenericC
    {

        public PDFOrdersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Order";
        }
        
        [HttpGet("{OrderId}")]
        public IActionResult GetPDF(int OrderId)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PageSize.A4);
            pdf.Save("document.pdf");
            return Ok();
        }
    }
}
