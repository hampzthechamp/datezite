using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using datezite.Models;
namespace datezite.Controllers
{
    
    public class EntryApiController : ApiController
    {
        public void newEntry(string _authourId, string _recipientId, string _content)
        {
            using(var _context = new ApplicationDbContext())
            {
                var entry = new Entry { AuthorId = _authourId, RecipientId = _recipientId, Content = _content };
                _context.Entries.Add(entry);
            }
        }
        [HttpPost]
        public void Post([FromBody]Entry _entry)
        {
            //try
            
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entries.Add(_entry);
                    _context.SaveChanges();

                    //var msg = Request.CreateResponse(HttpStatusCode.Created, _entry);
                    //msg.Headers.Location = new Uri(Request.RequestUri + _entry.Id.ToString());
                    //return msg;
               
                }
            //catch(Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
        }
    }
}
