using DataAccess;
using DataAccess.Entities;

namespace Services;
public class TicketService
{
    private readonly ITicket _ticket;
    public TicketService(ITicket ticket)
    {
        _ticket = ticket;
    }
    public List<Ticket> GetAllTickets()
    {
        return _ticket.GetAllTickets() ?? throw new NotImplementedException();
    }
    public List<Ticket> GetTicketByClaim(int claimID)
    {
        return _ticket.GetTicketByClaim(claimID) ?? throw new NotImplementedException();
    }
    public List<Ticket> GetTicketByPatient(int patientID)
    {
        return _ticket.GetTicketByPatient(patientID) ?? throw new NotImplementedException();
    }
    public Ticket CreateTicket(Ticket ticket)
    {
        return _ticket.CreateTicket(ticket) ?? throw new NotImplementedException();
    }
    public Ticket UpdateTicket(Ticket ticket)
    {
        return _ticket.UpdateTicket(ticket) ?? throw new NotImplementedException();
    }
    public Ticket DeleteTicket(int ticketID)
    {
        return _ticket.DeleteTicket(ticketID) ?? throw new NotImplementedException();
    }
}
