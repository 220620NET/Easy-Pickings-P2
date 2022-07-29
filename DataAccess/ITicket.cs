using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;

namespace DataAccess
{
    public interface ITicket
    {
        public List<Ticket> GetAllTickets();
        public List<Ticket> GetTicketByClaim(int claimID);
        public List<Ticket> GetTicketByPatient(int patientID);
        public Ticket CreateTicket(Ticket ticket);
        public Ticket UpdateTicket(Ticket ticket);
        public Ticket DeleteTicket(int ticketID);
    }
}
