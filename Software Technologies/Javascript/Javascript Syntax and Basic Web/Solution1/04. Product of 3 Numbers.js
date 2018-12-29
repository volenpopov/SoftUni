function productOfThreeNumbers(input) {
  let numArray = input.map(Number);
  let countNegativeNums = 0;

  if (numArray.includes(0))
  {
    console.log('Positive');
    return;
  }

  for (let num of numArray) {
    if (num < 0)
      countNegativeNums += 1;
  }

  if (countNegativeNums % 2 != 0)
    console.log("Negative");
  else
    console.log("Positive");
}

productOfThreeNumbers(['2', '3', '0']);
