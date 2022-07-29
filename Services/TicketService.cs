using DataAccess;
using NewModels;

namespace Services;
public class TicketService
{
    private readonly ITicket _ticket;
    public TicketService(ITicket ticket)
    {
        _ticket = ticket;
    }
    /// <summary>
    /// Will grab all tickets
    /// </summary>
    /// <returns>All tickets</returns>
    /// <exception cref="NotImplementedException">There are no tickets</exception>
    public List<Ticket> GetAllTickets()
    {
        return _ticket.GetAllTickets() ?? throw new NotImplementedException();
    }
    /// <summary>
    /// Will return all tickets related to a particular claim
    /// </summary>
    /// <param name="claimID">The claim in question</param>
    /// <returns>A list of all related tickets</returns>
    /// <exception cref="NotImplementedException">There are no tickets related to that claim</exception>
    public List<Ticket> GetTicketByClaim(int claimID)
    {
        return _ticket.GetTicketByClaim(claimID) ?? throw new NotImplementedException();
    }
    /// <summary>
    /// Will return all tickets from a specific patient
    /// </summary>
    /// <param name="patientID">The patient in question</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException">There are no tickets related to that patient</exception>
    public List<Ticket> GetTicketByPatient(int patientID)
    {
        return _ticket.GetTicketByPatient(patientID) ?? throw new NotImplementedException();
    }
    /// <summary>
    /// Will create a ticket
    /// </summary>
    /// <param name="ticket">A valid ticket</param>
    /// <returns>The newly created ticket</returns>
    /// <exception cref="NotImplementedException">That ticket couldn't be created</exception>
    public Ticket CreateTicket(Ticket ticket)
    {
        return _ticket.CreateTicket(ticket) ?? throw new NotImplementedException();
    }
    /// <summary>
    /// Will update a ticket
    /// </summary>
    /// <param name="ticket">A valid ticket with the information to update</param>
    /// <returns>The updated ticket</returns>
    /// <exception cref="NotImplementedException">That ticket could not be updated</exception>
    public Ticket UpdateTicket(Ticket ticket)
    {
        return _ticket.UpdateTicket(ticket) ?? throw new NotImplementedException();
    }
    /// <summary>
    /// Will delete a ticket
    /// </summary>
    /// <param name="ticketID">A valid Ticket Id</param>
    /// <returns>The ticket that was deleted</returns>
    /// <exception cref="NotImplementedException">That ticket doesn't exist</exception>
    public Ticket DeleteTicket(int ticketID)
    {
        return _ticket.DeleteTicket(ticketID) ?? throw new NotImplementedException();
    }
}