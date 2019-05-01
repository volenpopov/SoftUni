function dart(){

    const layerIndexToPoints = {
        firstLayer: 0,
        secondLayer: 1,
        thirdLayer: 2,
        fourthLayer: 3,
        fifthLayer: 4,
        sixthLayer: 5
    };

    let points = Array.from(
        document.querySelectorAll('#scoreBoard table tbody tr td:nth-child(2)'))
        .map(td => Number(td.textContent
                            .substr(0, td.textContent.length - 7)));

        
    let firstLayer = document.getElementById('firstLayer');
    firstLayer.addEventListener('click', makeTurn);

    let homePlayerTurn = true;

    let homePlayer = document.querySelector('#Home p');
    let awayPlayer = document.querySelector('#Away p');

    let homePar = document.querySelector('#Home p:nth-child(2)');
    let awayPar = document.querySelector('#Away p:nth-child(2)');

    let turnsElementChildren = document.getElementById('turns').children;    

    function makeTurn(event) {
        let layer = event.target.id;
        let currentPoints = points[layerIndexToPoints[layer]];                

        if (homePlayerTurn) {   
            
            homePlayer.textContent = 
                Number(homePlayer.textContent) + currentPoints;

            homePlayerTurn = false;
            turnsElementChildren[0].textContent = 'Turn on Away';
            turnsElementChildren[1].textContent = 'Next is Home';
            
        } else {

            awayPlayer.textContent = 
                Number(awayPlayer.textContent) + currentPoints;

            homePlayerTurn = true;
            turnsElementChildren[0].textContent = 'Turn on Home';
            turnsElementChildren[1].textContent = 'Next is Away';
        }
        
        if (Number(homePlayer.textContent) >= 100) {

            homePar.style.background = 'green';
            awayPar.style.background = 'red';
            firstLayer.removeEventListener('click', makeTurn);
        
        } else if (Number(awayPlayer.textContent) >= 100) {

            homePar.style.background = 'red';
            awayPar.style.background = 'green';
            firstLayer.removeEventListener('click', makeTurn);
        }
    }
}