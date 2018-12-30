using _03.DependencyInversion.Contracts;
using _03.DependencyInversion.Strategies;
using P03_DependencyInversion;
using System;

namespace _03.DependencyInversion
{
    class Engine
    {
        private PrimitiveCalculator calculator;

        public Engine(PrimitiveCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();
                int num1 = 0;
                int num2 = 0;
                char @operator;

                if (args[0] == "mode")
                {
                    @operator = args[1][0];
                    ICalculationStrategy strategy = null;

                    switch (@operator)
                    {
                        case '+':
                            strategy = new AdditionStrategy();
                            break;

                        case '-':
                            strategy = new SubtractionStrategy();
                            break;

                        case '*':
                            strategy = new MultiplicationStrategy();
                            break;

                        case '/':
                            strategy = new DivisionStrategy();
                            break;
                    }

                    this.calculator.changeStrategy(strategy);
                }

                else
                {
                    num1 = int.Parse(args[0]);
                    num2 = int.Parse(args[1]);

                    int result = this.calculator.performCalculation(num1, num2);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
