function turnObjIntoJSONstring(input) {
  let obj = {};
  for (let i = 0; i < input.length; i++) {
    let elements = input[i].split(' ');
    let propName = elements[0];
    let value = isNaN(elements[2]) ? elements[2] : Number(elements[2]);

    obj[propName] = value;
  }
  let str = JSON.stringify(obj);
  console.log(str);
}

turnObjIntoJSONstring(['name -> Angel', 'surname -> Georgiev', 'date -> 23/05/1995'])
