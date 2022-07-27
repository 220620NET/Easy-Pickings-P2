using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;

namespace DataAccess; 

     public interface IClaimRepo
     {
          public List<Claim> GetAllClaims();
          public Claim CreateClaims(Claim claim);
          public Claim UpdateClaims(Claim claim);
          public bool DeleteClaims(int ID);
          public Claim getClaimById(int ID);
          public List<Claim> getUserByPatientID(int ID);
          public List<Claim> getClaimByStatus(string status);
     }




