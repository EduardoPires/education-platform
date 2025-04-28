using Xunit;
using Moq;
using Microsoft.AspNetCore.Identity;
using EducationPlatform.Infrastructure.Identity;
using EducationPlatform.Api.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace EducationPlatform.Tests.Api
{
    public class AuthControllerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userClaimsPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            var options = new Mock<IOptions<IdentityOptions>>();
            var logger = new Mock<ILogger<SignInManager<ApplicationUser>>>();
            var schemes = new Mock<IAuthenticationSchemeProvider>();
            var confirmation = new Mock<IUserConfirmation<ApplicationUser>>();

            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object,
                contextAccessor.Object,
                userClaimsPrincipalFactory.Object,
                options.Object,
                logger.Object,
                schemes.Object,
                confirmation.Object
            );

            _configurationMock = new Mock<IConfiguration>();

            _controller = new AuthController(_userManagerMock.Object, _signInManagerMock.Object, _configurationMock.Object);
        }

        [Fact]
        public async Task Login_Deve_Retornar_Unauthorized_Se_Usuario_Nao_Encontrado()
        {
            // Arrange
            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _controller.Login("email@email.com", "senha123");

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
