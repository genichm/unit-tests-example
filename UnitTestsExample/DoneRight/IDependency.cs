namespace UnitTests.DoneRight
{
    public interface IDependency
    {
        int? ReturnValue(int valueA);
        void SomeFunctionA();
        void SomeFunctionB();
        int? Subtract(int? value);
    }
}