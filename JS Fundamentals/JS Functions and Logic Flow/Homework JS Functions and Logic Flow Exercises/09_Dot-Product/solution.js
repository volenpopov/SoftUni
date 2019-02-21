function solve() {
    let firstMatrix = JSON.parse(document.getElementById('mat1').value);
    let secondMatrix = JSON.parse(document.getElementById('mat2').value);

    //transposing the 2nd matrix
    secondMatrix = secondMatrix[0].map((col, i) => secondMatrix.map(row => row[i]));

    let resultMatrix = [];
    for (let r = 0; r < firstMatrix.length; r++) {
        resultMatrix[r] = Array(secondMatrix[0].length).fill(0);
    }

    for (let row = 0; row < resultMatrix.length; row++) {
    
        for (let col = 0; col < resultMatrix[row].length; col++) {

            resultMatrix[row][col] = calculateCell(row, col);
        }
    }

    let resultDiv = document.getElementById('result');
    for (let arr of resultMatrix) {

        let par = document.createElement('p');
        par.textContent = arr.join(', ');
        resultDiv.appendChild(par);
    }

    function transpose(m) {
        m => m[0].map((x,i) => m.map(x => x[i]));

        return m;
    } 

    function calculateCell(row, col) {
        let sum = 0;

        for (let i = 0; i < firstMatrix[row].length; i++) {
            sum += firstMatrix[row][i] * secondMatrix[i][col];
        }

        return sum;
    }
}