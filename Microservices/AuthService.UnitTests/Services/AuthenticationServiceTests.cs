using AuthService.Authentication;
using AuthService.Connectors;
using AuthService.Models;
using AuthService.Services;
using FluentAssertions;
using Moq;

namespace AuthService.UnitTests.Services;
public class AuthenticationServiceTests
{
	private readonly Mock<IDatabaseConnector> _connectorMock;
	private readonly Mock<IJwtProvider> _jwtProviderMock;

	public AuthenticationServiceTests()
	{
		_connectorMock = new Mock<IDatabaseConnector>();
		_jwtProviderMock = new Mock<IJwtProvider>();
	}

	// Test name convention is [ThingUnderTest]_Should_[ExpectedResult]_[Conditions]
	[Fact]
	public async Task AuthenticateAsync_Should_ReturnNotSuccessfulResult_WhenUserIsNotInDatabase()
	{
		// Arrange
		var email = "email@test.com";
		var passwordHash = "testPassHash";

		_connectorMock.Setup(
			x => x.GetUserAsync(
				It.IsAny<string>()))
			.ReturnsAsync(new ResultObject<UserInfo>
			{
				Result = null,
				Error = new Exception("No user found"),
				IsSuccess = false,
			});

		var authService = new AuthenticationService(
			_connectorMock.Object,
			_jwtProviderMock.Object);

		// Act
		var result = await authService.AuthenticateAsync(email, passwordHash);

		// Assert
		result.IsSuccess.Should().BeFalse();
	}

	[Fact]
	public async Task AuthenticateAsync_Should_ReturnNotSuccessfulResult_WhenUserCredentialsAreInvalid()
	{
		// Arrange
		var email = "email@test.com";
		var passwordHash = "testPassHash";

		_connectorMock.Setup(
			x => x.GetUserAsync(
				It.IsAny<string>()))
			.ReturnsAsync(new ResultObject<UserInfo>()
			{
				Result = new UserInfo
				{
					PasswordHash = "notTheSamePassHash"
				},
				Error = null,
				IsSuccess = true,
			});

		var authService = new AuthenticationService(
			_connectorMock.Object,
			_jwtProviderMock.Object);

		// Act
		var result = await authService.AuthenticateAsync(email, passwordHash);

		// Assert
		result.IsSuccess.Should().BeFalse();
	}

	[Fact]
	public async Task AuthenticateAsync_Should_ReturnSuccessfulResult_WhenUserCredentialsAreValid()
	{
		// Arrange
		var email = "email@test.com";
		var passwordHash = "testPassHash";

		_connectorMock.Setup(
			x => x.GetUserAsync(
				It.IsAny<string>()))
			.ReturnsAsync(new ResultObject<UserInfo>()
			{
				Result = new UserInfo
				{
					PasswordHash = "testPassHash"
				},
				Error = null,
				IsSuccess = true,
			});

		var authService = new AuthenticationService(
			_connectorMock.Object,
			_jwtProviderMock.Object);

		// Act
		var result = await authService.AuthenticateAsync(email, passwordHash);

		// Assert
		result.IsSuccess.Should().BeTrue();
	}
}
