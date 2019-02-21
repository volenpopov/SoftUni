function leapYear() {

    let checkBtn = document.getElementsByTagName('button')[0];
    checkBtn.addEventListener('click', clickEvent);

    function clickEvent() {
    
        let inputField = document.getElementsByTagName('input')[0];
        let year = inputField.value;

        let isLeap = false;

        year % 4 === 0 
            ? (year % 100 !== 0 ? isLeap = true : (year % 400 === 0 ? isLeap = true : isLeap = false))
            : isLeap = false;

        // if (year % 4 === 0) {

        //     if (year % 100 === 0) {

        //         if (year % 400 === 0) {
        //             isLeap = true;
        //         }
        //     } else {
        //         isLeap = true;
        //     }
        // }

        let resultH2 = document.getElementById('year').children[0];

        isLeap === true ? resultH2.textContent = 'Leap Year' 
                    : resultH2.textContent = 'Not Leap Year';

        document.getElementById('year').children[1].textContent = year;

        input.value = '';
    }
    
    
    
}