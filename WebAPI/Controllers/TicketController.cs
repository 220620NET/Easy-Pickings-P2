using Services;
using NewModels;
using CustomExceptions;
namespace WebAPI.Controllers
{
    public class TicketController
    {
        private readonly TicketService ticketService;

        public TicketController(TicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        /// <summary>
        /// This will allow the API to read all tickets
        /// </summary>
        /// <remarks>Returns Status Code 404 if there are no tickets</remarks>
        /// <returns>202 and Tickets</returns>
        public IResult GetAllTickets()
        {
            try
            {
                return Results.Accepted("/ticket",ticketService.GetAllTickets());
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("No tickets have been made or all tickets have been removed by their owners");
            }
        }
        /// <summary>
        /// This will allow the API to read a specific ticket
        /// </summary>
        /// <remarks>Returns Status Code 404 if there is no such tickets</remarks>
        /// <param name="ticketID">The requested ticket</param>
        /// <returns>202 and the requested Ticket</returns>
        public IResult GetTicketByID(int ticketID)
        {
            try
            {
                return Results.Accepted("/ticket/id/{ticketID}",ticketService.GetTicketByID(ticketID));
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("That Ticket does not exist yet, please make sure what the ticket ID is before requesting it");
            }
        }
        /// <summary>
        /// This will allow the API to read all tickets related to a claim
        /// </summary>
        /// <remarks>Returns Status code 404 if there are no tickets</remarks>
        /// <param name="claimID">The specific claim</param>
        /// <returns>202 and the Tickets</returns>
        public IResult GetTicketByClaim(int claimID)
        {
            try
            {
                return Results.Accepted("/ticket/claim/{ID}",ticketService.GetTicketByClaim(claimID));
            }
            catch (InvalidClaimException)
            {
                return Results.BadRequest("That claim does not exist yet.");
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("There is no ticket associated with that claim");
            }
        }
        /// <summary>
        /// This will allow the API to read all tickets
        /// </summary>
        /// <remarks>Returns Status Code 404 if there are no tickets</remarks>
        /// <param name="patientID">The requested patient</param>
        /// <returns></returns>
        public IResult GetTicketByPatient(int patientID)
        {
            try
            {
                return Results.Accepted("/ticket/patient/{ID}",ticketService.GetTicketByPatient(patientID));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That patient does not exist yet.");
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("That patient hasn't made any tickets yet");
            }
        }
        public IResult GetTicketByPolicy(int policyID)
        {
            try
            {
                return Results.Accepted("/tickets/policy/{id}", ticketService.GetTicketByPolicy(policyID));
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("There are no tickets associated with that policy.");
            }
            catch (InvalidPolicyException)
            {
                return Results.BadRequest("That policy does not exist.");
            }
          
        }
        public IResult CreateTicket(Ticket ticket)
        {
            try
            {
                return Results.Accepted("/submit/ticket", ticketService.CreateTicket(ticket));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist");
            }
            catch (InvalidClaimException)
            {
                return Results.BadRequest("That claim does not exist");
            }
            catch (InvalidPolicyException)
            {
                return Results.BadRequest("That policy does not exist");
            }
        }
        public IResult UpdateTicket(Ticket ticket)
        {
            try
            {
                return Results.Accepted("/update/ticket", ticketService.UpdateTicket(ticket));
            }
            catch (InvalidUserException)
            {
                return Results.BadRequest("That user does not exist");
            }
            catch (InvalidClaimException)
            {
                return Results.BadRequest("That claim does not exist");
            }
            catch (InvalidPolicyException)
            {
                return Results.BadRequest("That policy does not exist");
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("That ticket does not exist.");
            }
        }
        public IResult DeleteTicket(int ticketID)
        {
            try
            {
                return Results.Accepted("/delete/ticket", ticketService.DeleteTicket(ticketID));
            }
            catch (TicketNotAvailableException)
            {
                return Results.BadRequest("That ticket does not exist.");
            }
        }
    }
}
