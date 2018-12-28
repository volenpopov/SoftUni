function addOrRemoveElements(input) {
  let array = [];
  let inputLine = "";
  for (let i = 0; i < input.length; i++) {
    inputLine = input[i].split(' ');
    let command = inputLine[0];
    let numOrIndex = inputLine[1];

    if (command == 'add')
      array.push(numOrIndex);
    else
      array.splice(numOrIndex, 1);
  }

  for (let elementIndex in array) {
    console.log(array[elementIndex]);
  }
}

addOrRemoveElements(['add 3', 'add 5', 'remove 10']);
