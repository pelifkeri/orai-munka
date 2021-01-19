using System;
using WinFormsUnitTesting;
using Xunit;

namespace UnitTest.Form1TestCases
{
    public class Form1Tests
    {
        Form1 f1;

        public Form1Tests()
        {
            f1 = new Form1();
        }

        [Fact]
        public void OsszeadasTest()
        {
            // arrange
            f1.textBox1.Text = "2";
            f1.textBox2.Text = "3";
            object o = new object();
            EventArgs ea = new EventArgs();

            // act
            f1.button1_Click(o, ea);

            // assert
            Assert.Equal("5", f1.label1.Text);
        }

        [Fact]
        public void OsszeadasTest_ExceptiontDob()
        {
            // arrange
            f1.textBox1.Text = "2";
            object o = new object();
            EventArgs ea = new EventArgs();

            // act
            f1.button1_Click(o, ea);

            // assert
            //Assert.Throws<UresTextboxException>(() => f1.button1_Click(o, ea));
            Assert.Contains("Hiba", f1.label1.Text);
            Assert.False(string.IsNullOrEmpty(f1.label1.Text));
            Assert.True(!string.IsNullOrEmpty(f1.label1.Text));
        }
    }
}
