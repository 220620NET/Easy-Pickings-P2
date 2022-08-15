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
        /// Will create a new ticket
        /// </summary>
        /// <param name="ticket">Ticket to be created</param>
        /// <returns>The ticket that was created</returns>
        /// <exception cref="TicketNotAvailable">How did you get here</exception> 
        public Ticket CreateTicket(Ticket ticket)
        { 
            _dbContext.Tickets.Add(ticket);
            Finish();
            return ticket ?? throw new TicketNotAvailableException();
        }

        /// <summary>
        /// This will remove a ticket from the discussion board
        /// </summary>
        /// <param name="ticketID">Ticket ID to delete</param>
        /// <returns>Ticket that was deleted</returns> 
        /// <exception cref="TicketNotAvailable">That ticket does not exist</exception>
        public bool DeleteTicket(int ticketID)
        {
            Ticket? ticketToDelete =_dbContext.Tickets.FirstOrDefault(ticket=>ticket.ticketID==ticketID);
            if (ticketToDelete != null)
            {
                _dbContext.Entry(ticketToDelete).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            } 
            return false;
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
        /// <exception cref="TicketNotAvailable">There are no tickets related to that claim</exception>
        public List<Ticket> GetTicketByClaim(int claimID)
        {
            return _dbContext.Tickets.AsNoTracking().Where(p => p.claimID == claimID).ToList();
        }
        /// <summary>
        /// Will grab a particular ticket
        /// </summary>
        /// <param name="ticketID">Specific ticketID</param>
        /// <returns>Ticket in question</returns>
        /// <exception cref="TicketNotAvailable">That ticket does not exist</exception>
        public Ticket GetTicketByID(int ticketID)
        {
            return _dbContext.Tickets.AsNoTracking().FirstOrDefault(p => p.ticketID == ticketID)?? throw new TicketNotAvailableException();
        }
        /// <summary>
        /// Will grab all tickets related to a patient
        /// </summary>
        /// <param name="patientID">Specific patientID</param>
        /// <returns>List of all tickets from a particular patient</returns>  
        /// <exception cref="TicketNotAvailable">There are no tickets related to that patient</exception>
        public List<Ticket> GetTicketByPatient(int patientID)
        {
            return _dbContext.Tickets.AsNoTracking().Where(p => p.userID == patientID).ToList();
        }
        /// <summary>
        /// Will grab all tickets related to a policy
        /// </summary>
        /// <param name="policyID">Specific policyID</param>
        /// <returns>List of all tickets from a particular policy</returns>
        /// <exception cref="TicketNotAvailable">There are no tickets related to that policy</exception>
        public List<Ticket> GetTicketByPolicy(int policyID)
        {
            return _dbContext.Tickets.AsNoTracking().Where(p => p.policyID == policyID).ToList();
        }

        /// <summary>
        /// Will update a ticket
        /// </summary>
        /// <param name="ticket">Ticket to update</param>
        /// <returns>Updated ticket</returns>
        /// <exception cref="TicketNotAvailable">That ticket does not exist</exception>
        public Ticket UpdateTicket(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            Finish();
            return ticket ?? throw new TicketNotAvailableException();
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
