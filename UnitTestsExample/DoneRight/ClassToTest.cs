namespace UnitTests.DoneRight
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

            var subtracted = _dependency.Subtract(result);

            if(subtracted < 2)
            {
                _dependency.SomeFunctionA();
            }
            else
            {
                _dependency.SomeFunctionB();
            }

            return subtracted;
        }
    }
}
