function main(arg) {
    let argType = typeof(arg);

    const errorMessage = `We can not calculate the circle area, because we receive a ${argType}.`;

    if (argType === 'number') {
        let radius = Number(arg);

        let circleArea = Math.PI * Math.pow(radius, 2);

        console.log(circleArea.toFixed(2));
    }
    else {
        console.log(errorMessage);
    }
}

main('a');