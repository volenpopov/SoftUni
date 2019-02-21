function Main(input) {
    let arr = input.slice(0, input.length - 1);
    let step = Number(input[input.length - 1]);

    for (let index = 0; index < arr.length; index+=step) {
        console.log(arr[index]);
    } 
}

Main(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
);