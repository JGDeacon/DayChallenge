using DayChallengeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeModels.CommentModels
{
    public class CommentDetails
    {
        public int CommentID { get; set; }

        public string Text { get; set; }

        public Guid AuthorID { get; set; }

        public int PostID { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
