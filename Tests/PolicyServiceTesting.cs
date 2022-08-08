using Moq;
using NewModels;
using Services;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Tests
{
    public class PolicyServiceTesting
    {  
        [Fact]
        public void LoginWithValidpolicyID()
        {
            var mockedRepo = new Mock<IPolicy>();
            Policy policyToAdd = new()
            {
                policyID = 3,
                insurance= "Rockwell",
                coverage = "Full",
            };
            Policy policyToReturn = new()
            {
                policyID = 3,
                insurance= "Rockwell",
                coverage = "Full",
            };
            mockedRepo.Setup(repo => repo.GetUserByName(userToAdd.username,true)).Returns(userToReturn);
            PolicyService service = new(mockedRepo.Object);
            Assert.Throws<NotImplementedException>(() => service.Login(policyToAdd));
            mockedRepo.Verify(repo => repo.GetPolicyByID(policyToAdd.insurance,true)());
        }
        [Fact]
        public void Createcoverage()
        {
            var mockedRepo = new Mock<IPolicy>();
            Policy policyToAdd = new()
            {
                policyID = 3,
                insurance = "Rockwell",
            };
            Policy policyToReturn = new()
            {
                policyID = 3,
                 insurance = 250,
                coverage = "Full",
            };
            mockedRepo.Setup(repo => repo.GetPolicyBycoverage(policyToAdd.insurance,true)).Returns(policyToReturn);
            PolicyService service = new(mockedRepo.Object);
            Assert.Throws<NotImplementedException>(() => service.CreatePolicy(policyToAdd));
            mockedRepo.Verify(repo => repo.GetPolicyBycoverage(policyToAdd.insurance,true)());
        }
       
    }
 }
