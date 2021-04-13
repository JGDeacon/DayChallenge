using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeData
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string Text { get; set; }
        public Guid AuthorID { get; set; }
        public virtual List<Reply> Replies { get; set; }
        //[ForeignKey(nameof(Reply))]
        public int PostID { get; set; } //Needs to be FK after first migration
        public virtual Reply Reply { get; set; }
    }
}
