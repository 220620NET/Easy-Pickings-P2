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
        public void PolicyCreationFailsWithInvalidUpdate()
        {
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            List<User> user = new();
            user.Add(new()
            {
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
            });

            Policy policy = new()
            {
                policyID = 2,
                insurance = 1,
                coverage = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            PolicyService policyService = new(mockedPolicy.Object,mockedUser.Object);
            Assert.Throws<InvalidResourceException>(() => policyService.CreatePolicy(policy));
        }

        [Fact]
        public void PolicyCreationFailsWithInvalidDelete()
        {
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            List<User> user = new();
            user.Add(new()
            {
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
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

           
            Policy policy = new()
            {
                policyID = 2,
                insurance = 1,
                coverage = "Test"
            };

            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            PolicyService policyService = new(mockedPolicy.Object, mockedUser.Object);
            Assert.Throws<InvalidPolicyException>(() => policyService.CreatePolicy(policy));
        }
        [Fact]
        public void PolicyCreationFailsWithInvalidUser()
        {
            var mockedPolicy = new Mock<IPolicy>();
            var mockedUser = new Mock<IUserRepo>();
            List<User> user = new();
            user.Add(new()
            {
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
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });
            Policy policy = new()
            {
                policyID = 2,
                insurance = 1,
                coverage = "Test"
            };

            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            PolicyService policyService = new(mockedPolicy.Object, mockedUser.Object);
            Assert.Throws<InvalidUserException>(() => policyService.CreatePolicy(policy));
        }
     }
        
 }
