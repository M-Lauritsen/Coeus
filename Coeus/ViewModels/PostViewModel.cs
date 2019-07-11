using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coeus.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";
        public string GitHubLink { get; set; } = "";
        public string ProjectLink { get; set; } = "";

        public string CurrentImage { get; set; } = "";

        public IFormFile Image { get; set; } = null;
    }
}
