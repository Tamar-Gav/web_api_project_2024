using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Repository.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject;


public class UserUnitTest
{
    [Fact]
    public async Task TestLogin_Successful()
    {
        // Arrange
        var mockUserContext = new Mock<Product326075108Context>();
        var users = new List<User>
        {
            new User { Email = "testuser@gmail.com", Password = "password" }
        };

        mockUserContext.Setup(x => x.Users).ReturnsDbSet(users);

        var userRepository = new UserRepository(mockUserContext.Object);

        // Act
        var user = await userRepository.Login("testuser@gmail.com", "password");

        // Assert
        Assert.NotNull(user);
        Assert.Equal("testuser@gmail.com", user.Email);
    }

    [Fact]
    public async Task TestLogin_Failed()
    {
        // Arrange
        var mockUserContext = new Mock<Product326075108Context>();
        var users = new List<User>
    {
        new User { Email = "testuser", Password = "password" }
    };

        mockUserContext.Setup(x => x.Users).ReturnsDbSet(users);

        var userService = new UserRepository(mockUserContext.Object);

        // Act
        var user = await userService.Login( "testuser", "wrongpassword" );

        // Assert
        Assert.Null(user);
    }




}
