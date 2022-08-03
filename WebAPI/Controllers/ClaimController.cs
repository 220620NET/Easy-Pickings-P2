using Services;
using NewModels;
namespace WebAPI.Controllers;

public class ClaimController
{

   private readonly ClaimService _service;
   /// <summary>
   /// This connects to the database
   /// </summary>
   /// <param name="service"></param>
   public ClaimController(ClaimService service)
   {
    _service = service;
   }
   /// <summary>
   /// Get all Claims
   /// </summary>
   /// <returns>List of claims</returns>
    public List<Claim> GetAllClaims()
   {
    return _service.GetAllClaims();
   }
   /// <summary>
   /// Create a claim
   /// </summary>
   /// <param name="claim"></param>
   /// <returns>200 success</returns>
   public Claim CreateClaims(Claim claim)
   {
       return _service.CreateClaims(claim);
   }
   /// <summary>
   /// Update a claim
   /// </summary>
   /// <param name="claim"></param>
   /// <returns>202 with an updated claim</returns>
   public Claim UpdateClaims(Claim claim)
   {
        return _service.UpdateClaims(claim);
   }
   /// <summary>
   /// Delete a claim
   /// </summary>
   /// <param name="ID"></param>
   /// <returns>202 with a boolean verfication</returns>
   public bool DeleteClaims(int ID)
   {
     return _service.DeleteClaims(ID);
   }
   /// <summary>
   /// Get the claim by Id
   /// </summary>
   /// <param name="ID"></param>
   /// <returns>202 with claim id </returns>
   public Claim GetClaimById(int ID)
   {
    return _service.GetClaimById(ID);
   }
   /// <summary>
   /// get a user by ID
   /// </summary>
   /// <param name="ID"></param>
   /// <returns>Returns 202 with a list of user claims with given ID</returns>
   public List<Claim> GetUserByPatientId(int ID)
   {
       return _service.GetUserByPatientID(ID);
   }
/// <summary>
///  Get claims by status
/// </summary>
/// <param name="status"></param>
/// <returns>200 claim by status</returns>
   public List<Claim> GetClaimByStatus(string status)
   {
       return _service.GetClaimByStatus(status);
   }

}

   

