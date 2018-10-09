using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Coffee.Models;

namespace Coffee.Controllers.Api
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostController : Controller
    {
        private IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("api/post/all")]
        public IEnumerable<PostViewModel> Posts()
        {
            return _postRepository.Get().Select(x => new PostViewModel {
                post_id = x.Id,
                image = x.Image,
                is_liked = false,
                likes = x.Likes,
                title = x.Title
            });
        }
    }
}