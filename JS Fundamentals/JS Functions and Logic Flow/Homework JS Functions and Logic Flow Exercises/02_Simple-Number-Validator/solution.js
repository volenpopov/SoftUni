function validate() {
    let checkBtn = document.querySelector('button');
    checkBtn.addEventListener('click', clickEvent);

    function checkLastDigit(input) {
        let lastDigit = Number(input[9]);
        let weightsArray = [2, 4, 8, 5, 10, 9, 7, 3, 6];

        let sumProduct = 0;
        for (let i = 0; i < input.length - 1; i++) {
            sumProduct += input[i] * weightsArray[i];
        }
        
        let remainder = sumProduct % 11 === 10 ? 0 : sumProduct % 11;

        return lastDigit === remainder;
    }
    
    function clickEvent() {
        let inputField = document.querySelector('input');
        let inputText = inputField.value;

        let firstCheck = inputText.length === 10;
        let secondCheck = checkLastDigit(inputText);
        
        let msg = 'This number is';
        let resultSpan = document.getElementById('response');

        if (firstCheck && secondCheck) {
            resultSpan.textContent = `${msg} Valid!`;
        } else {
            resultSpan.textContent = `${msg} NOT Valid!`;
        }
         
    }
}