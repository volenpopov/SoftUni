function solve() {
    let myObj =  {
        extend: function (template) {
            for (let prop of Object.keys(template)) {
                if (typeof template[prop] === 'function') {
                    Object.getPrototypeOf(myObj)[prop] = template[prop];
                } else {
                    myObj[prop] = template[prop];
                }
            }
        }
      }

      return myObj;
};

  let template = {
  extensionMethod: function () {},
  extensionProperty: 'someString'
}

console.log(myObj);

myObj.extend(template);

console.log(myObj);
  