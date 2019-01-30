function Main(num) {
    let strNum = num.toString();
    let allEqual = true;
    let sum = Number(strNum[0]);

    for (let i = 0; i < strNum.length - 1; i++) {
        sum += Number(strNum[i + 1]);

        if (strNum[i] !== strNum[i + 1] && allEqual === true) {
            allEqual = false;
        }
    }

    console.log(allEqual);
    console.log(sum);
}

Main(1234);