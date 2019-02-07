function solve() {

    // Array.from(document.getElementsByTagName('button'))
    //     .forEach((btn) => btn.addEventListener('click', clickEvent));

    document.querySelector('#exercise button[name="myBtn"]').addEventListener('click', clickEvent);
    document.querySelector('#exercise button[name="peshoBtn"]').addEventListener('click', clickEvent);

    function clickEvent(event) {

        let chatChronology = document.getElementById('chatChronology');

        let newDiv = document.createElement('div');
        let newSpan = document.createElement('span');
        let newParagraph = document.createElement('p');

        if (event.target.name === 'myBtn') {
            newSpan.textContent = 'Me';
            newParagraph.textContent = document.getElementById('myChatBox').value;
            newDiv.style.textAlign = 'left';
            document.getElementById('myChatBox').value = '';
        } else {
            newSpan.textContent = 'Pesho';
            newParagraph.textContent = document.getElementById('peshoChatBox').value;
            newDiv.style.textAlign = 'right';
            document.getElementById('peshoChatBox').value = '';
        }

        newDiv.appendChild(newSpan);
        newDiv.appendChild(newParagraph);
        chatChronology.appendChild(newDiv);
    }
}