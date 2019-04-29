function attachEventsListeners() {
    const meterConverter = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };

    let btn = document.getElementById('convert');    
    btn.addEventListener('click', convert);

    function convert() {
        let fromValue = 
            Number(document.getElementById('inputDistance').value);
        
        let fromList = document.getElementById('inputUnits');
        let fromMetric = fromList.options[fromList.selectedIndex].value;
        
        let toList = document.getElementById('outputUnits');
        let toMetric = toList.options[toList.selectedIndex].value;
        
        let result;
        
        if (fromMetric === 'm') {
            result = fromValue / meterConverter[toMetric];            
        } else {
            result = 
                (fromValue * meterConverter[fromMetric]) / meterConverter[toMetric];
        }
        
        let outputElement = document.getElementById('outputDistance');
        outputElement.disable = 'false';
        outputElement.value = result;
        outputElement.disable = 'true';
    };
}