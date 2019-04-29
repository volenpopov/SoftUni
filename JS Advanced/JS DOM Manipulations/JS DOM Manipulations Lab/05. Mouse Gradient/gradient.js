function attachGradientEvents() {
    let result = document.getElementById('result');
    let bar = document.getElementById('gradient');
    
    bar.addEventListener('mousemove', onMove);
    bar.addEventListener('mouseout', clear);

    function onMove(event) {
        let currentWidthCoordinate = event.offsetX;
        let width = this.clientWidth;
        
        result.textContent = 
            Math.floor((currentWidthCoordinate/width) * 100) + '%';
    }

    function clear() {
        result.textContent = '';
    }
}