using NewModels;
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
        Claim? ClaimToDelete = _context.claims.AsNoTracking().FirstOrDefault(c => c.claimID == Id);
        if(ClaimToDelete != null)
        {
        _context.claims.Remove(ClaimToDelete);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return true;
        }
        return false;
    }

    public List<Claim> GetAllClaims()
    {
    return _context.claims.AsNoTracking().ToList();
    }

    public Claim GetClaimById(int ID)
    {
    return _context.claims.AsNoTracking().FirstOrDefault(c => c.claimID == ID)??throw new NotImplementedException();
    }

  public List<Claim> GetClaimByStatus(string status)
  {
    return _context.claims.AsNoTracking().Where(c => c.status == status).ToList();
  }

  public List<Claim> GetUserByPatientID(int ID)                                  // user is the patient?
  {
    return _context.claims.AsNoTracking().Where(p => p.userID == ID).ToList();  // claims only has user id or doctor id 
  }

  public Claim UpdateClaims(Claim claim)
  {
      //update the claim
        _context.claims.Update(claim);
        _context.SaveChanges();

   //Clear the change tracker
       _context.ChangeTracker.Clear();
        return claim;

  }
}

 