using Coffee.Controllers.Api;
using Coffee.DbEntities;
using Coffee.Filters.Exceptions;
using Coffee.Repositories.Interfaces;
using Coffee.Services.Interfaces;
using Coffee.DbEntities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Coffee.Test.Controllers.Api
{
    public class AccountControllerTest
    {
        [Fact]
        public async Task RefreshTokenWithInvalidToken()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var refreshToken = Guid.NewGuid().ToString();

            //var accountController = new AccountController(mockUserRepository.Object, mockSellerRepository.Object, mockIdentityService.Object, mockSecurityService.Object);

            // Act
            // Assert
            //await Assert.ThrowsAsync<InvalidRefreshTokenException>(() => accountController.RefreshToken(refreshToken));

        }

        [Fact]
        public async Task RefreshTokenWithCorrectToken()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var refreshToken = Guid.NewGuid().ToString();
            var mockUserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    IsConfirm = true,
                    Password = "test",
                    Phone = "123456789",
                    RefreshToken = refreshToken
                }
            };
            mockUserRepository.Setup(repo => repo.Get(It.IsAny<Func<User,bool>>())).Returns(mockUserList);
            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            //var accountController = new AccountController(mockUserRepository.Object,mockSellerRepository.Object,mockIdentityService.Object,mockSecurityService.Object);

            // Act
            //await accountController.RefreshToken(refreshToken);
            // Assert

        }
    }
}
