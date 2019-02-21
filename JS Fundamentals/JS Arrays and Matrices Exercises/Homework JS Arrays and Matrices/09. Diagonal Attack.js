function Main(input) {
    
    // let matrix = getMatrix(); 
    let matrix = input.map(row => row.split(' ').map(Number));

    let leftDiagonalSum = getLeftDiagonalSum();
    let rightDiagonalSum = getRightDiagonalSum();

    if (leftDiagonalSum === rightDiagonalSum) {
        transformMatrix();
    }

    printMatrix();

    function transformMatrix() {
        let leftDiagonalColumn = 0;
        let rightDiagonalColumn = matrix.length - 1;

        for (let row = 0; row < matrix.length; row++) {
            
            for (let col = 0; col < matrix.length; col++) {                

                if (col === leftDiagonalColumn || col === rightDiagonalColumn) {
                    continue;
                } else {
                    matrix[row][col] = leftDiagonalSum;
                }
            }

            leftDiagonalColumn++;
            rightDiagonalColumn--;
        }

        return matrix;
    }

    function printMatrix() {
        for (let arr of matrix) {
            console.log(arr.join(' '));
        }
    }
    
    function getRightDiagonalSum() {
        let sum = 0;
        let col = matrix.length - 1;

        for (let row = 0; row < matrix.length; row++, col--) {
            sum += matrix[row][col];
        }

        return sum;
    }

    function getLeftDiagonalSum() {
        let sum = 0;
        let col = 0;

        for (let row = 0; row < matrix.length; row++, col++) {
            sum += matrix[row][col];
        }

        return sum;
    }
    
    function getMatrix() {
        let matrix = [];

        let row = 0;

        for (let arr of input) {
            matrix[row] = [];
            let col = 0;
    
            for (let element of arr.split(' ')) {
                matrix[row][col] = Number(element);
                col++;
            }
            row++;
        }

        return matrix;
    }
}

Main(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);