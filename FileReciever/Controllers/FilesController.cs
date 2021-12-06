using FileReciever.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileReciever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // POST api/<FileController>
        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public void Post([FromBody] TransferClass value)
        {
            //File.WriteAllBytes(string path, byte[] bytes)
            System.IO.File.WriteAllBytes("c:/temp/1Git-2.34.1-64-bit.exe", value.Data);
        }
    }
}
