function solve(args) {
  let objects = args.map(JSON.parse);
  let sums = {};

  for (let element of objects) {
    let townName = element.town;
    let townIncome = element.income;

    if (townName in sums)
      sums[townName] += townIncome;
    else
      sums[townName] = townIncome;
  }

  let sortedTowns = Object.keys(sums).sort();

  for (let argument of sortedTowns) {
    let output = `${argument} -> ${sums[argument]}`;
    console.log(output);
  }

}


solve([
  '{"town":"Sofia","income":200}',
  '{"town":"Varna","income":120}',
  '{"town":"Pleven","income":60}',
  '{"town":"Varna","income":70}'
]);
