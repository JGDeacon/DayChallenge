using DayChallengeData;
using DayChallengeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeServices
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        //created the instance of a note
        //Post Reply Using Foreign Key
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                    CommentID = model.CommentID
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GetByCommentID
        public ReplyDetail GetReplyById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyId == commentId && e.AuthorId == _userId);
                return
                    new ReplyDetail
                    {

                        ReplyId = entity.ReplyId,
                        Text = entity.Text
                    };
            }
        }

    }
}
