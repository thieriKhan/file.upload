
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using file.upload.Data_context;
using file.upload.Model;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using Utilities;
using Utilities.Network;
using FluentFTP;
using System.Net;

namespace file.upload.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MyFilesController : ControllerBase
    {
        private readonly DataContext _context;
      private readonly IWebHostEnvironment _webHostEnvironment; 
        public MyFilesController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
      _webHostEnvironment = webHostEnvironment; 
        }

        // GET: MyFiles
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.myFile.ToListAsync());
        }

        // GET: MyFiles/Details/5
        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFile = await _context.myFile
                .FirstOrDefaultAsync(m => m.MyFileId == id);
            if (myFile == null)
            {
                return NotFound();
            }

            return Ok(myFile);
        }


        [HttpPost]
        [Route("postformfile")]
       
        public async Task<IActionResult> Create( MyFile myFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(myFile);
        }

    [HttpPost]
    [Route("uploadFile")]

    public async Task<IActionResult> Upload(  IFormFile myfile, string id)
    {


      var path = Path.Combine(@"Users","Resources", "Images");
      NetworkDrive nd = new NetworkDrive();
      nd.MapNetworkDrive(@"\\THIERI", "c:\\", "admin", "pass");

      var dirPath = Path.Combine(@"\\THIERI", path);

      var filename = ContentDispositionHeaderValue.Parse(myfile.ContentDisposition).FileName.Trim('"');
      var fullpath = Path.Combine(dirPath, filename);
      
      var dbPath = Path.Combine(path, filename);


      using (FtpClient ftp = new FtpClient("192.168.50.102", "admin", "pass" ))
      {
        if (ftp.IsConnected)
        {

          using (var stream = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
          {
            await ftp.UploadAsync(stream, fullpath);



          }
        } else
        {
          return BadRequest("failed to connect to the ftp server");
        }
       

      }

    

      

  
      


      return Ok("success");
    }








    private bool MyFileExists(int id)
        {
            return _context.myFile.Any(e => e.MyFileId == id);
        }
    }
}
