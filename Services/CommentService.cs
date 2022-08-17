using DataAccess;
using NewModels;
using CustomExceptions;

namespace Services
{
    public class CommentService
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IUserRepo _userRepo;
        public CommentService(ICommentRepo commentRepo, IUserRepo userRepo)
        {
            _commentRepo = commentRepo;
            _userRepo = userRepo;
        }
        public List<Comment> GetAllComments()
        {
            return _commentRepo.GetAllComments() ?? throw new CommentNotAvailableException();
        }
        public List<Comment> GetCommentByUser(int userID)
        {
            try
            {
                List<User> all = _userRepo.GetAllUsers();
                bool there = false;
                foreach (User user in all)
                {
                    if (userID == user.userID)
                    {
                        there = true;
                    }
                }
                if (!there)
                {
                    throw new InvalidUserException();
                }
                return _commentRepo.GetCommentByUser(userID);
            }
            catch (InvalidUserException)
            {
                throw new InvalidUserException();
            }
            catch (NullReferenceException)
            {
                throw new CommentNotAvailableException();
            }
        }
        public List<Comment> GetCommentsByPost(int postID)
        {
            try
            {
                return _commentRepo.GetCommentByPost(postID);
            }
            catch (NullReferenceException)
            {
                throw new InvalidDiscussionException();
            }
        }
        public Comment GetCommentByCommentID(int commentID)
        {
            try
            {
                List<Comment> all = _commentRepo.GetAllComments();
                bool there = false;
                foreach (Comment comment in all)
                {
                    if (commentID == comment.commentID)
                    {
                        there = true;
                    }
                }
                if (!there)
                {
                    throw new CommentNotAvailableException();
                }
                return _commentRepo.GetCommentByID(commentID);
            }
            catch (CommentNotAvailableException)
            {
                throw new CommentNotAvailableException();
            }
        }
        public Comment CreateComment(Comment CommentToAdd)
        {
            try
            {
                GetCommentByUser(CommentToAdd.userID);
                GetCommentsByPost(CommentToAdd.messageID);
                return _commentRepo.CreateComment(CommentToAdd);
            }
            catch (CommentNotAvailableException)
            {
                return _commentRepo.CreateComment(CommentToAdd);
            }
            catch (InvalidDiscussionException)
            {
                throw new InvalidDiscussionException();
            }
            catch (InvalidUserException)
            {
                throw new InvalidUserException();
            }
        }

        public Comment UpdateComment(Comment CommentToUpdate)
        {
            try
            {
                GetCommentByUser(CommentToUpdate.userID);
                GetCommentsByPost(CommentToUpdate.messageID);
                GetCommentByCommentID(CommentToUpdate.commentID);
                return _commentRepo.UpdateComment(CommentToUpdate);
            }
            catch (CommentNotAvailableException)
            {
                throw new CommentNotAvailableException();
            }
            catch (InvalidDiscussionException)
            {
                throw new InvalidDiscussionException();
            }
            catch (InvalidUserException)
            {
                throw new InvalidUserException();
            }
        }
        public Comment DeleteComment(int CommentIDToDelete)
        {
            try
            {
                Comment comment = GetCommentByCommentID(CommentIDToDelete);
                _commentRepo.DeleteComment(CommentIDToDelete);
                return comment;
            }
            catch (CommentNotAvailableException)
            {
                throw new CommentNotAvailableException();
            }
        }
    }
}
