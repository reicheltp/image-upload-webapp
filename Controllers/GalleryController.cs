using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FaceWebApp.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FaceWebApp.Controllers
{
    [Route("api/[controller]")]
    public class GalleryController : Controller
    {
        public static IDictionary<string, IList<ImageUpload>> Galleries 
            = new ConcurrentDictionary<string, IList<ImageUpload>>();
        
        // GET: api/values
        [HttpGet("{galleryId}")]
        public IEnumerable<ImageUpload> Get(string galleryId)
        {
            if(!Galleries.ContainsKey(galleryId))
                return new ImageUpload[0];
            
            return Galleries[galleryId];
        }

        // POST api/values
        [HttpPost("{galleryId}")]
        public void Post(string galleryId, [FromBody]ImageUpload value)
        {
            Console.WriteLine($"add image {value?.Title} to {galleryId} with size: {value?.Image?.Length}");
            
            if(!Galleries.ContainsKey(galleryId))
                Galleries[galleryId] = new List<ImageUpload>();
                
            Galleries[galleryId].Add(value);
        }
    }
}
