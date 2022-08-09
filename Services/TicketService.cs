using DataAccess;
using NewModels;
using CustomExceptions;

namespace Services;
public class TicketService
{
    private readonly ITicket _ticket;
    private readonly IPolicy _policy;
    private readonly IUserRepo _userRepo;
    private readonly IClaimRepo _claimRepo;
    public TicketService(ITicket ticket, IPolicy policy, IUserRepo userRepo, IClaimRepo claimRepo)
    {
        _ticket = ticket;
        _policy = policy;
        _userRepo = userRepo;
        _claimRepo = claimRepo;
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
        try
        {
            List<Claim> all = _claimRepo.GetAllClaims();
            bool there = true;
            foreach(Claim ticket in all)
            {
                if(claimID!= ticket.claimID)
                {
                    there = false;
                }
            }
            if (!there)
            {
                throw new InvalidClaimException();
            }
            return _ticket.GetTicketByClaim(claimID);
        }
        catch (InvalidClaimException)
        {
            throw new InvalidClaimException();
        }
        catch (NotImplementedException)
        {
            throw new InvalidClaimException();
        }
    }

    public List<Ticket> GetTicketByPolicy(int policyID)
    {
        try
        {
            List<Policy> all = _policy.GetAllPolicy();
            bool there = false;
            foreach (Policy ticket in all)
            {
                if (policyID == ticket.policyID)
                {
                    there = true;
                }
            }
            if (!there)
            {
                throw new InvalidPolicyException();
            }
            return _ticket.GetTicketByPolicy(policyID);
        }
        catch (InvalidPolicyException)
        {
            throw new InvalidPolicyException();
        }
        catch (NotImplementedException)
        {
            throw new InvalidPolicyException();
        }
    }
    /// <summary>
    /// Will return all tickets from a specific patient
    /// </summary>
    /// <param name="patientID">The patient in question</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException">There are no tickets related to that patient</exception>
    public List<Ticket> GetTicketByPatient(int patientID)
    {
        try
        {
            List<User> all = _userRepo.GetAllUsers();
            bool there = true;
            foreach (User ticket in all)
            {
                if (patientID != ticket.userID)
                {
                    there = false;
                }
            }
            if (!there)
            {
                throw new InvalidUserException();
            }
            return _ticket.GetTicketByPatient(patientID);
        }
        catch (InvalidUserException)
        {
            throw new InvalidUserException();
        }
        catch (NotImplementedException)
        {
            throw new InvalidUserException();
        }
    }
    /// <summary>
    /// Will create a ticket
    /// </summary>
    /// <param name="ticket">A valid ticket</param>
    /// <returns>The newly created ticket</returns>
    /// <exception cref="NotImplementedException">That ticket couldn't be created</exception>
    public Ticket CreateTicket(Ticket ticket)
    {
        try
        {
            List<Ticket> tickets = GetTicketByClaim(ticket.claimID);
            List<Ticket> ticketsP = GetTicketByPolicy(ticket.policyID);
            List<Ticket> ticketsU = GetTicketByPatient(ticket.userID);
            return _ticket.CreateTicket(ticket);
        }
        catch (InvalidClaimException)
        {
            throw new InvalidClaimException();
        }
        catch (InvalidPolicyException)
        {
            throw new InvalidPolicyException();
        }
        catch (InvalidUserException)
        {
            throw new InvalidUserException();
        }
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
    public Ticket GetTicketByID(int ticketId)
    {
        return _ticket.GetTicketByID(ticketId) ?? throw new NotImplementedException();
    }
}