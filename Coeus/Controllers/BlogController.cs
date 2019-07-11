using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coeus.Data;
using Coeus.Data.FileManager;
using Coeus.Data.Repository;
using Coeus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coeus.Controllers
{
    public class BlogController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public BlogController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }


        public IActionResult Index(string category)
        {
            var Posts = string.IsNullOrEmpty(category) ? _repo.getAllPost() : _repo.getAllPost(category);
            // Boolean = true : false / is the right side true run getallpost if not run getallpost with category
            return View(Posts);
        }

        [Route("Post")]
        public IActionResult Post(int id)
        {
            var post = _repo.getPost(id);

            return View(post);
        }
        [HttpGet("/Image/{image}")]
        [ResponseCache(CacheProfileName = "Monthly")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}