using NewModels; 

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
        /// Will create a new entry for a Ticket in the tickets table in the database
        /// </summary>
        /// <param name="ticket">New ticket</param>
        /// <returns>New ticket</returns> 
        public Ticket CreateTicket(Ticket ticket)
        { 
            _dbContext.tickets.Add(ticket);
            _dbContext.SaveChanges();
            return ticket ?? throw new NotImplementedException();
        }

        /// <summary>
        /// This will remove a ticket from the discussion board
        /// </summary>
        /// <param name="ticketID">Ticket ID to delete</param>
        /// <returns>Ticket that was deleted</returns> 
        public Ticket DeleteTicket(int ticketID)
        {
            Ticket? ticketToDelete =_dbContext.tickets.FirstOrDefault(ticket=>ticket.ticketID==ticketID);
            if (ticketToDelete != null)
            {
                _dbContext.tickets.Remove(ticketToDelete);
            }
            else
            {
                throw new Exception();
            }
            _dbContext.SaveChanges();
            return ticketToDelete ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Will get all tickets from the database
        /// </summary>
        /// <returns>All Tickets</returns>
        public List<Ticket> GetAllTickets()
        {
            return _dbContext.tickets.ToList() ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Will Grab all tickets related to a claim
        /// </summary>
        /// <param name="claimID">Claim ID to sort by</param>
        /// <returns>The specific ticket by claim</returns>
        public List<Ticket> GetTicketByClaim(int claimID)
        {
            return _dbContext.tickets.Where(p => p.claimID == claimID).ToList() ?? throw new NotImplementedException();
        }
        /// <summary>
        /// Will grab all tickets related to a patient
        /// </summary>
        /// <param name="patientID">Specific patientID</param>
        /// <returns>List of all tickets from a particular patient</returns>
        public List<Ticket> GetTicketByPatient(int patientID)
        {
            return _dbContext.tickets.Where(p => p.userID == patientID).ToList() ?? throw new NotImplementedException();
        }

        /// <summary>
        /// Will update a ticket
        /// </summary>
        /// <param name="ticket">Ticket to update</param>
        /// <returns>Updated ticket</returns>
        public Ticket UpdateTicket(Ticket ticket)
        {
            _dbContext.tickets.Update(ticket);
            _dbContext.SaveChanges();
            return ticket ?? throw new NotImplementedException();
        }
    }
}
