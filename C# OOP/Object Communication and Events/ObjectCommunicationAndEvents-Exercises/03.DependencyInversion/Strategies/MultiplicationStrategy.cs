using _03.DependencyInversion.Contracts;

namespace _03.DependencyInversion.Strategies
{
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
