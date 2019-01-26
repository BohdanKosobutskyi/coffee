using Coffee.DbEntities;
using Coffee.Filters.Exceptions;
using Coffee.Repositories.Interfaces;
using Coffee.Services;
using Coffee.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace Coffee.Test.Services
{
    public class AuthServiceTest
    {
        [Fact]
        public void RefreshTokenWithInvalidToken()
        {
            // Arrange
            var refreshToken = Guid.NewGuid().ToString();
            var expectedMessage = "Invalid refresh token.";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>();
            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();


            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);
           
            // Act
            // Assert
            var exception = Assert.Throws<InvalidRefreshTokenException>(() => authService.RefreshToken(refreshToken));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void RefreshTokenSuccess()
        {
            // Arrange
            var refreshToken = Guid.NewGuid().ToString();
            var mockUserRepository = new Mock<IUserRepository>();
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
            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var accessToken = "1234";
            mockSecurityService.Setup(repo => repo.GenerateToken(It.IsAny<User>())).Returns(accessToken);
            
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            var response = authService.RefreshToken(refreshToken);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.refresh_token);
            Assert.NotEmpty(response.access_token);
            Assert.Equal(response.access_token, accessToken);
            Assert.NotEmpty(response.expire_time.ToString());
            Assert.NotEqual(response.refresh_token, refreshToken);
            mockUserRepository.Verify(n => n.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void GetTokenWebSuccess()
        {
            // Arrange
            var email = "test";
            var password = "test";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockSellerList = new List<Seller>
            {
                new Seller
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    Email = "test",
                    Password = "test"
                }
            };
            mockSellerRepository.Setup(repo => repo.Get(It.IsAny<Func<Seller, bool>>())).Returns(mockSellerList);

            var mockIdentityService = new Mock<IIdentityService>();
            mockIdentityService.Setup(repo => repo.GetIdentity(It.IsAny<Seller>())).Returns(new ClaimsIdentity());

            var mockSecurityService = new Mock<ISecurityService>();
            var accessToken = "1234";
            mockSecurityService.Setup(repo => repo.GenerateToken(It.IsAny<Seller>())).Returns(accessToken);

            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            var response = authService.TokenWeb(email, password);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.refresh_token);
            Assert.NotEmpty(response.access_token);
            Assert.Equal(response.access_token, accessToken);
            Assert.NotEmpty(response.expire_time.ToString());
            mockSellerRepository.Verify(n => n.Update(It.IsAny<Seller>()), Times.Once);
        }

        [Fact]
        public void GetTokenWebFailed()
        {
            // Arrange
            var email = "test";
            var password = "test";
            var expectedMessage = "Invalid email or password.";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockSellerList = new List<Seller>();
            mockSellerRepository.Setup(repo => repo.Get(It.IsAny<Func<Seller, bool>>())).Returns(mockSellerList);

            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var accessToken = "1234";
            mockSecurityService.Setup(repo => repo.GenerateToken(It.IsAny<Seller>())).Returns(accessToken);

            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            // Assert
            var exception = Assert.Throws<InvalidCredentialsException>(() => authService.TokenWeb(email, password));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void GetTokenMobileSuccess()
        {
            // Arrange
            var phone = "test";
            var password = "test";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    Phone = "test",
                    Password = "test"
                }
            };
            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            
            var mockIdentityService = new Mock<IIdentityService>();
            mockIdentityService.Setup(repo => repo.GetIdentity(It.IsAny<User>())).Returns(new ClaimsIdentity());

            var mockSecurityService = new Mock<ISecurityService>();
            var accessToken = "1234";
            mockSecurityService.Setup(repo => repo.GenerateToken(It.IsAny<User>())).Returns(accessToken);

            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            var response = authService.TokenMobile(phone, password);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.refresh_token);
            Assert.NotEmpty(response.access_token);
            Assert.Equal(response.access_token, accessToken);
            Assert.NotEmpty(response.expire_time.ToString());
            mockUserRepository.Verify(n => n.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void GetTokenMobileFailed()
        {
            // Arrange
            var phone = "test";
            var password = "test";
            var expectedMessage = "Invalid phone or password.";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>();
            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);


            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var accessToken = "1234";
            mockSecurityService.Setup(repo => repo.GenerateToken(It.IsAny<User>())).Returns(accessToken);

            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            // Assert
            var exception = Assert.Throws<InvalidCredentialsException>(() => authService.TokenMobile(phone, password));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void RegistrationSuccessWithoutRemovingNotConfirmUser()
        {
            // Arrange
            string phone = "test";
            var mockUserRepository = new Mock<IUserRepository>();
            
            var mockEmptyUserList = new List<User>();

            
            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockEmptyUserList);
            mockUserRepository.Setup(repo => repo.GetNotConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockEmptyUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            authService.Registration(phone);

            //Assert
            mockUserRepository.Verify(n => n.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void RegistrationSuccessWithRemovingNotConfirmUser()
        {
            // Arrange
            string phone = "test";
            var mockUserRepository = new Mock<IUserRepository>();

            var mockEmptyUserList = new List<User>();
            var mockUserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Password = "test",
                    Phone = "test"
                }
            };
            
            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockEmptyUserList);
            mockUserRepository.Setup(repo => repo.GetNotConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            authService.Registration(phone);

            //Assert

            mockUserRepository.Verify(n => n.Remove(It.IsAny<User>()), Times.Once);
            mockUserRepository.Verify(n => n.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void RegistrationFailed()
        {
            // Arrange
            string phone = "test";
            var expectedMessage = "User with this phone already exist.";
            var mockUserRepository = new Mock<IUserRepository>();

            var mockEmptyUserList = new List<User>();
            var mockUserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Password = "test",
                    Phone = "test"
                }
            };

            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act
            //Assert
            
            var exception = Assert.Throws<InvalidCredentialsException>(() => authService.Registration(phone));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void ConfirmRegisterSuccess()
        {
            // Arrange
            string phone = "test";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Password = "test",
                    Phone = "test"
                }
            };

            mockUserRepository.Setup(repo => repo.GetNotConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act 
            authService.ConfirmRegister(phone);

            // Assert
            mockUserRepository.Verify(n => n.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void ConfirmRegisterFailed()
        {
            // Arrange
            string phone = "test";
            string expectedMessage = "User with this phone already confirm or incorect confirm parameters.";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>();

            mockUserRepository.Setup(repo => repo.GetNotConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act 
            // Assert
            var exception = Assert.Throws<InvalidCredentialsException>(() => authService.ConfirmRegister(phone));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void RecoverPasswordSuccess()
        {
            // Arrange
            string phone = "test";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Password = "test",
                    Phone = "test"
                }
            };

            mockUserRepository.Setup(repo => repo.GetConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act 
            authService.Password(phone);

            // Assert
            mockUserRepository.Verify(n => n.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void RecoverPasswordFailed()
        {
            // Arrange
            string phone = "test";
            var expectedMessage = "User with this phone not exist.";
            var mockUserRepository = new Mock<IUserRepository>();
            var mockUserList = new List<User>();

            mockUserRepository.Setup(repo => repo.GetNotConfirmUsers(It.IsAny<Func<User, bool>>())).Returns(mockUserList);

            var mockSellerRepository = new Mock<ISellerRepository>();
            var mockIdentityService = new Mock<IIdentityService>();
            var mockSecurityService = new Mock<ISecurityService>();
            var authService = new AuthService(mockUserRepository.Object, mockSecurityService.Object, mockSellerRepository.Object, mockIdentityService.Object);

            // Act 
            // Assert
            var exception = Assert.Throws<InvalidCredentialsException>(() => authService.Password(phone));
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
