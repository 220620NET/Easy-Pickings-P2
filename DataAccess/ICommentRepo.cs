using NewModels;

namespace DataAccess
{
    public interface ICommentRepo
    {
        public Comment CreateComment(Comment commentToAdd);
        public Comment UpdateComment(Comment CommentToUpdate);
        public bool DeleteComment(int commentIDToDelete);
        public List<Comment> GetAllComments();
        public Comment GetCommentByID(int commentID);
        public List<Comment> GetCommentByUser(int userID);
        public List<Comment> GetCommentByPost(int postID);

    }
}
