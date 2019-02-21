function Main(input) {
    
    let width = input[0];
    let height = input[1];
    let startRow = input[2];
    let startCol = input[3];

    let matrix = [];
    matrix = Array(height).fill().map(() => Array(width).fill(0));
    
    let cell = {};
    cell.row = startRow;
    cell.col = startCol;
    cell.value = 1;
    
    let queue = [];
    queue.unshift(cell);
    
    while (containsZero()) {

        let currentCell = queue.pop();
        
        let row = currentCell.row;
        let col = currentCell.col;
        let currentValue = currentCell.value;
        
        if ((row >= 0 && row < height) && (col >= 0 && col < width)) {
            
            if (matrix[row][col] === 0) {
                matrix[row][col] = currentValue;
            }
            
        } else {
            continue;
        }
        
        queue = enqueAllValidNeighbouringCells(row, col, currentValue);
    }

    printMatrix();

    function containsZero() {
        let result = false;

        for (let arr of matrix) {
            if (arr.includes(0)) {
                result = true;
                break;
            }
        }

        return result;
    }

    function enqueAllValidNeighbouringCells(row, col, value) {
        let leftCell = {};
        leftCell.row = row;
        leftCell.col = col - 1;
        leftCell.value = value + 1;
        
        let leftUpperDiagonalCell = {};
        leftUpperDiagonalCell.row = row - 1;
        leftUpperDiagonalCell.col = col - 1;
        leftUpperDiagonalCell.value = value + 1;

        let upperCell = {};
        upperCell.row = row - 1;
        upperCell.col = col;
        upperCell.value = value + 1;

        let rightUpperDiagonalCell = {};
        rightUpperDiagonalCell.row = row - 1;
        rightUpperDiagonalCell.col = col + 1;
        rightUpperDiagonalCell.value = value + 1;

        let rightCell = {};
        rightCell.row = row;
        rightCell.col = col + 1;
        rightCell.value = value + 1;

        let rightLowerDiagonalCell = {};
        rightLowerDiagonalCell.row = row + 1;
        rightLowerDiagonalCell.col = col + 1;
        rightLowerDiagonalCell.value = value + 1;

        let lowerCell = {};
        lowerCell.row = row + 1;
        lowerCell.col = col;
        lowerCell.value = value + 1;

        let leftLowerDiagonalCell = {};
        leftLowerDiagonalCell.row = row + 1;
        leftLowerDiagonalCell.col = col - 1;
        leftLowerDiagonalCell.value = value + 1;

        queue = enqueCell(leftCell);
        queue = enqueCell(leftUpperDiagonalCell);
        queue = enqueCell(upperCell);
        queue = enqueCell(rightUpperDiagonalCell);
        queue = enqueCell(rightCell);
        queue = enqueCell(rightLowerDiagonalCell);
        queue = enqueCell(lowerCell);
        queue = enqueCell(leftLowerDiagonalCell);
        
        return queue;
    }

    function enqueCell(cell) {
        if (cell.row >= 0 && cell.row < width && cell.col >= 0 && cell.col < height && matrix[cell.row][cell.col] === 0) {
            queue.unshift(cell);
        }

        return queue;
    }
    
    function printMatrix() {
        for (let arr of matrix) {
            console.log(arr.join(' '));
        }
    }
}

Main([4, 4, 0, 0]);