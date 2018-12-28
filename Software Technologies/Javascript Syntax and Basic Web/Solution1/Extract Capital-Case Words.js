function extractCapitalCaseWords(input) {
  let joinedInput = input.join(",");
  let tokens = joinedInput.split(/\W+/);
  let tokensWithoutBlank = tokens.filter(removeBlanks)
  let upperWords = tokensWithoutBlank.filter(isUpperCase);

  function removeBlanks(str) {
    return str != '';
  }
  function isUpperCase(str) {
    return str === str.toUpperCase();
  }

  console.log(upperWords.join(", "));
}

extractCapitalCaseWords(['We start by HTML, CSS, JavaScript, JSON and REST.\n' +
'Later we touch some PHP, MySQL and SQL.\n' +
'Later we play with C#, EF, SQL Server and ASP.NET MVC.\n' +
'Finally, we touch some Java, Hibernate and Spring.MVC.'])

