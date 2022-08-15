using Services;
using NewModels;
using CustomExceptions;
namespace WebAPI.Controllers
{
    public class DiscussionController
    {
        private readonly DiscussionService _service;
        public DiscussionController(DiscussionService service)
        {
            _service = service;
        }

        public IResult CreateDiscussion(Discussion discussion)
        {
            try
            {
                return Results.Accepted("/submit/discussion", _service.CreateDiscussision(discussion));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist");
            }
        }
        public IResult UpdateDiscussion(Discussion discussionToUpdate)
        {
            try
            {
                return Results.Accepted("/update/discussion", _service.UpdateDiscussion(discussionToUpdate));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist");
            }

            catch (DiscussionNotAvailableException)
            {
                return Results.BadRequest("That discussion does not exist.");
            }
        }
        public IResult DeleteDiscussion(int discussionID)
        {
            try
            {
                return Results.Accepted("/delete/discussion", _service.DeleteDiscussion(discussionID));
            }
            catch (DiscussionNotAvailableException)
            {
                return Results.BadRequest("That discussion does not exist.");
            }
        }

        public IResult GetAllDiscussions()
        {
            try
            {
                return Results.Accepted("/discussion", _service.GetAllDiscussions());
            }
            catch (DiscussionNotAvailableException)
            {
                return Results.BadRequest("No Current Posts");
            }
        }
        public IResult GetByID(int discussionID)
        {
            try
            {
                return Results.Accepted("/discussion/id/{discussionID}", _service.GetByID(discussionID));
            }
            catch (DiscussionNotAvailableException)
            {
                return Results.BadRequest("No current posts by that ID");
            }
        }
        public IResult GetByUserID(int userID)
        {
            try
            {
                return Results.Accepted("/discussion/userid/{userID}", _service.GetByUserID(userID));
            }
            catch (DiscussionNotAvailableException)
            {
                return Results.BadRequest("No current posts by that ID");
            }
        }

    }
}