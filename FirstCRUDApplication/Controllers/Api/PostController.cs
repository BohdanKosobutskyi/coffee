using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Coffee.Repositories.Interfaces;
using Coffee.DbEntities;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Coffee.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

        [HttpGet("api/mobile/post/all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PostViewModel>))]
        public async Task Posts()
        {
            var response = _postRepository.Get().Select(x => new PostViewModel {
                post_id = x.Id,
                image = x.Image,
                is_liked = false,
                likes = x.Likes,
                title = x.Title
            });

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("api/mobile/post/create")]
        public void Create([FromBody] PostCreateViewModel post)
        {
            var postDbEntity = new Post
            {
                CompanyId = post.company_id,
                Image = post.image,
                Title = post.title
            };

            _postRepository.Create(postDbEntity);

            Response.StatusCode = 200;
            return;
        }
    }
}