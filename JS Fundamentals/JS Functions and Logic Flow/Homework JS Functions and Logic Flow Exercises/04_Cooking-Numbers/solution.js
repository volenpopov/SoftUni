function solve() {
    let btns = Array.from(document.querySelectorAll('main>div>div>button'))
        .forEach((btn) => btn.addEventListener('click', clickEvent));
    
    let firstClick = true;

    function clickEvent(eventObj) {
        let btnName = eventObj.target.textContent;
        let outputParagraph = document.getElementById('output');
        let result = 0;
        
        if (firstClick) {
            result = Number(document.querySelector('#exercise>input').value);
        } else {
            result = Number(outputParagraph.textContent);
        }

        firstClick = false;

        switch (btnName) {
                
            case 'Chop':
            result /= 2;
                break;

            case 'Dice':
            result = Math.sqrt(result);
                break;

            case 'Spice':
            result += 1;
                break;

            case 'Bake':
            result *= 3;
                break;

            case 'Fillet':
            result *= 0.8;
                break;
        }
        
        outputParagraph.textContent = result;
    }

}
