using Moq;
using NewModels;
using Services;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Tests
{
    
   public class ClaimTesting
   {
       [Fact]
       public void CreateClaimFailsWithInvalidPolicyID()
       {
        
        var mockedRepo = new Mock<IClaimRepo>();
        Claim claimToAdd = new()
       {
                claimID = 2,
                userID = 232,
                doctorID = 34,
                policyID = 44,
                reasonForVisit = "unrequited love, they left me for another",
                status = "Pending"
       };

          Claim claimToReturn = new()
            {
                claimID = 2,
                userID = 232,
                doctorID = 34,  //different
                policyID = 88,  //different
                reasonForVisit = "unrequited love, they left me for another",
                status = "Pending"
            };
            mockedRepo.Setup(r => r.CreateClaims(claimToAdd)).Returns(claimToAdd);
            ClaimService claimService = new (mockedRepo.Object);
            Assert.Throws<NotImplementedException>(() => claimService.CreateClaims(claimToReturn));
       }
   
   }


   
}










