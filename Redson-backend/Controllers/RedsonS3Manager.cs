using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;
using Amazon.S3.Model;
using System.IO;
using Amazon.Runtime;
using System.Security.Cryptography;
using System.Text;

namespace Redson_backend.Controllers
{

    /*
     * Usuario *
    Usuario: s3redson
    ID de clave de acceso: AKIA5K2ASHWOT2VPC2UE
    Clave de acceso secreta: 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
    Region:Ohio

    *** Buckets**
    Nombre: bktrensons3
     */
    public class RedsonS3Manager
    {
        string AwsAccessKey = "AKIA5K2ASHWOT2VPC2UE";
        string AwsSecretKey = "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";

        string bucketName = "bktrensons3";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;

        string lastUrl = "";

        private Dictionary<string, string> keyMD5Sums;

        AmazonS3Client s3Client;

        public RedsonS3Manager()
        {
            var amazonS3Config = new AmazonS3Config
            {
                ServiceURL = bucketName,
                RegionEndpoint = bucketRegion,
                SignatureMethod = SigningAlgorithm.HmacSHA256
            };

            AWSConfigsS3.UseSignatureVersion4 = true;

            s3Client = new AmazonS3Client(AwsAccessKey, AwsSecretKey, amazonS3Config );
            this.keyMD5Sums = new Dictionary<string, string>();
        }
    
        public string Transfer(Microsoft.AspNetCore.Http.IFormFile formFile)
        {
            try
            {
                // Creating filestream
                var filePath = Path.GetFullPath("Files");
                var fileName = DateTime.Now.ToString("yyyyMMddhmmss-") + formFile.FileName;
                //var filePath = Directory.GetCurrentDirectory();
                var fileNamePath = Path.Combine(filePath, fileName);
                var inputStream = new FileStream(fileNamePath, FileMode.Create);

                formFile.CopyTo(inputStream);
                byte[] array = new byte[inputStream.Length];
                inputStream.Seek(0, SeekOrigin.Begin);
                inputStream.Read(array, 0, array.Length);
                var mimeMapping = MimeTypes.GetMimeType(formFile.FileName);

                // Send file
                var fileTransferUtility = new TransferUtility(s3Client);

                var uploadReq = new TransferUtilityUploadRequest();
                uploadReq.BucketName = this.bucketName;
                uploadReq.InputStream = inputStream;
                uploadReq.Key = fileName;
                uploadReq.Headers.ContentType = mimeMapping;

                fileTransferUtility.Upload(uploadReq);

                // Delete File
                if (File.Exists(@fileNamePath))
                {
                    File.Delete(@fileNamePath);
                }

                return uploadReq.Key;
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }

        public string GetURL( string key )
        {
            // Getting URL
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Verb = HttpVerb.GET,
                Protocol = Protocol.HTTPS,
                Key = key,
                Expires = DateTime.Now.AddDays(1)
            };
            var url = s3Client.GetPreSignedURL(request);
            var uri = new Uri(url);

            return uri.ToString();
        }

        private string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            return result.ToString();
        }
    }
}
