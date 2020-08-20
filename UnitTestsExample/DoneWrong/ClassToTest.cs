namespace UnitTests.DoneWrong
{
    public class ClassToTest
    {
        private readonly IDependency _dependency;

        public ClassToTest(IDependency dependency)
        {
            _dependency = dependency;
        }

        public int? GetResult(int a)
        {
            var result = _dependency.ReturnValue(a);

            var subtracted = Subtract(result);

            if (subtracted < 2)
            {
                _dependency.SomeFunctionA();
            }
            else
            {
                _dependency.SomeFunctionB();
            }

            return subtracted;
        }

        public int? Subtract(int? value)
        {
            if (value < 4)
            {
                return value - 1;
            }

            return null;
        }
    }
}
