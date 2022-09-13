using NewModels;

namespace DataAccess
{
    public interface ICommentRepo
    {
        Comment CreateComment(Comment commentToAdd);
        Comment UpdateComment(Comment CommentToUpdate);
        bool DeleteComment(int commentIDToDelete);
        List<Comment> GetAllComments();
        Comment GetCommentByID(int commentID);
        List<Comment> GetCommentByUser(int userID);
        List<Comment> GetCommentByPost(int postID);

    }
}
