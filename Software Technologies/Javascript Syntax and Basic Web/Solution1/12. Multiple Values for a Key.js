function multipleValuesForAKey(input) {
  let dict = {};
  let lastElement = input[input.length - 1];

  for (let i = 0; i < input.length - 1; i++) {
    let elements = input[i].split(' ');
    let key = elements[0];
    let value = elements[1];

    if (dict[key] == undefined)
      dict[key] = new Array();
    dict[key].push(value);
  }

  if (dict[lastElement] == undefined)
    console.log('None');
  else {
    for (let elementIndex in dict[lastElement]) {
      console.log(dict[lastElement][elementIndex]);
    }
  }
}

multipleValuesForAKey(['key value', 'key eulav', 'key']);
