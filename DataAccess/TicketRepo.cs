using NewModels;
using Microsoft.EntityFrameworkCore;
using CustomExceptions;
namespace DataAccess
{
    public class TicketRepo : ITicket
    {
        // Dependency injection
        private readonly InsuranceDbContext _dbContext;
        public TicketRepo(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Ticket CreateTicket(Ticket ticket)
        { 
            _dbContext.Tickets.Add(ticket);
            Finish();
            return ticket ?? throw new NotImplementedException();
        }

        /// <summary>
        /// This will remove a ticket from the discussion board
        /// </summary>
        /// <param name="ticketID">Ticket ID to delete</param>
        /// <returns>Ticket that was deleted</returns> 
        public Ticket DeleteTicket(int ticketID)
        {
            Ticket ticketToDelete =_dbContext.Tickets.FirstOrDefault(ticket=>ticket.ticketID==ticketID)??throw new NotImplementedException();
            _dbContext.Tickets.Remove(ticketToDelete);
            Finish();
            return ticketToDelete;
        }

        /// <summary>
        /// Will get all tickets from the database
        /// </summary>
        /// <returns>All Tickets</returns>
        public List<Ticket> GetAllTickets()
        {
            return _dbContext.Tickets.AsNoTracking().ToList() ??  new List<Ticket>();
        }

        /// <summary>
        /// Will Grab all tickets related to a claim
        /// </summary>
        /// <param name="claimID">Claim ID to sort by</param>
        /// <returns>The specific ticket by claim</returns>
        public List<Ticket> GetTicketByClaim(int claimID)
        {
            return _dbContext.Tickets.AsNoTracking().Where(p => p.claimID == claimID).ToList() ?? throw new InvalidClaimException();
        }

        public Ticket GetTicketByID(int ticketID)
        {
            return _dbContext.Tickets.AsNoTracking().FirstOrDefault(p => p.ticketID == ticketID)?? throw new NotImplementedException();
        }
        /// <summary>
        /// Will grab all tickets related to a patient
        /// </summary>
        /// <param name="patientID">Specific patientID</param>
        /// <returns>List of all tickets from a particular patient</returns>
        public List<Ticket> GetTicketByPatient(int patientID)
        {
            return _dbContext.Tickets.AsNoTracking().Where(p => p.userID == patientID).ToList() ?? throw new InvalidUserException();
        }

        public List<Ticket> GetTicketByPolicy(int policyID)
        {
            return _dbContext.Tickets.AsNoTracking().Where(p => p.policyID == policyID).ToList() ?? throw new InvalidPolicyException();
        }

        /// <summary>
        /// Will update a ticket
        /// </summary>
        /// <param name="ticket">Ticket to update</param>
        /// <returns>Updated ticket</returns>
        public Ticket UpdateTicket(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            Finish();
            return ticket ?? throw new NotImplementedException();
        }
        /// <summary>
        /// Persist changes and clear the tracker
        /// </summary>
        protected void Finish( )
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }
}
