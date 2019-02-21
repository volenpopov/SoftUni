function getNext() {
    let num = Number(document.getElementById('num').value);
    
    let hailStoneArray = [];
    hailStoneArray.push(num);

    while (num != 1) {
        if (num % 2 === 0) {
            num /= 2;
        } else {
            num = (3 * num) + 1;
        }

        hailStoneArray.push(num);
    }
    
    document.getElementById('result').textContent = hailStoneArray.join(' ') + ' ';
    
}