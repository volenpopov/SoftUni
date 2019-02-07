function solve() {
    let selectMenu = document.getElementById('selectMenuTo');

    let binaryOption = document.createElement('option');
    binaryOption.value = 'binary';
    binaryOption.innerText = 'Binary'

    let hexadecimalOption = document.createElement('option');
    hexadecimalOption.value = 'hexadecimal';
    hexadecimalOption.innerText = 'Hexadecimal'
    
    selectMenu.appendChild(binaryOption);
    selectMenu.appendChild(hexadecimalOption);
    
    Array.from(document.getElementsByTagName('button'))[0].addEventListener('click', clickEvent);

    function binary (num) {
         return Number(num).toString(2);
    }

    function hexadecimal (num) {
        return Number(num).toString(16);
    }

    function clickEvent () {
        let number = document.getElementById('input').value;
        let chosenOption = document.getElementById('selectMenuTo').value;

        let convertedNum = '';
        
        if (chosenOption === 'binary') {
            convertedNum = binary(number);
        }
        else if (chosenOption === 'hexadecimal') {
            convertedNum = hexadecimal(number).toUpperCase();
        }

        let result = document.getElementById('result');
        result.value = convertedNum;
    }
    
}