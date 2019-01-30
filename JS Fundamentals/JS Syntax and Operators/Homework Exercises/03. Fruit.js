function main(arg1, arg2, arg3) {
    let fruit = arg1;
    let grams = Number(arg2);
    let pricePerKg = Number(arg3);

    let weightInKg = grams/1000;
    let totalPrice = (weightInKg * pricePerKg);

    console.log(`I need ${totalPrice.toFixed(2)} leva to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

main('apple', 1000, 2);