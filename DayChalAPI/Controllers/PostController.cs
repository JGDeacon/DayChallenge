using DayChallengeModels;
using DayChallengeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace DayChallengeAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetAllPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok("You have created new post");

        }
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var PostService = new PostService(userId);
            return PostService;

        }

        public IHttpActionResult Get(Guid id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok();
        }

        public IHttpActionResult Put(PostEdit post)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok("Post got updated successfully!");
        }

        public IHttpActionResult Delete(int id)
        {

            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok("Post got deleted successfully!");
        }
    }
}
