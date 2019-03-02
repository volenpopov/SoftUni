function solve() {
    let outputSection = document.getElementById('output');
    let numberOfFans = 0;
    let profit = 0;

    let vipPrices = 
    {
        'A' : 25,
        'B' : 15,
        'C' : 10
    };

    let normalPrices = 
    {
        'A' : 10,
        'B' : 7,
        'C' : 5 
    };

    Array.from(document.getElementsByClassName('seat'))
        .forEach(seat => seat.addEventListener('click', tryTakeSeat));
    
    document.querySelector('#summary > button')
        .addEventListener('click', onSubmit);
        
    function onSubmit() {
        document.querySelector('#summary > span').textContent 
            = `${profit} leva, ${numberOfFans} fans.`;

        profit = 0;
        numberOfFans = 0;
    }

    function tryTakeSeat(e) {
        let seatNumber = e.target.textContent;
        let zone = e.target.parentNode.parentNode.parentNode.parentNode.parentNode.className;
        let sectorIndex = e.target.parentNode.cellIndex;        
        let sector = '';

        if (sectorIndex === 0) {
            sector = 'A';
        } else if (sectorIndex === 1) {
            sector = 'B';
        } else {
            sector = 'C';
        }

        if (e.target.style.backgroundColor != 'rgb(255, 0, 0)') {            
            outputSection.textContent += ` Seat ${seatNumber} in zone ${zone} sector ${sector} was taken.`
                + '\n';

            e.target.style.backgroundColor = 'rgb(255, 0, 0)';

            numberOfFans++;

            if (zone === 'VIP') {
                profit += vipPrices[sector];
            } else {
                profit += normalPrices[sector];
            }

        } else {
            outputSection.textContent += ` Seat ${seatNumber} in zone ${zone} sector ${sector} is unavailable.`
                + '\n';
        }                
    }
}