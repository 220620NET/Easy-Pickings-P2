using Services;
using DataAccess.Entities;
using DataAccess;

namespace WebAPI.Controllers;

public class ClaimController
{

   private readonly ClaimService _service;
   public ClaimController(ClaimService service)
   {
    _service = service;
   }

    public List<Claim> GetAllClaims()
   {
    return _service.GetAllClaims();
   }

   public Claim CreateClaims(Claim claim)
   {
       return _service.CreateClaims(claim);
   }

   public Claim UpdateClaims(Claim claim)
   {
        return _service.UpdateClaims(claim);
   }

   public bool DeleteClaims(int ID)
   {
     return _service.DeleteClaims(ID);
   }

   public Claim GetClaimById(int ID)
   {
    return _service.GetClaimById(ID);
   }
   public List<Claim> GetUserByPatientId(int ID)
   {
       return _service.GetUserByPatientID(ID);
   }

   public List<Claim> GetClaimByStatus(string status)
   {
       return _service.GetClaimByStatus(status);
   }

}

   

