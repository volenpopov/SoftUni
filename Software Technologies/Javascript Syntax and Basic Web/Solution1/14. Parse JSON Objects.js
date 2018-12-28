  function parseJSONobj(input) {

    for (let i = 0; i < input.length; i++) {
      let obj = JSON.parse(input[i]);
      console.log(`Name: ${obj.name}`);
      console.log(`Age: ${obj.age}`);
      console.log(`Date: ${obj.date}`);
    }
  }

parseJSONobj(['{"name":"Gosho","age":10,"date":"19/06/2005"}']);
