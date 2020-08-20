using Moq;
using Xunit;

namespace UnitTests.DoneWrong.Tests
{
    public class TestClassTests
    {
        [Fact]
        public void Sutructed_1_IfTheValueIsLowerThan4()
        {
            var value = 1;

            var expected = 0;

            var dependencyA = new Mock<IDependency>();

            dependencyA.Setup(x => x.ReturnValue(It.IsAny<int>())).Returns(value);

            var target = new ClassToTest(dependencyA.Object);

            var result = target.GetResult(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public void Returned_Null_IfTheValueIsGreaterOrEqualTo4(int value)
        {

            int? expected = null;

            var dependencyA = new Mock<IDependency>();

            dependencyA.Setup(x => x.ReturnValue(It.IsAny<int>())).Returns(value);

            var target = new ClassToTest(dependencyA.Object);

            var result = target.GetResult(value);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void EnsureTheFlow_SomeFunctionA_CalledIfReturnedValueLowerThan2()
        {
            var dependency = new Mock<IDependency>();

            dependency.Setup(x => x.ReturnValue(It.IsAny<int>())).Returns(2);

            var target = new ClassToTest(dependency.Object);

            var result = target.GetResult(It.IsAny<int>());

            dependency.Verify(x => x.SomeFunctionA(), Times.Once());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public void EnsureTheFlow_SomeFunctionB_CalledIfSubtractedValueGreaterOrEqualTo2(int value)
        {
            var dependency = new Mock<IDependency>();

            dependency.Setup(x => x.ReturnValue(It.IsAny<int>())).Returns(value);

            var target = new ClassToTest(dependency.Object);

            var result = target.GetResult(It.IsAny<int>());

            dependency.Verify(x => x.SomeFunctionB(), Times.Once());
        }
    }
}
