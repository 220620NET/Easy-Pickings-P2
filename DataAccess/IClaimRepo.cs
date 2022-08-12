using System.ComponentModel.DataAnnotations;
using NewModels;

namespace DataAccess; 

     public interface IClaimRepo
     {
          public List<Claim> GetAllClaims();
          public Claim CreateClaims(Claim claim);
          public Claim UpdateClaims(Claim claim);  //test  3 repos claim user policy
          public Claim DeleteClaims(int ID);  //test claimId
          public Claim GetClaimById(int ID);  // test
          public List<Claim> GetClaimByPatientID(int ID);  // test
          public List<Claim> GetClaimByStatus(string status);  // test
          public List<Claim> GetClaimByPolicyId(int ID);  // test 
     }




