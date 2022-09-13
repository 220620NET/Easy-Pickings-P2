using System.ComponentModel.DataAnnotations;
using NewModels;

namespace DataAccess; 

     public interface IClaimRepo
     {
          List<Claim> GetAllClaims();
          Claim CreateClaims(Claim claim);
          Claim UpdateClaims(Claim claim);
          Claim DeleteClaims(int ID);
          Claim GetClaimById(int ID);
          List<Claim> GetClaimByPatientID(int ID);
          List<Claim> GetClaimByStatus(string status);
     }




