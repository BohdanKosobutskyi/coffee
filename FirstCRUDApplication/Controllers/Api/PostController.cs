using System.Collections.Generic;
using System.Threading.Tasks;
using Coffee.Models;
using Microsoft.AspNetCore.Mvc;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;

namespace Coffee.Controllers.Api
{
    public class PostController : Controller
    {
        private IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("/post/all")]
        public IEnumerable<Post> Posts(string refresh_token)
        {
            return _postRepository.Get();
        }
    }
}