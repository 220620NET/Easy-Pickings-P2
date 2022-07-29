using Services;
using NewModels; 
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
            catch (NotImplementedException)
            {
                return Results.BadRequest();
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
            catch (NotImplementedException)
            {
                return Results.BadRequest();
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
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
        public IResult CreateTicket(Ticket ticket)
        {
            try
            {
                return Results.Accepted("/submit/ticket", ticketService.CreateTicket(ticket));
            }
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
        public IResult UpdateTicket(Ticket ticket)
        {
            try
            {
                return Results.Accepted("/update/ticket", ticketService.UpdateTicket(ticket));
            }
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
        public IResult DeleteTicket(int ticketID)
        {
            try
            {
                return Results.Accepted("/delete/ticket", ticketService.DeleteTicket(ticketID));
            }
            catch (NotImplementedException)
            {
                return Results.BadRequest();
            }
        }
    }
}
