function Main(rows, cols) {
    let matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
    }

    let startRow = 0;
    let endRow = rows;
    let startCol = 0;
    let endCol = cols;
    let num = 1;

    while (true) {
        matrix = populateHorizontal(startRow, startCol, endCol, num);   
        num += endCol - startRow; 
        
        if (getTotalElements() >= rows * cols) {break;}

        matrix = populateVerticalDownwards(startRow, endCol, endRow, num);
        num += endRow - startRow - 1;

        if (getTotalElements() >= rows * cols) {break;}

        matrix = populateHorizontalBackwards(endRow, startCol, endCol, num);
        num += endCol - startCol - 1;

        if (getTotalElements() >= rows * cols) {break;}

        matrix = populateVerticalUpwards(endRow, startCol, startRow, num);
        num += endRow - 1 - startRow - 1;

        if (getTotalElements() >= rows * cols) {break;}

        startRow++;
        startCol++;
        endRow--;
        endCol--;
    }

    console.log(matrix.map(row => row.join(' ')).join('\n'));
    

    // for (let arr of matrix) {
    //     console.log(arr.join(' '));
    // }

    function populateHorizontal(row, startCol, endCol, num) {

        for (let col = startCol; col < endCol; col++, num++) {
            matrix[row][col] = num;
        }

        return matrix;
    }

    function populateVerticalDownwards(startRow, col, endRow, num) {

        for (let row = startRow + 1; row < endRow; row++, num++) {
            matrix[row][col - 1] = num;
        }

        return matrix;
    }

    function populateHorizontalBackwards(endRow, startCol, endCol, num) {
        let row = endRow - 1;

        for (let col = endCol - 2; col >= startCol; col--, num++) {
            matrix[row][col] = num;
        }

        return matrix;
    }

    function populateVerticalUpwards(endRow, startCol, startRow, num) {
        for (let row = endRow - 2; row > startRow; row--, num++) {
            matrix[row][startCol] = num;
        }

        return matrix;
    }

    function getTotalElements() {
        let elements = 0;

        for (let arr of matrix) {
            for (let col = 0; col < arr.length; col++) {
                if (arr[col]) {
                    elements++;
                }
            }
        }

        return elements;
    }
}

Main(7, 7);