using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public interface IDiscussionRepo
    {
        public Discussion CreateDiscussion(Discussion discussion);
        public bool DeleteDiscussion(int discussionID);
        public List<Discussion> GetAllDiscussions();
        public Discussion GetByID(int discussionID);
        public List<Discussion> GetByUserID(int userID);
        public Discussion UpdateDiscussion(Discussion discussion);
        
    }
}
