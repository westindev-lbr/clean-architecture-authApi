using System.Diagnostics;
using alabarre.Api.Controllers;
using alabarre.Application.Services.Authentication;
using alabarre.Contracts.Authentication;
using alabarre.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace alabarre.Tests.Systems.Controllers;


public class TestAuthenticationController
{

    private readonly User _user = new User{
            FirstName = "John",
            LastName = "Doe",
            Email = "toto@mail.fr",
            StudentNum = 20006281,
            Password = "toto93",
            Salt = "salt",
            DateCreation = DateTime.UtcNow
        };

    
    [Fact(DisplayName = "Controller - Login retourne une AuthResponse")]
    public async Task Get_OnSuccess_InvokesAuthServiceLogin(){

        var user = new User(){};
        var mockUserService = new Mock<IAuthService>();
        mockUserService
            .Setup(service => service.Login( "toto@mail.fr", "toto"))
            .Returns(new AuthResult(_user, "token"));
        
        var sut = new AuthController(mockUserService.Object);

        var req = new LoginRequest("toto@mail.fr", 20006281, "toto");
        var result = sut.Login(req); 
        
        result.Should().BeOfType<OkObjectResult>();
        
        var objectResult = (OkObjectResult)result;
        Console.WriteLine(objectResult.Value);
        objectResult.Value.Should().BeOfType<AuthResponse>();
    }

}