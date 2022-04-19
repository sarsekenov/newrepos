using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    //[Route("/api/")]
    //[Authorize(Roles = "admin")]
    public class FilesController : ApiController
    {
        [Route("GetFiles")]
        [HttpGet]
        public IQueryable<Models.Folder> get_Dirs() 
        {
            
            //if(User.IsInRole("admin")) { 
            return FoldersController.db.Folders;
        }
            //return null;
        }
        [Route("SendFiles")]
        [HttpPost]
        public IHttpActionResult SendFolder(Models.Folder folder) 
        {
        
        
        }
 }

