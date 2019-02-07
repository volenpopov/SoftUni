function solve() {

   Array.from(document.getElementsByTagName('button'))
      .forEach((btn) => btn.addEventListener('click', clickEvent))
   
   function clickEvent(e) {
      let user = e.originalTarget.previousElementSibling.id.substring(0,5);
      
      let profileLocked = document.getElementsByName(`${user}Locked`)[0].checked;
      
      if (!profileLocked) {
         let div =  document.getElementById(e.originalTarget.previousElementSibling.id);
         let infoIsDisplayed = div.style.display === 'block';

         if (!infoIsDisplayed) {
            div.style.display = 'block';
            e.target.textContent = 'Hide it';
         }  
         
         else {
            div.style.display = 'none';
            e.target.textContent = 'Show more';
         }
      } 
   }
} 