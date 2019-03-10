(function () {
    let sum = 0;

    function add(number) {
        sum += number;
        
        return add;
    }

    add.toString = () => { return sum; }

    return add;
})();