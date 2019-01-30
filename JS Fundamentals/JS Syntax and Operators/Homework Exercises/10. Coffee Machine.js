function Main(arr) {
    let income = 0.0;

    for (let i = 0; i < arr.length; i++) {
        let args = arr[i].split(', ');

        let coins = Number(args[0]).toFixed(2);
        let drink = args[1];

        let price = 0.8;

        if (drink === 'coffee' && args[2] === 'decaf') {
            price = 0.9;
        }

        if (args.includes('milk')) {
            price += 0.1;
        }

        arr[i][arr[i].length - 1] > 0 ? price += 0.1 : price;

        if (coins >= price) {
            console.log(`You ordered ${drink}. Price: ${price.toFixed(2)}$ Change: ${(coins - price).toFixed(2)}$`);
            income += price;
        }
        else {
            console.log(`Not enough money for ${drink}. Need ${(price - coins).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${income.toFixed(2)}$`);
}


Main(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
);