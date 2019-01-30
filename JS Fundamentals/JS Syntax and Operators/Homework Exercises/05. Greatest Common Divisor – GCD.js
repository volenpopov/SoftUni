function Main(a, b) {

    let gcd = function (a, b) {
        a = Math.abs(a);
        b = Math.abs(b);

        while (a !== 0 && b !== 0) {
            if (a > b) {
                a %= b;
            }
            else {
                b %= a;
            }
        }

        return a === 0 ? b : a;
    };

    console.log(gcd(a, b));
}

Main(2154, 458);