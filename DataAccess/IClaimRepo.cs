using System.ComponentModel.DataAnnotations;
using NewModels;

namespace DataAccess; 

     public interface IClaimRepo
     {
          public List<Claim> GetAllClaims();
          public Claim CreateClaims(Claim claim);
          public Claim UpdateClaims(Claim claim);
          public Claim DeleteClaims(int ID);
          public Claim GetClaimById(int ID);
          public List<Claim> GetClaimByPatientID(int ID);
          public List<Claim> GetClaimByStatus(string status);
     }




