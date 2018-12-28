function multiply2Numbers(input) {
  let array = input.map(Number);
  let num1 = array[0];
  let num2 = array[1];
  let result = num1 * num2;

  console.log(result);
}

multiply2Numbers(['2', '5']);
