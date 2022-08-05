﻿using NewModels;
using Microsoft.EntityFrameworkCore;
using CustomExceptions;

namespace DataAccess; 
public class ClaimsRepo : IClaimRepo
{     
    private readonly InsuranceDbContext _context;
    public ClaimsRepo (InsuranceDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Will add a claim to the database
    /// </summary>
    /// <param name="claim">Claim to add to the table</param>
    /// <returns>Claim that was added</returns>
    public Claim CreateClaims(Claim claim)
    {   
        // EF core can tell which class it is, so it is unnecessary to specify which dbSet you want this object to be added
        _context.Claims.Add(claim);
        Finish();
        return claim; 
    }
    /// <summary>
    /// Will delete a specific claim
    /// </summary>
    /// <param name="Id">The claim to delete</param>
    /// <returns>True if deleted false if not</returns>
    public Claim DeleteClaims(int Id)
    {
        Claim? ClaimToDelete = _context.Claims.AsNoTracking().FirstOrDefault(c => c.claimID == Id)??throw new NotImplementedException();
        _context.Claims.Remove(ClaimToDelete);
        Finish();        
        return ClaimToDelete;
    }
    /// <summary>
    /// Will read the entire table of claims
    /// </summary>
    /// <returns>Will return a new list if the database is empty other wise will return the entire table as a list</returns>
    public List<Claim> GetAllClaims()
    {
    return _context.Claims.AsNoTracking().ToList()??new List<Claim>();
    }
    /// <summary>
    /// will retreive a claim based on the claim ID
    /// </summary>
    /// <param name="ID">The specific claim being requested</param>
    /// <returns>The requested claim</returns> 
    public Claim GetClaimById(int ID)
    {
    return _context.Claims.AsNoTracking().FirstOrDefault(c => c.claimID == ID)??throw new NotImplementedException();
    }
    /// <summary>
    /// will retreive all claims based on a particular status
    /// </summary>
    /// <param name="status">The status in question</param>
    /// <returns>A list of all claims with a specific status</returns> 
    public List<Claim> GetClaimByStatus(string status)
    {
    return _context.Claims.AsNoTracking().Where(c => c.status == status).ToList()??throw new NotImplementedException();
    }
    /// <summary>
    /// will retreive all claims based on a patient's id
    /// </summary>
    /// <param name="ID">The specific patient in question</param>
    /// <returns>All claims made by the patient</returns> 
    public List<Claim> GetClaimByPatientID(int ID)
    {
    return _context.Claims.AsNoTracking().Where(p => p.userID == ID).ToList()??throw new NotImplementedException(); 
    }
    /// <summary>
    /// This will update a claim based on provided input
    /// </summary>
    /// <param name="claim">claim to update and the specifics of the update</param>
    /// <returns>updated claim</returns>
    public Claim UpdateClaims(Claim claim)
    {
        //update the claim
        _context.Claims.Update(claim);
        Finish();
        return claim; 
    }
    protected void Finish()
    {
        _context.SaveChanges();
        //Clear the change tracker
        _context.ChangeTracker.Clear();
    }
}

 