using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeModels
{
    public class ReplyCreate
    {
        [Required]
        public string Text { get; set; }
        public int CommentID { get; set; }
    }
}
