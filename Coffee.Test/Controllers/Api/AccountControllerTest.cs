using Coffee.Controllers.Api;
using Coffee.Repositories.Interfaces;
using Coffee.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Coffee.Test.Controllers.Api
{
    public class AccountControllerTest
    {
        [Fact]
        public void RefreshTokenSuccess()
        {
            // Arrange

            var mockUserRepository = new Mock<IUserRepository>();
            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var refreshToken = Guid.NewGuid().ToString();

            var accountController = new AccountController(mockUserRepository.Object, mockSellerRepository.Object, mockIdentityService.Object, mockSecurityService.Object);

            // Act
            //var result = accountController.RefreshToken(refreshToken).;
            
        }
    }
}
