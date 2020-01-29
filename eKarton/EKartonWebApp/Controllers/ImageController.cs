using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EKartonWebApp.Config;
using EKartonWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EKartonWebApp.Controllers
{
    public class ImageController : Controller
    {
        private IWebHostEnvironment _environment;
        eKartonAPI _api = eKartonAPI.GetInstance();

        public ImageController(IWebHostEnvironment host)
        {
            _environment = host;
        }

        public IActionResult Image()
        {
            return View();
        }

       [HttpGet]
       public IActionResult Create()
       {
          return View(new CreatePost());
       }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePost model)
        {
            var img = model.MyImage;
            var ss = model.MyImage.FileName;
            
            var imgCaption = model.ImageCaption;
            var st = model.MyImage.OpenReadStream();
            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    using (var streamContent = new StreamContent(st))
                    {
                        using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                        {
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                            // "file" parameter name should be the same as the server side input parameter name
                            form.Add(fileContent, "file", ss);
                            HttpResponseMessage response = await httpClient.PostAsync(Routes.APIBaseURI + "Image/UploadFile", form);
                            var k = response.ReasonPhrase;

                        }
                    }
                }
            }
            return View();
        }
    }
    public class CreatePost
    {
        public string ImageCaption { set; get; }
        public string ImageDescription { set; get; }
        public IFormFile MyImage { set; get; }
        public byte[] Bytes { get; set; }
    }
}