function main(leftOperand, rightOperand, operator) {
    let a = Number(leftOperand);
    let b = Number(rightOperand);

    let result = 0;

    switch (operator) {
        case '+': result = a + b;
            break;

        case '-': result = a - b;
            break;

        case '*': result = a * b;
            break;

        case '/': result = a / b;
            break;

        case '**': result = a ** b;
            break;

        case '%': result = a % b;
            break;
    }

    console.log(result);
}

main(10, 5, '+');