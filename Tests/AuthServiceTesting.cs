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
                DoB = "9/19/1999",
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
                DoB = "9/19/1999",
                role = "Employee"
            };
            mockedRepo.Setup(r => r.GetUserByName(userToAdd.username, false)).Returns(userToAdd);
            AuthService authService = new(mockedRepo.Object);
            Assert.Throws<InvalidCredentialsException>(() => authService.Login(userToReturn.username,userToReturn.password));
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
                DoB = "9/19/1999",
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
                DoB = "9/19/1999",
                role = "Employee"
            };
            mockedRepo.Setup(r => r.GetUserByName(userToAdd.username, false)).Returns(userToAdd);
            AuthService authService = new(mockedRepo.Object);
            Assert.Throws<InputInvalidException>(() => authService.Login(userToReturn.username, userToReturn.password));
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
                DoB = "9/19/1999",
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
                DoB = "9/19/1999",
                role = "Employee"
            };
            mockedRepo.Setup(repo => repo.GetUserByName(userToReturn.username,true)).Returns(userToReturn);
            AuthService service = new(mockedRepo.Object);
            Assert.Throws<DuplicateRecordException>(() => service.Register(userToAdd));
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
                DoB = "9/19/1999",
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
                DoB = "9/19/1999",
                role = "Employee"
            };
            mockedRepo.Setup(repo => repo.GetUserByName(userToAdd.username, true)).Returns(new User());
            AuthService service = new(mockedRepo.Object);
            Assert.Throws<InputInvalidException>(() => service.Register(userToAdd));
        }

        [Fact]
        public void ResetFailsWithInvalidInfo()
        {
            var mockedRepo = new Mock<IUserRepo>();
            User userToAdd = new()
            {
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "1234",
                DoB = "9/19/1999",
                role = "Employee"
            };
            User userToReturn = new()
            {
                userID = 2,
                first_name = "Joanne",
                middle_init = 'T',
                last_name = "Scammer",
                username = "Micke",
                password = "2",
                DoB = "9/19/1999",
                role = "Employee"
            };
            mockedRepo.Setup(repo => repo.GetUserByName(userToReturn.username, false)).Returns(userToReturn);
            AuthService service = new(mockedRepo.Object);
            Assert.Throws<InputInvalidException>(() => service.ResetPassword(userToAdd));
        }
    }
}