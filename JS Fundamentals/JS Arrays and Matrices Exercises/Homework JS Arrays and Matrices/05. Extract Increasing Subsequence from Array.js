function Main(arr) {
    if (arr.length === 0) {
        return '';
    }

    let max = -Infinity;
    let resultArr = arr.reduce((acc, el) => {
        if (el > max) {
            acc.push(el);
            max = el;
        }
        return acc;
    }, []);
    
    console.log(resultArr.join('\n'));
}

//arr
    // .filter((e, i) => e >= Math.max.apply(null, arr.slice(0, i)))
    // .join('\n');

Main([25,
21,
26,
25,
25,
31]    
    );