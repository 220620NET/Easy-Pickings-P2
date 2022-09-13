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
        List<Ticket> GetAllTickets();
        Ticket GetTicketByID(int ticketID);
        List<Ticket> GetTicketByClaim(int claimID);
        List<Ticket> GetTicketByPatient(int patientID);
        List<Ticket> GetTicketByPolicy(int policyID);
        Ticket CreateTicket(Ticket ticket);
        Ticket UpdateTicket(Ticket ticket);
        bool DeleteTicket(int ticketID);
    }
}
