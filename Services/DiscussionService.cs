using DataAccess;
using NewModels;
using CustomExceptions;
namespace Services
{
    public class DiscussionService
    {
        private readonly IDiscussionRepo _discussion;
        public DiscussionService(IDiscussionRepo discussion)
        {
            _discussion = discussion;
        }
        /// <summary>
        /// Checks for exceptions while creating a discussion post
        /// </summary>
        /// <param name="newDiscussion"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Discussion CreateDiscussision(Discussion newDiscussion)
        {
            return _discussion.CreateDiscussion(newDiscussion);
            throw new DiscussionNotAvailableException();
        }
        public Discussion DeleteDiscussion(int discussionID)
        {
            try
            {
                Discussion d =GetByID(discussionID);
                _discussion.DeleteDiscussion(discussionID);
                return d;
            }
            catch (DiscussionNotAvailableException)
            {
                throw new DiscussionNotAvailableException();
            }
        }
        public List<Discussion> GetAllDiscussions()
        {
            return _discussion.GetAllDiscussions();
            throw new DiscussionNotAvailableException();
        }
        public Discussion GetByID(int discussionID)
        {
            try
            {
                List<Discussion> all = _discussion.GetAllDiscussions();
                bool there = false;
                foreach(Discussion discussion in all)
                {
                    if(discussion.discussionID == discussionID)
                    {
                        there = true;
                    }
                }
                if(!there)
                {
                    throw new DiscussionNotAvailableException();
                }
                return _discussion.GetByID(discussionID);
            }
            catch (DiscussionNotAvailableException)
            {
                throw new DiscussionNotAvailableException();
            }
            catch (NullReferenceException)
            {
                throw new DiscussionNotAvailableException();
            }
        }
        public List<Discussion> GetByUserID(int userID)
        {
            try
            {
                List<Discussion> all = _discussion.GetAllDiscussions();
                bool there = false;
                foreach (Discussion discussion in all)
                {
                    if (discussion.discussionID == userID)
                    {
                        there = true;
                    }
                }
                if (!there)
                {
                    throw new DiscussionNotAvailableException();
                }
                return _discussion.GetByUserID(userID);
            }
            catch (DiscussionNotAvailableException)
            {
                throw new DiscussionNotAvailableException();
            }
            catch (NullReferenceException)
            {
                throw new DiscussionNotAvailableException();
            }
        }
        public Discussion UpdateDiscussion(Discussion discussionToUpdate)
        {
            try
            {
                GetByID(discussionToUpdate.discussionID);
                return _discussion.UpdateDiscussion(discussionToUpdate);

            }
            catch (DiscussionNotAvailableException)
            {
                throw new DiscussionNotAvailableException();
            }


        }
    }
}
