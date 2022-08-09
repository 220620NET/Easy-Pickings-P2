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
        [Fact]
        public void CreationFailsWithInvalidClaim()
        {
            var mockedClaimRepo = new Mock<IClaimRepo>();
            var mockedPolicyRepo = new Mock<IPolicy>();
            var mockedUserRepo = new Mock<IUserRepo>();
            var mockedRepo = new Mock<ITicket>();
            User user = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = new DateTime(),
                role = "Patient"
            };
            Policy policy = new()
            {
                policyID = 1,
                insurance =3,
                coverage="Testing"
            };
            Claim claim = new()
            {

            };
            Ticket ticketToCreate = new()
            {

            };
        }
    }
}
