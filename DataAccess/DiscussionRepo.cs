using Microsoft.EntityFrameworkCore;
using CustomExceptions;
using Microsoft.Data.SqlClient;
using NewModels;

namespace DataAccess
{
    public class DiscussionRepo : IDiscussionRepo
    {
        /// <summary>
        /// Dependency Injection
        /// </summary>
        private readonly InsuranceDbContext _dbContext;
        public DiscussionRepo(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Will create a new discussion post
        /// </summary>
        /// <param name="discussion"></param>
        /// <returns></returns>
        public Discussion CreateDiscussion(Discussion newDiscussion)
        {
            _dbContext.Discussions.Add(newDiscussion);
            Finish();
            return newDiscussion ?? throw new DiscussionNotAvailableException();
        }
        /// <summary>
        /// Deletes discussion post
        /// </summary>
        /// <param name="discussionID"></param>
        /// <returns></returns>
        /// <exception cref="DiscussionNotAvailableException"></exception>
        public Discussion DeleteDiscussion(int discussionID)
        {
            Discussion discussionToDelete = _dbContext.Discussions.FirstOrDefault(discussion => discussion.discussionID == discussionID) ?? throw new DiscussionNotAvailableException();
            Finish();
            return discussionToDelete;
        }
        /// <summary>
        /// Lists All Discussion Posts
        /// </summary>
        /// <returns></returns>
        public List<Discussion> GetAllDiscussions()
        {
            return _dbContext.Discussions.AsNoTracking().ToList();
        }
        /// <summary>
        /// Gets a post by the post ID
        /// </summary>
        /// <param name="discussionID"></param>
        /// <returns></returns>
        /// <exception cref="DiscussionNotAvailableException"></exception>
        public Discussion GetByID(int discussionID)
        {
            return _dbContext.Discussions.AsNoTracking().FirstOrDefault(d => d.discussionID == discussionID) ?? throw new DiscussionNotAvailableException();
        }
        /// <summary>
        /// Gets a post by the user ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Discussion> GetByUserID(int userID)
        {
            return _dbContext.Discussions.AsNoTracking().Where(d => d.userID == userID).ToList();
        }
        /// <summary>
        /// Updates a discussion post
        /// </summary>
        /// <param name="discussion"></param>
        /// <returns></returns>
        /// <exception cref="DiscussionNotAvailableException"></exception>
        public Discussion UpdateDiscussion(Discussion discussion)
        {
            _dbContext.Discussions.Update(discussion);
            Finish();
            return discussion ?? throw new DiscussionNotAvailableException();
        }
        protected void Finish()
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }
}