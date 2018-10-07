using System.Collections.Generic;
using System.Threading.Tasks;
using Coffee.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers.Api
{
    public class PostController : Controller
    {
        [HttpGet("/post/all")]
        public async Task<List<PostViewModel>> Posts(string refresh_token)
        {
            return await Task.Run(() => {
                return posts;
            });
        }

        private static List<PostViewModel> posts = new List<PostViewModel>()
        {
            new PostViewModel
            {
                post_id = 1,
                image = "test",
                is_liked = true,
                title = "test_post",
                like_count = 10
            },
            new PostViewModel
            {
                post_id = 2,
                image = "test2",
                is_liked = true,
                title = "test_post2",
                like_count = 10
            }
        };
    }
}