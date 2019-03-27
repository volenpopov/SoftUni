function isOddOrEven(input) {
    let result = '';

    if (typeof(input) !== 'string') {
        result = undefined;
    } else {        
        input.length % 2 === 0
            ? result = 'even'
            : result = 'odd';
    }

    return result;
}

module.exports = isOddOrEven;




