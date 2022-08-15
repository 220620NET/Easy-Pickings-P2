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
        public Ticket GetTicketByID(int ticketID);
        public List<Ticket> GetTicketByClaim(int claimID);
        public List<Ticket> GetTicketByPatient(int patientID);
        public List<Ticket> GetTicketByPolicy(int policyID);
        public Ticket CreateTicket(Ticket ticket);
        public Ticket UpdateTicket(Ticket ticket);
        public bool DeleteTicket(int ticketID);
    }
}
