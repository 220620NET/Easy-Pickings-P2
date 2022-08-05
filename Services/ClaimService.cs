using DataAccess;
using NewModels;

namespace Services;

public class ClaimService
{
   private readonly IClaimRepo _repo;
   public ClaimService(IClaimRepo repo)
   {
       _repo = repo;
   }

   public List<Claim> GetAllClaims()
   {
      return _repo.GetAllClaims() ?? throw new NotImplementedException();
   }

   public Claim CreateClaims(Claim claim)
   {
       return _repo.CreateClaims(claim);
   }


   public Claim UpdateClaims(Claim claim)
   {
        return _repo.UpdateClaims(claim);
   }

   public Claim DeleteClaims(int ID)
   {
        return _repo.DeleteClaims(ID);
   }

   public Claim GetClaimById(int ID)
   {
        return _repo.GetClaimById(ID);
   }


   public List<Claim> GetClaimByPatientID(int ID)
   {
       return _repo.GetClaimByPatientID(ID);
   }

   // public List<Claim> GetClaimByStatus(string status);

   public List<Claim> GetClaimByStatus(string status)
   {
       return _repo.GetClaimByStatus(status);
   }
}



