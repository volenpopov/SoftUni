function KVP(input) {
  let dict = [];
  for (let i = 0; i < input.length - 1; i++) {
    let elements = input[i].split(' ');
    let key = elements[0];
    let value = elements[1];

    dict[key] = value;
  }

  if (dict[input[input.length - 1]] == undefined)
    console.log('None');
  else
    console.log(dict[input[input.length - 1]]);
}

KVP(['3 test', '3 test1', '4 test1', '4 test5', '4'])
