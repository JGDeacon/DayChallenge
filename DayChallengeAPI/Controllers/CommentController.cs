using DayChallengeModels.CommentModels;
using DayChallengeServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DayChallengeAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userID);
            return commentService;
        }

        public IHttpActionResult PostComment(CommentAdd model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCommentService();
            if (!service.AddComment(model))
            {
                return InternalServerError();
            }
            return Ok("Comment Added");
        }
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentByID(id);
            return Ok(comments);
        }


    }
}
