function attachEventsListeners() {
    const multipliers = {
        days: {
            hours: 24,
            minutes: 24 * 60,
            seconds: 24 * 60 * 60
        },

        hours: {
            days: 1/24,
            minutes: 60,
            seconds: 60 * 60
        },

        minutes: {
            days: 1 / (24 * 60),
            hours: 1 / 60,
            seconds: 60
        },

        seconds: {
            days: 1 / (24 * 60 * 60),
            hours: 1 / (60 * 60),
            minutes: 1 / 60
        }
    };

    let btnsArr = Array.from(
            document.querySelectorAll('div input:last-child'));

    btnsArr.forEach(btn => {
        btn.addEventListener('click', convert)
    });
    
    function convert() {
        
        let indexOfBtn = btnsArr.indexOf(this);
        let timeUnit = this.id.substr(0, this.id.length - 3);        
        let timeValueToConvert = document.getElementById(timeUnit).value;
        
        for (let i = 0; i < btnsArr.length; i++) {
            
            if (i === indexOfBtn) {
                continue;
            }

            let currentTimeUnitId = 
                btnsArr[i].id.substr(0, btnsArr[i].id.length - 3);

            let currentTimeSection = document.getElementById(currentTimeUnitId);
                        
            let calculatedTime = 
                (timeValueToConvert * multipliers[timeUnit][currentTimeUnitId])
                .toFixed(2);

            currentTimeSection.value = calculatedTime;
        }               
    }
}