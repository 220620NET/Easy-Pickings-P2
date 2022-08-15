using Services;
using NewModels;
using CustomExceptions;
namespace WebAPI.Controllers
{
    public class CommentController
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// This will allow the API to read all tickets
        /// </summary>
        /// <remarks>Returns Status Code 404 if there are no tickets</remarks>
        /// <returns>202 and Tickets</returns>
        public IResult GetAllComments()
        {
            try
            {
                return Results.Accepted("/comment", _commentService.GetAllComments());
            }
            catch (CommentNotAvailableException)
            {
                return Results.BadRequest("No Comments have been made or all Comments have been removed by their owners");
            }
        }
        /// <summary>
        /// This will allow the API to read a specific ticket
        /// </summary>
        /// <remarks>Returns Status Code 404 if there is no such tickets</remarks>
        /// <param name="ticketID">The requested ticket</param>
        /// <returns>202 and the requested Ticket</returns>
        public IResult GetCommentById(int commentID)
        {
            try
            {
                return Results.Accepted("/comment/id/{commentID}", _commentService.GetCommentByCommentID(commentID));
            }
            catch (CommentNotAvailableException)
            {
                return Results.BadRequest("That Comment does not exist yet, please make sure what the comment ID is before requesting it");
            }
        }
        /// <summary>
        /// This will allow the API to read all tickets related to a claim
        /// </summary>
        /// <remarks>Returns Status code 404 if there are no tickets</remarks>
        /// <param name="claimID">The specific claim</param>
        /// <returns>202 and the Tickets</returns>
        public IResult GetCommentByUser(int userID)
        {
            try
            {
                return Results.Accepted("/comment/user/{userID}", _commentService.GetCommentByUser(userID));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist yet.");
            }
            catch (CommentNotAvailableException)
            {
                return Results.BadRequest("There is no comment associated with that user");
            }
        }
        /// <summary>
        /// This will allow the API to read all tickets
        /// </summary>
        /// <remarks>Returns Status Code 404 if there are no tickets</remarks>
        /// <param name="patientID">The requested patient</param>
        /// <returns></returns>
        public IResult GetCommentByPost(int postID)
        {
            try
            {
                return Results.Accepted("/comment/discussion/{postID}", _commentService.GetCommentsByPost(postID));
            }
            catch (InvalidDiscussionException)
            {
                return Results.BadRequest("That discussion does not exist yet.");
            }
            catch (CommentNotAvailableException)
            {
                return Results.BadRequest("That Disscussion doesn't have comments yet");
            }
        }
       
        public IResult CreateComment(Comment comment)
        {
            try
            {
                return Results.Accepted("/submit/comment", _commentService.CreateComment(comment));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist");
            }
            catch (InvalidDiscussionException)
            {
                return Results.BadRequest("That discussion does not exist");
            } 
        }
        public IResult UpdateComment(Comment comment)
        {
            try
            {
                return Results.Accepted("/update/comment", _commentService.UpdateComment(comment));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist");
            }
            catch (InvalidClaimException)
            {
                return Results.BadRequest("That claim does not exist");
            } 
            catch (CommentNotAvailableException)
            {
                return Results.BadRequest("That comment does not exist.");
            }
        }
        public IResult DeleteComment(int commentID)
        {
            try
            {
                return Results.Accepted("/delete/comment", _commentService.DeleteComment(commentID));
            }
            catch (CommentNotAvailableException)
            {
                return Results.BadRequest("That comment does not exist.");
            }
        }
    }
}
