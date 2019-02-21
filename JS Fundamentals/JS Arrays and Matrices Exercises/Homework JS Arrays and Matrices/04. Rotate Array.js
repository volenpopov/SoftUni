function Main(input) {
    let rotations = input.pop() % input.length;
    let arr = input;
    
    for (let rot = 0; rot < rotations; rot++) {
        
        let lastElement = arr[arr.length - 1];
        for (let index = arr.length - 1; index > 0; index--) {
            arr[index] = arr[index - 1];
        }
        arr[0] = lastElement;  
    }
    console.log(arr.join(' ')); 
}

Main(['1', 
'2', 
'3', 
'4', 
'2']
);