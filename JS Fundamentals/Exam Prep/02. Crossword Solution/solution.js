function solve() {
   let inputField = document.querySelector('#input');
   let outputParagraph = document.querySelector('#output > p');   

   let btns = document.getElementsByTagName('button');
   btns[0].addEventListener('click', filter);
   btns[1].addEventListener('click', sort);
   btns[2].addEventListener('click', rotate);
   btns[3].addEventListener('click', get);

   function filter() {
      let input = inputField.value;
      let dropdown = document.getElementById('filterSecondaryCmd');
      let secondaryCmd = dropdown.options[dropdown.selectedIndex].value;
      let position = document.getElementById('filterPosition').value;
      
      let elements = [];

      switch (secondaryCmd) {
         case 'uppercase':
            elements = input.match(/[A-Z]/g);            
            break;

         case 'lowercase':
            elements = input.match(/[a-z]/g);            
            break;

         case 'nums':
            elements = input.match(/[0-9]/g);            
            break;
      }

      if (position - 1 >= 0 && position - 1 < elements.length) {
         outputParagraph.textContent += elements[position - 1];
      }
      
   }

   function sort() {      
      let elements = inputField.value.split('');
      let dropdown = document.getElementById('sortSecondaryCmd');
      let sortOption = dropdown.options[dropdown.selectedIndex].value;
      let position = document.getElementById('sortPosition').value;

      if (sortOption === 'A') {
         elements.sort();
      } else {
         elements.sort().reverse();
      }
      
      if (position - 1 >= 0 && position - 1 < elements.length) {
         outputParagraph.textContent += elements[position - 1];
      }
   }
     
   function rotate() {
      let elements = inputField.value.split('');
      let rotations = document.getElementById('rotateSecondaryCmd').value;
      let position = document.getElementById('rotatePosition').value;

      let lastElement = 0;

      if (rotations > elements.length) {
         rotations %= elements.length;
      }

      for (let rotation = 0; rotation < rotations; rotation++) {         
         
         lastElement = elements[elements.length - 1];

         for (let index = elements.length - 1; index >= 1; index--) {
            elements[index] = elements[index - 1];
         }
         elements[0] = lastElement;
      }

      if (position - 1 >= 0 && position - 1 < elements.length) {
         outputParagraph.textContent += elements[position - 1];
      }
   }

   function get() {
      let input = inputField.value;
      let position = document.getElementById('getPosition').value;
      
      if (position - 1 >= 0 && position - 1 < input.length) {
         outputParagraph.textContent += Array.from(input.split(''))[position - 1];
      }
   }
}