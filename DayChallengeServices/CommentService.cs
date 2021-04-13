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

        public bool AddComment()
        {
            //todo
            return true;
        }
    }
}
