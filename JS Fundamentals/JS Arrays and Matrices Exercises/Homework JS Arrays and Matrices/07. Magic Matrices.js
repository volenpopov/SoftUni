function Main(input) {
    
    let result = true;
    let targetSum = input[0].reduce((a, b) => a + b);

    for (let i = 0; i < input.length; i++) {
        
        let colSum = 0;

        for (let j = 0; j < input.length; j++) {
            colSum += input[j][i];
        }
        
        if (colSum != targetSum) {
            result = false;
            break;
        }
    }

    console.log(result); 
}

Main([[1],
    [1],
    [1]]
   
   );