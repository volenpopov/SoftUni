package com.softuni.entity;

public class Calculator {
    private double leftOperand;
    private double rightOperand;
    private String operator;

    public Calculator(double leftOperand, double rightOperand, String operator)
    {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }

    public double calculateResult() {
        double result = 0;

        switch (operator) {
            case "+":
                result = leftOperand + rightOperand;
                break;

            case "-":
                result = leftOperand - rightOperand;
                break;

            case "*":
                result = leftOperand * rightOperand;
                break;

            case "/":
                result = leftOperand / rightOperand;
                break;
        }

        return result;
    }


    public double getLeftOperand() {
        return leftOperand;
    }

    public void setLeftOperand(double leftOperand) {
        this.leftOperand = leftOperand;
    }

    public double getRightOperand() {
        return rightOperand;
    }

    public void setRightOperand(double rightOperand) {
        this.rightOperand = rightOperand;
    }

    public String getOperator() {
        return operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }
}
