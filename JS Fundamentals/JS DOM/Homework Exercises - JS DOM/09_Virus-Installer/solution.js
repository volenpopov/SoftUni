function solve() {
    
    let clicks = 0;

    let btns = document.getElementsByTagName('button');
    let cancelBtn = btns[1];
    let nextButton = btns[0];
    
    nextButton.addEventListener('click', toggleNext);
    cancelBtn.addEventListener('click', hideAll)

    function hideAll() {
        let contentSection = document.getElementsByTagName('section')[0];
        contentSection.style.visibility = 'hidden';
        contentSection.style.display = 'none';
    }

    function toggleNext() {
        
        clicks += 1;

        let virusImg = document.getElementById('content');
        let firstStepDiv = document.getElementById('firstStep');
        let secondStepDiv = document.getElementById('secondStep');
        let thirdStepDiv = document.getElementById('thirdStep');

        if (clicks === 1) {
            
            virusImg.style.visibility = 'hidden';
    
            showDiv(firstStepDiv);
        }
        
        else if (clicks === 2) {
            let agreed = document.getElementsByTagName('input')[0].checked === true;
       
            if (agreed) {
                hideDiv(firstStepDiv);
    
                showDiv(secondStepDiv);
    
                btns[0].style.visibility = 'hidden';
    
                setTimeout(() => {
                    btns[0].style.visibility = 'visible';
                 }, 3000);    
            }
        
        }

        else if (clicks === 3) {
            hideDiv(secondStepDiv);

            showDiv(thirdStepDiv);

            nextButton.style.visibility = 'hidden';
            cancelBtn.textContent = 'Finish';
        }
    }

    function showDiv(div) {
        div.style.visibility = 'visible';
        div.style.display = 'block';
    }

    function hideDiv(div) {
        div.style.visibility = 'hidden';
        div.style.display = 'none';
    }
}