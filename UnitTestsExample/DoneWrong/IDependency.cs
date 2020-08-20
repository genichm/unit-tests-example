namespace UnitTests.DoneWrong
{
    public interface IDependency
    {
        int? ReturnValue(int valueA);
        void SomeFunctionA();
        void SomeFunctionB();
    }
}