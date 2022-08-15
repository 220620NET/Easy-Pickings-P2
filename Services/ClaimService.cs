using DataAccess;
using NewModels;
using CustomExceptions;

namespace Services;

public class ClaimService
{
   private readonly IClaimRepo _repo;
   private readonly IUserRepo _user;
   private readonly IPolicy _policy;


  public ClaimService(IClaimRepo repo) => _repo = repo;

  public ClaimService(IClaimRepo repo,IPolicy policy, IUserRepo user )
   {
       _repo = repo;
       _user = user;
       _policy = policy;
   }

   public List<Claim> GetAllClaims()
   {
      return _repo.GetAllClaims() ?? throw new NotImplementedException();
   }

   public Claim CreateClaims(Claim claim)
   {  
    try
   {
    GetClaimByPatientID(claim.userID);
    GetClaimByPolicyID(claim.policyID);
    return _repo.CreateClaims(claim);
   }
   catch (InvalidPolicyException)
   {
    
    throw new InvalidPolicyException();
   }
   catch(InvalidUserException)
   {
        throw new InvalidUserException();
   }
   }

   

   public Claim UpdateClaims(Claim claim)
   {
        return _repo.UpdateClaims(claim);
   }

   public Claim DeleteClaims(int ID)
   {
        Claim claim = GetClaimById(ID);
        _repo.DeleteClaims(ID);
        return claim;
    }

   public Claim GetClaimById(int ID)
   {
        return _repo.GetClaimById(ID);
   }


   public List<Claim> GetClaimByPatientID(int ID)
   {
      try
      {
        List<User> all = _user.GetAllUsers();
         bool something = true;
         foreach(User user in all)
         {
            if(user.userID != ID)
              something = false;
         }
         if(! something )
         throw new InvalidUserException();

        return _repo.GetClaimByPatientID(ID);
      }
      catch (InvalidUserException)
      {
        
        throw new InvalidUserException();
      }
      
   }
  
     public List<Claim> GetClaimByPolicyID(int ID)
   {
      try
      {
        List<Policy> all = _policy.GetAllPolicy();
         bool something = true;
         foreach(Policy policy in all)
         {
            if(policy.policyID != ID)
              something = false;
         }
         if(! something )
         throw new InvalidPolicyException();

        return _repo.GetClaimByPolicyId(ID);
      }
      catch (InvalidPolicyException)
      {
        
        throw new InvalidPolicyException();
      }
       
   }

   public List<Claim> GetClaimByStatus(string status)
   {
       return _repo.GetClaimByStatus(status);
   }
}



