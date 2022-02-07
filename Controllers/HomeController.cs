using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftXpansion.Interfaces;
using SoftXpansion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SoftXpansion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUnitsLoaderService unitsLoaderService;
        public IWebHostEnvironment appEnvironment;


        public HomeController(IUnitsLoaderService unitsLoaderService, IWebHostEnvironment environment)
        {
            this.unitsLoaderService = unitsLoaderService;
            appEnvironment = environment;
        }


        [HttpPost]
        public IActionResult LoadXml(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string path = "/XmlFiles/" + file.FileName;

                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                         file.CopyTo(fileStream);
                    }

                    return Ok(unitsLoaderService.LoadUnits(appEnvironment.WebRootPath + path));
                }
                else {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Please, choose XML file");
            }
        }
    }
}
