function Main(a, b) {

    while (a != 0 && b != 0) {
        if (a > b) {
            a %= b;
        } else {
            b %= a;
        }
    }

    if (a <= 0) {
        return b;
    } else {
        return a;
    }
}