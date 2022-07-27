using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using CustomExceptions;


namespace DataAccess;



public class ClaimsRepo : IClaimRepo
{
     
    private readonly easypickingsContext _context;

    public ClaimsRepo (easypickingsContext context)
    {
        _context = context;
    }
  public Claim CreateClaims(Claim claim)
  {   
    // EF core can tell which class it is, so it is unnecessary to specify which dbSet you want this object to be added
   _context.Add(claim);
   _context.SaveChanges();

   //Clear the change tracker
   _context.ChangeTracker.Clear();
   return claim;


  }

  public bool DeleteClaims(int Id)
  {
      Claim? ClaimToDelete = _context.Claims.AsNoTracking().FirstOrDefault(c => c.ClaimId == Id);
      if(ClaimToDelete != null)
      {
        _context.Claims.Remove(ClaimToDelete);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return true;
      }
      return false;
  }

  public List<Claim> GetAllClaims()
  {
    return _context.Claims.AsNoTracking().ToList();
  }

  public Claim getClaimById(int ID)
  {
    return _context.Claims.AsNoTracking().FirstOrDefault(c => c.ClaimId == ID);
  }

  public List<Claim> getClaimByStatus(string status)
  {
    return _context.Claims.AsNoTracking().Where(c => c.Status == status).ToList();
  }

  public List<Claim> getUserByPatientID(int ID)                                  // user is the patient?
  {
    return _context.Claims.AsNoTracking().Where(p => p.ClaimId == ID).ToList();  // claims only has user id or doctor id 
  }

  public Claim UpdateClaims(Claim claim)
  {
      //update the claim
        _context.Claims.Update(claim);
        _context.SaveChanges();

   //Clear the change tracker
       _context.ChangeTracker.Clear();
        return claim;

  }
}

 