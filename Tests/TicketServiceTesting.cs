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
    public class TicketServiceTesting
    {
        /*
         *      CreateTicket() Testing
         */
        [Fact]
        public void TicketCreationFailsWithInvalidClaim()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 2,
                policyID = 1,
                claimID = 2,
                userID = 2,
                details = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<InvalidClaimException>(() => ticketService.CreateTicket(ticket));
        }

        [Fact]
        public void TicketCreationFailsWithInvalidPolicy()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 2,
                policyID = 2,
                claimID = 1,
                userID = 2,
                details = "Test"
            };

            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<InvalidPolicyException>(() => ticketService.CreateTicket(ticket));
        }
        [Fact]
        public void TicketCreationFailsWithInvalidUser()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 2,
                policyID = 1,
                claimID = 1,
                userID = 1,
                details = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<InvalidUserException>(() => ticketService.CreateTicket(ticket));
        }

        /*      
         *      UpdateTicket() Testing
         */
        [Fact]
        public void TicketUpdateFailsWithNonExistentTicket()
        {

            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 2,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<TicketNotAvailable>(() => ticketService.UpdateTicket(ticket));
        }
        [Fact]
        public void TicketUpdateFailsWithInvalidClaim()
        {

            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 2,
                userID = 2,
                details = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<InvalidClaimException>(() => ticketService.UpdateTicket(ticket));
        }
        [Fact]
        public void TicketUpdateFailsWithInvalidPolicy()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 1,
                policyID = 2,
                claimID = 1,
                userID = 2,
                details = "Test"
            };

            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<InvalidPolicyException>(() => ticketService.UpdateTicket(ticket));
        }
        [Fact]
        public void TicketUpdateFailsWithInvalidUser()
        {

            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 1,
                details = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<InvalidUserException>(() => ticketService.UpdateTicket(ticket));
        }

        /*
         *      DeleteTicket() Testing
         */
        [Fact]
        public void TicketDeleteFailsWithNonExistentTicket()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
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
            List<Claim> claim = new();
            claim.Add(new()
            {
                claimID = 1,
                userID = 2,
                doctorID = 1,
                policyID = 1,
                reasonForVisit = "Test"
            });
            List<Policy> policy = new List<Policy>();
            policy.Add(new()
            {
                policyID = 1,
                insurance = 3,
                coverage = "Test"
            });

            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 2,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            };
            mockedUser.Setup(r => r.GetAllUsers()).Returns(user);
            mockedClaim.Setup(r => r.GetAllClaims()).Returns(claim);
            mockedPolicy.Setup(r => r.GetAllPolicy()).Returns(policy);
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<TicketNotAvailable>(() => ticketService.DeleteTicket(ticket.ticketID));
        }
        /*
         *      GetTickets Testing
         */

        [Fact]
        public void GetTicketByIDFailsWithNonExistentTicket()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 2,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            };
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<TicketNotAvailable>(() => ticketService.GetTicketByID(ticket.ticketID));
        }
        [Fact]
        public void GetTicketByPatientFailsWithNonExistentPatient()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 1,
                details = "Test"
            };
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<TicketNotAvailable>(() => ticketService.GetTicketByPatient(ticket.userID));
        }

        [Fact]
        public void GetTicketByPolicyFailsWithNonExistentPolicy()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 1,
                policyID = 2,
                claimID = 1,
                userID = 2,
                details = "Test"
            };
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<TicketNotAvailable>(() => ticketService.GetTicketByPolicy(ticket.policyID));
        }

        [Fact]
        public void GetTicketByClaimFailsWithNonExistentClaim()
        {
            var mockedTicket = new Mock<ITicket>();
            var mockedUser = new Mock<IUserRepo>();
            var mockedPolicy = new Mock<IPolicy>();
            var mockedClaim = new Mock<IClaimRepo>();
            List<Ticket> ticket1 = new();
            ticket1.Add(new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 1,
                userID = 2,
                details = "Test"
            });
            Ticket ticket = new()
            {
                ticketID = 1,
                policyID = 1,
                claimID = 2,
                userID = 2,
                details = "Test"
            };
            mockedTicket.Setup(r => r.GetAllTickets()).Returns(ticket1);
            TicketService ticketService = new(mockedTicket.Object, mockedPolicy.Object, mockedUser.Object, mockedClaim.Object);
            Assert.Throws<TicketNotAvailable>(() => ticketService.GetTicketByClaim(ticket.claimID));
        }
    }
}