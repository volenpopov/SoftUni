function greatestCD() {
    let firstNum = Number(document.getElementById('num1').value);
    let secondNum = Number(document.getElementById('num2').value);

    while (firstNum != 0 && secondNum != 0) {

        if (firstNum > secondNum) {
            firstNum %= secondNum;
        } else {
            secondNum %= firstNum;
        }
    }

    let gcd = firstNum === 0 ? secondNum : firstNum;

    document.getElementById('result').textContent = gcd;
}