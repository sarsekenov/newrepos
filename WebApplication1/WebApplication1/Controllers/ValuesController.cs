using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /*
        public static Content content;
        [Route("SendFiles")]
        [HttpPost]
        public async Task<IHttpActionResult> SendFiles()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            if (provider.Contents != null && provider.Contents.Count > 0)
            {
                foreach (var cont in provider.Contents)
                {
                    if (!string.IsNullOrEmpty(cont.Headers.ContentDisposition.FileName))
                    {
                        var fileName = cont.Headers.ContentDisposition.FileName;
                        var path = cont.Headers.ContentDisposition.FileNameStar;
                        var folderId = cont.Headers.ContentDisposition.Name;

                        content = new Content
                        {
                            Name = fileName,
                            Path = path,
                            FolderId = folderId
                        };

                        db.Contents.Add(content);

                        var saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
                        if (!Directory.Exists(saveDir))
                        {
                            Directory.CreateDirectory(saveDir);
                        }

                        var filePath = Path.Combine(saveDir, fileName);
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        var bites = await cont.ReadAsByteArrayAsync();
                        if (bites != null && bites.Length > 0)
                        {
                            using (var streamMemory = new MemoryStream(bites))
                            {
                                streamMemory.Seek(0, SeekOrigin.Begin);
                                using (var fileStream = File.Create(filePath))
                                {
                                    streamMemory.CopyTo(fileStream);
                                }
                            }
                        }
                    }
                }
            }
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = content.Id }, content);
        }*/

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
