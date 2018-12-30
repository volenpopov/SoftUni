using P03_DependencyInversion;

namespace _03.DependencyInversion
{
    class Program
    {
        static void Main()
        {
            PrimitiveCalculator calculator = 
                new PrimitiveCalculator(new AdditionStrategy());

            Engine engine = new Engine(calculator);
            engine.Run();
        }
    }
}
