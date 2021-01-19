using WinFormsUnitTesting;
using Xunit;

namespace UnitTest.OsszeadasTestCases
{
    public class OsszeadasTests
    {
        [Theory]
        [InlineData("2", "4", 6)]
        [InlineData("1", "3", 4)]
        [InlineData("2", "5", 7)]
        public void Osszeadas_HelyesEredmeny(string s1, string s2, int eredmeny)
        {
            // act
            var result = Matematika.Osszeadas(s1, s2);

            // assert
            Assert.Equal(eredmeny, result);
        }

        [Theory]
        [InlineData("2", null)]
        [InlineData(null, "2")]
        [InlineData("", "2")]
        [InlineData("2", "")]
        public void Osszeadas_ExceptiontDob(string s1, string s2)
        {
            // act + assert
            Assert.Throws<UresTextboxException>(() => Matematika.Osszeadas(s1, s2));
        }
    }
}
