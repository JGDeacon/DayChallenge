using DayChallengeData;
using DayChallengeModels.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeServices
{
    public class CommentService
    {
        private readonly Guid _userID;
        public CommentService(Guid userID)
        {
            _userID = userID;
        }

        public bool AddComment(CommentAdd model)
        {
            var entity = new Comment()
            {
                AuthorID = _userID,
                Text = model.Text,
                Id = model.PostID

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentDetails> GetComments()
        {
            using (var ctx = new ApplicationDbContext()) //Couldn't this be a private readonly scoped to the entire class?
            {
                var query = ctx.Comments.Where(e => e.CommentID >= 1).Select(e => new CommentDetails
                {
                    CommentID = e.CommentID,
                    Text = e.Text,
                    AuthorID = e.AuthorID,
                    PostID = e.Id,
                    Replies = ctx.Replies.Where(z => z.CommentID == e.CommentID).Select(z => new Reply { ReplyId = z.ReplyId, Text = z.Text, AuthorId = z.AuthorId }).ToList()
                });

                return query.ToArray();
            }
        }
        public CommentDetails GetCommentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.CommentID == id);
                return new CommentDetails
                {
                    CommentID = entity.CommentID,
                    Text = entity.Text,
                    AuthorID = entity.AuthorID,
                    PostID = entity.Id,
                    Replies = ctx.Replies.Where(z => z.CommentID == entity.CommentID).Select(z => new Reply { ReplyId = z.ReplyId, Text = z.Text, AuthorId = z.AuthorId }).ToList()
                };
            }
        }
    }
}
