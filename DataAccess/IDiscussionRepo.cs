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
        Discussion CreateDiscussion(Discussion discussion);
        bool DeleteDiscussion(int discussionID);
        List<Discussion> GetAllDiscussions();
        Discussion GetByID(int discussionID);
        List<Discussion> GetByUserID(int userID);
        Discussion UpdateDiscussion(Discussion discussion);
        
    }
}
