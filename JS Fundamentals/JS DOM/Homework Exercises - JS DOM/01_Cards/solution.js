function solve() {
    let imgArray = Array.from(document.getElementsByTagName('img'));
        
    imgArray.forEach((img) =>  {
            if (img.parentNode.id === 'player1Div' || img.parentNode.id === 'player2Div') 
                img.addEventListener('click', clickEvent);
            }
        );

    function clickEvent(e) {
        let card = e.target;
        card.src = "images/whiteCard.jpg";
        card.removeEventListener('click', clickEvent);

        let parent = card.parentNode;
        let spans = document.getElementById('result').children;
        
        if (parent.id === 'player1Div') {
            spans[0].textContent = card.name;

        }
        else {
            spans[2].textContent = card.name;
        }

        if (spans[0].textContent != '' && spans[2].textContent != '') {
           imgArray.forEach((img) => {
                if (img.name === spans[0].textContent) {
                        if (Number(spans[0].textContent) > Number(spans[2].textContent)) {
                            img.style.border = '2px solid green';
                        }
                        else {
                            img.style.border = '2px solid darkred';
                        } 
                    }
                else if (img.name === spans[2].textContent) {
                    if (Number(spans[2].textContent) > Number(spans[0].textContent)) {
                        img.style.border = '2px solid green';
                    }
                    else {
                        img.style.border = '2px solid darkred';
                    } 
                }
            });

            document.getElementById('history').textContent 
                += `[${spans[0].textContent} vs ${spans[2].textContent}] `;
            
            // setTimeout(() => {
                spans[0].textContent = '';
                spans[2].textContent = '';
            // }, 2000);
            
        }

        
    }
    
}

// Easier way to get the img: document.querySelector(`#player1Div img[name="${span[0].textContent}"]`);