using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coeus.Data.FileManager;
using Coeus.Data.Repository;
using Coeus.Models;
using Coeus.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coeus.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var Posts = _repo.getAllPost();
            return View(Posts);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.getPost((int)id);
                return View(new PostViewModel
                {
                    Title = post.Title,
                    Id = post.Id,
                    Body = post.Body,
                    CurrentImage = post.Image,
                    Description = post.Description,
                    Tags = post.Tags,
                    Category = post.Category,
                    GitHubLink = post.GitHubLink,
                    ProjectLink = post.ProjectLink
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Title = vm.Title,
                Id = vm.Id,
                Body = vm.Body,
                Description = vm.Description,
                Tags = vm.Tags,
                Category = vm.Category,
                GitHubLink = vm.GitHubLink,
                ProjectLink = vm.ProjectLink,
                
                Image = await _fileManager.SaveImage(vm.Image)
            };

            if (vm.Image == null)
                post.Image = vm.CurrentImage;
            else
                post.Image = await _fileManager.SaveImage(vm.Image);

            if (vm.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}