using Moq;
using NewModels;
using Services;
using DataAccess;
using CustomExceptions;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Tests
{
    
   public class ClaimTesting
   {
       [Fact]
       public void CreateClaimFailsWithInvalidPolicyId()
       {
        
        var mockedClaim = new Mock<IClaimRepo>();
        var mockedUser = new Mock<IUserRepo>();
        var mockedPolicy = new Mock<IPolicy>();
        List<Claim> claim1 = new();

       claim1.Add(new()
       {
            claimID = 2,
            userID = 2,
            doctorID = 2,
            policyID = 44,
            reasonForVisit = "unrequited love, they left me for another",
            status = "Pending"
       });
          Claim claim = new()
       {
            claimID = 1,
            userID = 2,
            doctorID = 2,
            policyID = 43,
            reasonForVisit = "unrequited love, they left me for another",
            status = "Pending"
       };
    
       List<User> user = new List<User>();
       user.Add(new(){
            userID = 2,
            first_name = "Joanne",
            middle_init = 'T',
            last_name = "Scammer",
            username = "Micke",
            password = "1234",
            DoB = new DateTime(),
            role = "Employee"
       });
        List<Policy> policy = new List<Policy>();
        policy.Add(new(){
            policyID = 1,
            insurance = 3,
            coverage = "Test"

        });  // create a constructor in ClaimServices that takes three arguments
         mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim1);
         mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
         mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
        ClaimService claimService = new(mockedClaim.Object, mockedPolicy.Object, mockedUser.Object);  
        Assert.Throws<InvalidPolicyException>(() => claimService.CreateClaims(claim));
       }

       [Fact]
       public void ClaimFailsWithInvalidUser()
       {
      var mockedClaim = new Mock<IClaimRepo>();
        var mockedUser = new Mock<IUserRepo>();
        var mockedPolicy = new Mock<IPolicy>();
        List<Claim> claim1 = new();

       claim1.Add(new()
       {
            claimID = 2,
            userID = 2,
            doctorID = 2,
            policyID = 1,
            reasonForVisit = "unrequited love, they left me for another",
            status = "Pending"
       });
          Claim claim = new()
       {
            claimID = 2,
            userID = 21,
            doctorID = 2,
            policyID = 1,
            reasonForVisit = "unrequited love, they left me for another",
            status = "Pending"
       };
    
       List<User> user = new List<User>();
       user.Add(new(){
            userID = 2,
            first_name = "Joanne",
            middle_init = 'T',
            last_name = "Scammer",
            username = "Micke",
            password = "1234",
            DoB = new DateTime(),
            role = "Employee"
       });
        List<Policy> policy = new List<Policy>();
        policy.Add(new(){
            policyID = 1,
            insurance = 3,
            coverage = "Test"

        });  // create a constructor in ClaimServices that takes three arguments
         mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim1);
         mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
         mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
        ClaimService claimService = new(mockedClaim.Object, mockedPolicy.Object, mockedUser.Object);  
        Assert.Throws<InvalidUserException>(() => claimService.CreateClaims(claim));
       }

     
      



       }
   
   }


   











