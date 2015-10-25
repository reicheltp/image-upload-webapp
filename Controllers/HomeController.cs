using System;
using Microsoft.AspNet.Mvc;
using FaceWebApp.Models;

namespace FaceWebApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return Index("cats");
		}
		
		public IActionResult Index(string id)
		{			
			ViewData["GalleryName"] = id;
			
			if(GalleryController.Galleries.ContainsKey(id))
				ViewData["Gallery"] = GalleryController.Galleries[id];
			else
				ViewData["Gallery"] = new ImageUpload[0];
			
			return View();
		}
	}
}