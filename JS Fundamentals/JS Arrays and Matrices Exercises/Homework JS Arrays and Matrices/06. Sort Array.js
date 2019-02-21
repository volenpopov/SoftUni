function Main(input) {
    console.log(input.sort(sortByLength, sortAlphabetically).join('\n'));
    

    function sortByLength(a, b) {
        if (a.length < b.length) {
            return -1;
        } else if (a.length > b.length) {
            return 1;
        } else {
            return sortAlphabetically(a, b);
        }
    }

    function sortAlphabetically(a, b) { 
        if (a < b) {
            return -1;
        } else if (a > b) {
            return 1;
        } else {
            return 0;
        }
    }
    
}

Main(['test', 
'Deny', 
'omen',
'Default']
);