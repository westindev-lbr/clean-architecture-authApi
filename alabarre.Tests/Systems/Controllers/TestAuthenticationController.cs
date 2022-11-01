using System.Diagnostics;
using alabarre.Api.Controllers;
using alabarre.Contracts.Authentication;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace alabarre.Tests.Systems.Controllers;


public class TestAuthenticationController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {   
        // Arrange
        var sut = new AuthController();

        // Act 
        // invocation de la méthode Get avec un cast en OkObjectResult de (Microsoft.AspNetCore.Mvc)
        var result = (OkObjectResult)await sut.Get();

        // Assert 
        // StatusCode est un attribut d'un objet OkObjectResult 
        // Should() est une méthode de FluentAssertions
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_Login()
    {   
        // Arrange
        var sut = new AuthController();
        
        string email = "toto@mail.fr";
        string studentNum = "20006281";
        string passwd = "toto";
 
        var req = new LoginRequest(email,studentNum,passwd);
        // Act 
        // invocation de la méthode Get avec un cast en OkObjectResult de (Microsoft.AspNetCore.Mvc)
        var result = sut.Login(req);

        // Assert 
        // Should() est une méthode de FluentAssertions
        result.Equals(req);
    }

    /* [Fact]
    public async Task Get_OnSuccess_InvokesUserService(){
        var mockUserService = Mock<IUserService>();
        var sut = new AuthController(mockUserService.Object);
        var result = sut.Get(); 
    } */

}