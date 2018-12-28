function  symmetricNumbers(n) {
  let num = Number(n[0]);
  let result = '';

  for (let i = 1; i <= num; i++) {
    let check = false;
    let array = i.toString();

    for (let i2 = 0; i2 < array.length / 2; i2++) {
      if (array[i2] == array[array.length - i2 - 1])
       check = true;
      else {
        check = false;
        break;
      }
    }
    if (check)
      result += i + " ";
  }
  console.log(result);
}

symmetricNumbers(['750']);
