function Main(arr) {
    let calorieObj = {};

    for (let i = 0; i < arr.length - 1; i+=2) {
        let objKey = arr[i];
        let objValue = arr[i+1];

        calorieObj[objKey] = Number(objValue);
    }

    console.log(calorieObj);
}

Main(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);