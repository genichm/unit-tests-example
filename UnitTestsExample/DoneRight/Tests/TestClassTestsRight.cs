using Moq;
using UnitTests.DoneRight;
using Xunit;

namespace UnitTests.DoneRight.Tests
{
    public class TestClassTestsRight
    {
        [Fact]
        public void Sutructed_1_IfTheValueIsLowerThan4()
        {
            var expected = 0;

            var value = 1;

            var target = new Dependency();

            var actual = target.Subtract(value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public void Returned_Null_IfTheValueIsGreaterOrEqualTo4(int value)
        {
            var target = new Dependency();

            var actual = target.Subtract(value);

            Assert.Null(actual);
        }

        [Fact]
        public void EnsureTheFlow_SomeFunctionA_CalledIfReturnedValueLowerThan2()
        {
            var dependency = new Mock<IDependency>();

            dependency.Setup(x => x.ReturnValue(It.IsAny<int>())).Returns(1);

            dependency.Setup(x => x.Subtract(It.IsAny<int>())).Returns(1);

            var target = new ClassToTest(dependency.Object);

            var result = target.GetResult(It.IsAny<int>());

            dependency.Verify(x => x.SomeFunctionA(), Times.Once());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void EnsureTheFlow_SomeFunctionB_CalledIfReturnedValueGreaterOrEqualTo2(int value)
        {
            var dependency = new Mock<IDependency>();

            dependency.Setup(x => x.ReturnValue(It.IsAny<int>())).Returns(value);

            dependency.Setup(x => x.Subtract(It.IsAny<int>())).Returns(value);

            var target = new ClassToTest(dependency.Object);

            var result = target.GetResult(It.IsAny<int>());

            dependency.Verify(x => x.SomeFunctionB(), Times.Once());
        }
    }
}
