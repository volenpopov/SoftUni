function solve(input) {
  let array = [];

  for (let i = 0; i < input.length; i++) {
    let elements = input[i].split(/\s->\s/);
    let studName = elements[0];
    let studAge = elements[1];
    let studGrade = elements[2];

    let obj = { 'Name' : studName, 'Age' : studAge, 'Grade' : studGrade};
    array[i] = new Array();
    array[i].push(obj);
  }

  for (let i in array) {
    console.log('Name: ' + array[i][0]['Name']);
    console.log('Age: ' + array[i][0]['Age']);
    console.log('Grade: ' + array[i][0]['Grade']);
  }
}

solve(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 4.90']);
