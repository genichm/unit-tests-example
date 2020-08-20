namespace UnitTests.DoneRight
{
    public class Dependency : IDependency
    {
        public int? ReturnValue(int value)
        {
            return value;
        }

        public int? Subtract(int? value)
        {
            if (value < 4)
            {
                return value - 1;
            }

            return null;
        }

        public void SomeFunctionA()
        {

        }

        public void SomeFunctionB()
        {

        }
    }
}
