function multiplyDivideNum(input) {
  let numArray = input.map(Number);
  let n = numArray[0];
  let x = numArray[1];
  let result = 0;

  if (x >= n)
     result = n * x;
  else
     result = n / x;

  console.log(result);
}

multiplyDivideNum(['13', '13']);
