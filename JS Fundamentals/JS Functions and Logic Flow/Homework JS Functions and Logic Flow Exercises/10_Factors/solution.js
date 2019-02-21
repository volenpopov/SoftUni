function solve() {
   let num = document.getElementById('num').value;

   let factorsArray = [];
   
   for (let i = 1; i <= num; i++) {
      if (num % i === 0) {
         factorsArray.push(i);
      }
   }

   document.getElementById('result').textContent = factorsArray.join(' ');
   
}