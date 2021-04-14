using DayChallengeModels;
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
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get(int commentId)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(commentId);
            return Ok(reply);
        }
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();
            return Ok();
        }
        private ReplyService CreateReplyService()
        {
            //not sure if line 16 is right
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
        
    }
}
