namespace UnitTests.DoneWrong
{
    public class Dependency : IDependency
    {
        public int? ReturnValue(int value)
        {
            return value;
        }

        public void SomeFunctionA()
        {

        }

        public void SomeFunctionB()
        {

        }
    }
}
