function lookupChar(string, index) {

    let result;

    if (typeof(string) !== 'string' || typeof(index) !== 'number') {
        result = undefined;
    } else if (index < 0 || index > string.length - 1) {
        result = 'Incorrect index';
    } else {
        result = string[index];
    }

    return result; 
}

module.exports = lookupChar;

