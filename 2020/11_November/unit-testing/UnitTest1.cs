using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void SimaTest()
        {
            // arrange
            var tomb = new int[] { 1, 2, 3 };

            // act
            var result = Kata.GetAverage(tomb);

            // assert
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2)]
        [InlineData(new int[] { 2, 3, 4 }, 3)]
        [InlineData(new int[] { 3, 4, 5 }, 4)]
        public void Test(int[] szamok, int eredmeny)
        {
            Assert.Equal(eredmeny, Kata.GetAverage(szamok));
        }
    }
}
