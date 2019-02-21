function binarySearch() {
    let arr = Array.from(document.getElementById('arr').value.split(', '));
    let num = document.getElementById('num').value;

    let minIndex = 0;
    let maxIndex = arr.length - 1;
    let resultIndex = -1;

    if (arr.includes(num)) {
       while (minIndex <= maxIndex) {
           let index = Math.floor((minIndex + maxIndex) / 2);

           if (num === arr[index]) {
               resultIndex = index;
               break;
           } else if (num < arr[index]) {
                maxIndex = index - 1;
           } else {
               minIndex = index + 1;
           }
       }
    }

    document.getElementById('result').textContent = 
        resultIndex === -1 ? `${num} is not in the array`
         : `Found ${num} at index ${resultIndex}`;
}