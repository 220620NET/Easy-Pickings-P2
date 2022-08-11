using Moq;
using NewModels;
using Services;
using DataAccess;
using CustomExceptions;
using System;
using Xunit;
using System.Threading.Tasks;



namespace Tests;

public class UserServiceTesting
{
	[Fact]		
	public void DeleteUserFailsWithNonExistantUser()
    {
		var mockedUser = new Mock<IUserRepo>();

			List<User> users = new();
			users.Add(new()

				{
					userID = 1,
					first_name = "Janet",
					middle_init = 'L',
					last_name = "Ruger",
					username = "jrug",
					password = "1234",
					DoB = new DateTime(),
					role = "Doctor"
				});

				User user = new()

				{
					userID = 2,
					first_name = "Hector",
					middle_init = 'K',
					last_name = "Blue",
					username = "hblue",
					password = "1234",
					DoB = new DateTime(),
					role = "Patient"
				};
		
		mockedUser.Setup(repo => repo.GetAllUsers()).Returns(users);

		UserService userService = new (mockedUser.Object);

		//Act
		Assert.Throws<UserNotFound>(() => userService.DeleteUser(user.userID));

	}
}
