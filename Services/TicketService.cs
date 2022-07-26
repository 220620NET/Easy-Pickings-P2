﻿using DataAccess;
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
    /// <exception cref="TicketNotAvailable">There are no tickets</exception>
    public List<Ticket> GetAllTickets()
    {
        return _ticket.GetAllTickets() ?? throw new TicketNotAvailableException();
    }
    /// <summary>
    /// Will return all tickets related to a particular claim
    /// </summary>
    /// <param name="claimID">The claim in question</param>
    /// <returns>A list of all related tickets</returns>
    /// <exception cref="InvalidClaimException">There are no tickets related to that claim</exception>
    /// <exception cref="TicketNotAvailable">There are no tickets</exception>
    public List<Ticket> GetTicketByClaim(int claimID)
    {
        try
        {
            List<Claim> all = _claimRepo.GetAllClaims();
            bool there = false;
            foreach(Claim ticket in all)
            {
                if(claimID == ticket.claimID)
                {
                    there = true;
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
        catch (NullReferenceException)
        {
            throw new TicketNotAvailableException();
        }
    }
    /// <summary>
    /// Will return all tickets related to a particular policy
    /// </summary>
    /// <param name="policyID">The policy beng requested</param>
    /// <returns>A list of all related tickets</returns>
    /// <exception cref="InvalidPolicyException">There are no tickets related to that policty</exception>
    /// <exception cref="TicketNotAvailable">There are no tickets</exception>
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
        catch (NullReferenceException)
        {
            throw new TicketNotAvailableException();
        }
    }
    /// <summary>
    /// Will return all tickets from a specific patient
    /// </summary>
    /// <param name="patientID">The patient in question</param>
    /// <returns></returns>
    /// <exception cref="InvalidUserException">There are no tickets related to that patient</exception>
    /// <exception cref="TicketNotAvailableException">There are no tickets</exception>
    public List<Ticket> GetTicketByPatient(int patientID)
    {
        try
        {
            List<User> all = _userRepo.GetAllUsers();
            bool there = false;
            foreach (User ticket in all)
            {
                if (patientID == ticket.userID)
                {
                    there = true;
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
        catch (NullReferenceException)
        {
            throw new TicketNotAvailableException();
        }
    }
    /// <summary>
    /// Will read a ticket
    /// </summary>
    /// <param name="ticketId">The specific ticket requested</param>
    /// <returns>The ticket requested</returns>
    /// <exception cref="TicketNotAvailable">There is no ticket with that ID</exception>
    public Ticket GetTicketByID(int ticketId)
    {
        try
        {
            List<Ticket> all = _ticket.GetAllTickets();
            bool there = false;
            foreach (Ticket ticket in all)
            {
                if (ticketId == ticket.ticketID)
                {
                    there = true;
                }
            }
            if (!there)
            {
                throw new TicketNotAvailableException();
            }
            return _ticket.GetTicketByID(ticketId);
        }
        catch (TicketNotAvailableException)
        {
            throw new TicketNotAvailableException();
        } 
         
    }
    /// <summary>
    /// Will create a ticket
    /// </summary>
    /// <param name="ticket">A valid ticket</param>
    /// <returns>The newly created ticket</returns>
    /// <exception cref="InvalidClaimException">That claim does not exist yet</exception>
    /// <exception cref="InvalidUserException">That user does not exist yet</exception>
    /// <exception cref="InvalidPolicyException">That policy does not exist yet</exception>
    public Ticket CreateTicket(Ticket ticket)
    {
        try
        {
            GetTicketByClaim(ticket.claimID);
            GetTicketByPolicy(ticket.policyID);
            GetTicketByPatient(ticket.userID);
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
        catch (TicketNotAvailableException)
        {
            return _ticket.CreateTicket(ticket);
        }
    }
    /// <summary>
    /// Will update a ticket
    /// </summary>
    /// <param name="ticket">A valid ticket with the information to update</param>
    /// <returns>The updated ticket</returns>
    /// <exception cref="InvalidClaimException">That claim does not exist yet</exception>
    /// <exception cref="InvalidUserException">That user does not exist yet</exception>
    /// <exception cref="InvalidPolicyException">That policy does not exist yet</exception>
    /// <exception cref="TicketNotAvailableException">That ticket does not exist</exception>
    public Ticket UpdateTicket(Ticket ticket)
    {
        try
        {
            GetTicketByClaim(ticket.claimID);
            GetTicketByPolicy(ticket.policyID);
            GetTicketByPatient(ticket.userID);
            GetTicketByID(ticket.ticketID);
            return _ticket.UpdateTicket(ticket);
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
        catch (TicketNotAvailableException)
        {
            throw new TicketNotAvailableException();
        }
    }
    /// <summary>
    /// Will delete a ticket
    /// </summary>
    /// <param name="ticketID">A valid Ticket Id</param>
    /// <returns>The ticket that was deleted</returns>
    /// <exception cref="TicketNotAvailableException">That ticket doesn't exist</exception>
    public Ticket DeleteTicket(int ticketID)
    {
        try
        {
            Ticket ticket = GetTicketByID(ticketID);
             _ticket.DeleteTicket(ticketID);
            return ticket;
        }
        catch (TicketNotAvailableException)
        {
            throw new TicketNotAvailableException();
        }
    }
}