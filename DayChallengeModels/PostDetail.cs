using DayChallengeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayChallengeModels
{
    public class PostDetail
    {
        
        public int PostId { get; set; }
      
        public string Title { get; set; }
      
        public string Text { get; set; }
        
        public Guid AuthorId { get; set; }

        public virtual Comment Comment { get; set; }

    }
}
