function subtract() {
    let leftNumber = +document.getElementById('firstNumber').value;
    let rightNumber = +document.getElementById('secondNumber').value;
    let resultDiv = document.getElementById('result');
    
    let calculation = leftNumber - rightNumber;
    resultDiv.textContent = calculation;
}