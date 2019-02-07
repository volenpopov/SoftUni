function main(num1, num2) {
    let start = Number(num1);
    let end = Number(num2);

    let sum = 0;

    for (let i = start; i <= end; i++) {
        sum += i;
    }

    // while (start <= end)
    // {
    //     sum += start++;
    // }

    console.log(sum);
}

main(1, 3);