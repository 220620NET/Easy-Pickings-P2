using DataAccess.Entities; 

namespace DataAccess
{
    public class TicketRepo : ITicket
    {
        // Dependency injection
        private readonly easypickingsContext _dbContext;
        public TicketRepo(easypickingsContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Will create a new entry for a Ticket in the tickets table in the database
        /// </summary>
        /// <param name="ticket">New ticket</param>
        /// <returns>New ticket</returns> 
        public Ticket CreateTicket(Ticket ticket)
        { 
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return ticket;
        }

        /// <summary>
        /// This will remove a ticket from the discussion board
        /// </summary>
        /// <param name="ticketID">Ticket ID to delete</param>
        /// <returns>Ticket that was deleted</returns> 
        public Ticket DeleteTicket(int ticketID)
        {
            Ticket? ticketToDelete =_dbContext.Tickets.FirstOrDefault(ticket=>ticket.TicketId==ticketID);
            if (ticketToDelete != null)
            {
                _dbContext.Tickets.Remove(ticketToDelete);
            }
            else
            {
                throw new Exception();
            }
            _dbContext.SaveChanges();
            return ticketToDelete;
        }

        /// <summary>
        /// Will get all tickets from the database
        /// </summary>
        /// <returns>All Tickets</returns>
        public List<Ticket> GetAllTickets()
        {
            return _dbContext.Tickets.ToList();
        }

        /// <summary>
        /// Will Grab all tickets related to a claim
        /// </summary>
        /// <param name="claimID">Claim ID to sort by</param>
        /// <returns>The specific ticket by claim</returns>
        public List<Ticket> GetTicketByClaim(int claimID)
        {
            return _dbContext.Tickets.Where(p => p.ClaimIdFk == claimID).ToList();
        }
        /// <summary>
        /// Will grab all tickets related to a patient
        /// </summary>
        /// <param name="patientID">Specific patientID</param>
        /// <returns>List of all tickets from a particular patient</returns>
        public List<Ticket> GetTicketByPatient(int patientID)
        {
            return _dbContext.Tickets.Where(p => p.UserIdFk == patientID).ToList();
        }

        /// <summary>
        /// Will update a ticket
        /// </summary>
        /// <param name="ticket">Ticket to update</param>
        /// <returns>Updated ticket</returns>
        public Ticket UpdateTicket(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            _dbContext.SaveChanges();
            return ticket;
        }
    }
}
