function validate() {
    document.querySelector('button').addEventListener('click', clickEvent);
    
    function getLastDigit(EGN) {
        let weightsArray = [2, 4, 8, 5, 10, 9, 7, 3, 6];

        let sumProduct = 0;
        for (let i = 0; i < EGN.length; i++) {
            sumProduct += EGN[i] * weightsArray[i];
        }
        
        return sumProduct % 11 === 10 ? '0' : (sumProduct % 11).toString();        
    }

    function clickEvent() {
        let yearField = document.getElementById('year');
        let monthField = document.getElementById('month');
        let dateField = document.getElementById('date');
        let regionalCodeField = document.getElementById('region');

        let monthArray = [];
        monthArray['January'] = '01';
        monthArray['February'] = '02';
        monthArray['March'] = '03';
        monthArray['April'] = '04';
        monthArray['May'] = '05';
        monthArray['June'] = '06';
        monthArray['July'] = '07';
        monthArray['August'] = '08';
        monthArray['September'] = '09';
        monthArray['October'] = '10';
        monthArray['November'] = '11';
        monthArray['December'] = '12';

        let year = yearField.value;
        
        let month = monthField.options.selectedIndex !== 0 
            ? monthField.options[monthField.selectedIndex].value 
            : '';
        
        let date = dateField.value;
        let gender = document.getElementById('male').checked === true ? 'male'
            : document.getElementById('female').checked === true ? 'female'
            : '';

        let regionalCode = regionalCodeField.value;
        
        if (year < 1900 || year > 2100 || regionalCode < 43 || regionalCode > 999 || date < 1 || date > 31 || gender === '' || month === '') {
            return;
        }

        let yearStr = year.toString();
        let dateStr = date > 9 ? date.toString() : `0${date.toString()}`;
        let regionalCodeStr = regionalCode.toString();

        let EGN = `${yearStr[2]}`;
        EGN += `${yearStr[3]}`;
        EGN += `${monthArray[month]}`;
        EGN += dateStr;
        EGN += `${regionalCodeStr[0]}`;
        EGN += `${regionalCodeStr[1]}`;
        gender === 'male' ? EGN += '2' : EGN += '1';
        EGN += getLastDigit(EGN);

        yearField.value = '';
        monthField.options.selectedIndex = 0;
        dateField.value = '';
        gender === 'male' ? document.getElementById('male').checked = false 
            : document.getElementById('female').checked = false;

        regionalCodeField.value = '';

        document.getElementById('egn').textContent = `Your EGN is: ${EGN}`; 
    }
}