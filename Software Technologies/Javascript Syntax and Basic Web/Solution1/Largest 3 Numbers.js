function getLargest3Nums(input) {
  let array = input;
  array = array.sort((a, b) => a - b);

  for (let i = array.length - 1; i >= array.length - 3; i--) {
    if (array[i])
      console.log(array[i]);
  }
}


getLargest3Nums([20, 15])
