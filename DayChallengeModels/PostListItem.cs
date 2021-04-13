using DayChallengeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeModels
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

    }
}
