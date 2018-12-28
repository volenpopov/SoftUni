function setValuesToIndexes(input) {
  let length = input[0];
  let array = {};
  let inputStr = {};

  for (let i = 1; i < input.length; i++) {
    inputStr = input[i].split(' ');
    let index = inputStr[0];
    let num = inputStr[2];

    array[index] = num;
  }

  for (let i = 0; i < length; i++) {
    if (array[i] == undefined)
      array[i] = 0;
    console.log(array[i]);
  }
}

setValuesToIndexes([2, '0 - 21', '0 - 3', '0 - 7'])
