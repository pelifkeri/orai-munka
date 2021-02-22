using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Tests.TestData;
using WebServerEntityFramework.Validation;
using Xunit;

namespace WebServerEntityFramework.Tests.Validation
{
    public class UserValidatorTests
    {
        private readonly UserValidator _validator;

        public UserValidatorTests()
        {
            _validator = new UserValidator();
        }

        [Fact]
        public void ShouldSucceed_WhenValidDtoWasGiven()
        {
            // arrange
            var dto = Generator.GetUserDto();

            // act 
            var result = _validator.Validate(dto);
            
            // asser
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory]
        [ClassData(typeof(UserValidatorTestData))]
        public void ShouldFail_WhenInvalidDtoWasGiven(UserDto dto)
        {
            // act 
            var result = _validator.Validate(dto);
            
            // assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
