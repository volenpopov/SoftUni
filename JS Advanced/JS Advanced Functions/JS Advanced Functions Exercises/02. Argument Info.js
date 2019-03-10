function Main() {
    let types = {};

    for (let a of arguments) {
        types[typeof(a)] = 0;
    }

    for (let a of arguments) {
        types[typeof(a)]++;
        console.log(`${typeof(a)}: ${a}`);
    }

    let sortedTypes = [];

    for (let a in types) {
        sortedTypes.push(`${a.toString()} = ${types[a]}`);
    }

    for (let a of sortedTypes.sort((a, b) => Number(b.match(/[\d]+$/)) - Number(a.match(/[\d]+$/)))) {
        console.log(a);
    }
}


Main({ name: 'bob' }, 3.333, 9.999);
