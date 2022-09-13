using Moq;
using NewModels;
using Services;
using CustomExceptions;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;
namespace Tests
{
    public class ClaimsDaoTesting
    {
        [Fact]
        public void GetAllClaimsReturnsAnEmptyListForEmptyDB()
        {
            var moqDB = new Mock<InsuranceDbContext>();
            IClaimRepo cr = new ClaimsRepo(moqDB.Object); 
            Assert.Throws<NullReferenceException>(()=>cr.GetAllClaims( ));
        }

       
    }
}
