function solve() {
    document.querySelector('button')
        .addEventListener('click', getCards);
    
    let cardsSection = document.getElementById('cards');

    function getCardValue(input) {
        return Number(input) < 11
            ? Number(input)
            : input === 'J' ? 11
                : input === 'Q' ? 12
                : input === 'K' ? 13
                : input === 'A' ? 14 : '';
    }

    function getCards() {
        let fromCardValue = document.getElementById('from').value;
        let toCardValue = document.getElementById('to').value;

        let start = getCardValue(fromCardValue);

        let end = getCardValue(toCardValue);
                
        if (end === '') {
             return;
         }

        let suit = document.querySelector('#exercise>select')
            .options[document.querySelector('#exercise>select').selectedIndex].textContent
            .match(/\w+/)[0];

        switch (suit) {
            case 'Hearts':
                suit = '&hearts;';
                break;

            case 'Diamonds':
                suit = '&diamond;';
                break;

            case 'Spades':
                suit = '&spades;';
                break;

            case 'Clubs':
                suit = '&clubs;';
                break;
        }

        for (let currentCard = start; currentCard <= end; currentCard++) {
            let newCardDiv = document.createElement('div');
            newCardDiv.className = 'card';

            let cardValuePar = document.createElement('p');
            currentCardValue = currentCard < 11
                ? currentCard
                : currentCard === 11 ? 'J'
                    : currentCard === 12 ? 'Q'
                    : currentCard === 13 ? 'K'
                    : currentCard === 14 ? 'A' : '';

            if (currentCardValue === '') {
                return;
            }

            let p1 = document.createElement('p');
            p1.innerHTML = `${suit}`;

            let p2 = document.createElement('p');
            p2.textContent = currentCardValue;

            let p3 = document.createElement('p');
            p3.innerHTML = `${suit}`;

            newCardDiv.appendChild(p1);
            newCardDiv.appendChild(p2);
            newCardDiv.appendChild(p3);

            cardsSection.appendChild(newCardDiv);
        }
       
    }
}