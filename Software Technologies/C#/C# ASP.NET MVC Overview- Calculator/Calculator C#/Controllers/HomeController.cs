using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorCSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Calculator.Models.Calculator calculator)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(Calculator.Models.Calculator calculator)
        {
            calculator.Result = CalculateResult(calculator);

            return RedirectToAction("Index", calculator);
        }

        public decimal CalculateResult(Calculator.Models.Calculator calculator)
        {
            var result = 0m;

            switch (calculator.Operator)
            {
                case "+":
                    result = calculator.LeftOperand + calculator.RightOperand;
                    break;

                case "-":
                    result = calculator.LeftOperand - calculator.RightOperand;
                    break;

                case "*":
                    result = calculator.LeftOperand * calculator.RightOperand;
                    break;

                case "/":
                    if (calculator.RightOperand == 0)
                    {
                        break;
                    }
                    result = calculator.LeftOperand / calculator.RightOperand;
                    break;
            }

            return result;

        }
    }
}