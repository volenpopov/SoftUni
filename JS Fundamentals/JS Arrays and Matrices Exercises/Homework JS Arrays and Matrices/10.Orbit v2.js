function Main([cols, rows, startRow, startCol]) {    
    let matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        
        for (let col = 0; col < cols; col++) {
            matrix[row].push(Math.max(Math.abs(row - startRow), Math.abs(col - startCol)) + 1);            
        }
    }

    console.log(matrix.map(row => row.join(' ')).join('\n'));    
}

Main([4, 4, 0, 0]);