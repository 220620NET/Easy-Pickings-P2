using Moq;
using NewModels;
using Services;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;
namespace Tests
{
    public class AuthServiceTesting
    {
        [Fact]
        public void LoginFailsWithInvalidPassword()
        {
            var mockedRepo = new Mock<IUserRepo>();
            User userToAdd = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = new DateTime(),
                role = "Employee"
            };
            User userToReturn = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "5",
                DoB = new DateTime(),
                role = "Employee"
            };
            mockedRepo.Setup(r => r.GetUserByName(userToAdd.username, false)).Returns(userToAdd);
            AuthService authService = new(mockedRepo.Object);
            Assert.Throws<NotImplementedException>(() => authService.Login(userToReturn.username,userToReturn.password));
        }
        [Fact]
        public void LoginFailsWithInvalidUsername()
        {
            var mockedRepo = new Mock<IUserRepo>();
            User userToAdd = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = new DateTime(),
                role = "Employee"
            };
            User userToReturn = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "School",
                password = "1234",
                DoB = new DateTime(),
                role = "Employee"
            };
            mockedRepo.Setup(r => r.GetUserByName(userToAdd.username, false)).Returns(userToAdd);
            AuthService authService = new(mockedRepo.Object);
            Assert.Throws<NullReferenceException>(() => authService.Login(userToReturn.username, userToReturn.password));
        }
        [Fact]
        public void RegisterFailsWithDuplicateUserName()
        {
            var mockedRepo = new Mock<IUserRepo>();
            User userToAdd = new()
            { 
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = new DateTime(),
                role = "Employee"
            };
            User userToReturn = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = new DateTime(),
                role = "Employee"
            };
            mockedRepo.Setup(repo => repo.GetUserByName(userToAdd.username,true)).Returns(userToReturn);
            AuthService service = new(mockedRepo.Object);
            Assert.Throws<NotImplementedException>(() => service.Register(userToAdd));
            mockedRepo.Verify(repo => repo.GetUserByName(userToAdd.username,true), Times.Once());
        }
        [Fact]
        public void RegisterFailsWithImproperInformation()
        {
            var mockedRepo = new Mock<IUserRepo>();
            User userToAdd = new()
            {
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                DoB = new DateTime(),
                role = "Employee"
            };
            User userToReturn = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = new DateTime(),
                role = "Employee"
            };
            mockedRepo.Setup(repo => repo.GetUserByName(userToAdd.username, true)).Returns(new User());
            AuthService service = new(mockedRepo.Object);
            Assert.Throws<NotImplementedException>(() => service.Register(userToAdd));
        }
    }
}