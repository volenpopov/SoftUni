function solve() {
    document.querySelector('button')
        .addEventListener('click', onClick);

    function onClick() {
        let input = document.getElementById('input').value;
        let countOfCharsToTake = input.match(/^\d+/)[0];
        
        let str = input
            .substr(countOfCharsToTake.toString().length, countOfCharsToTake);
        
        let arr = str.split(str[str.length - 1]);

        let pattern = new RegExp(`[^=\\[${arr[0]}\\]]+`, 'g');
        let resultArr = arr[1].match(pattern);
        
        let result = '';
        
        for (let el of resultArr) {
            if (el.includes('#')) {
                el = el.replace(/[#]+/g, ' ');                                        
            }
            result += el;  
        }

        document.getElementById('output').textContent = result;
    }
}