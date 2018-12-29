<?php

namespace CalculatorBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use CalculatorBundle\Entity\Calculator;
use CalculatorBundle\Form\CalculatorType;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class CalculatorController extends Controller
{
    /**
     * @param Request $request
     *
     * @Route("/", name="index", methods={"GET"})
     *
     * @return \Symfony\Component\HttpFoundation\Response
     *
     */
    public function index(Request $request)
    {
        return $this->render('calculator/index.html.twig');
    }

    /**
     * @param Request $request
     *
     * @Route("/", name="indexPost", methods={"POST"})
     *
     * @return \Symfony\Component\HttpFoundation\Response
     *
     */
    public function indexPost(Request $request)
    {
        $calculator = new Calculator();

        $form = $this->createForm(CalculatorType::class, $calculator);
        $form->handleRequest($request);

        if ($form->isSubmitted()) {
            $result = 0;

            $operator = $calculator->getOperator();
            switch ($operator) {
                case "+":
                    $leftNumber = $calculator->getLeftOperand();
                    $rightNumber = $calculator->getRightOperand();
                    $result = $leftNumber + $rightNumber;
                    break;

                case "-":
                    $leftNumber = $calculator->getLeftOperand();
                    $rightNumber = $calculator->getRightOperand();
                    $result = $leftNumber - $rightNumber;
                    break;

                case "*":
                    $leftNumber = $calculator->getLeftOperand();
                    $rightNumber = $calculator->getRightOperand();
                    $result = $leftNumber * $rightNumber;
                    break;

                case "/":
                    $leftNumber = $calculator->getLeftOperand();
                    $rightNumber = $calculator->getRightOperand();
                    $result = $leftNumber / $rightNumber;
                    break;
            }

            return $this->render('calculator/index.html.twig', [
                'result'=> $result,
                'form'=> $form->createView(),
                'calculator'=> $calculator
            ]);
        }

        return $this->render('calculator/index.html.twig');
    }
}
