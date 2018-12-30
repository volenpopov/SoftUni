using _03.DependencyInversion.Contracts;

namespace _03.DependencyInversion.Strategies
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
