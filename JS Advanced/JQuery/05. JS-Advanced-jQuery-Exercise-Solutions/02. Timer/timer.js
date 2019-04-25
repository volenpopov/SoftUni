function timer() {

   let begin;
   let isTicking = false;

   $('#start-timer').click(function () {
      if (!isTicking) {
         begin = setInterval(countSecond, 1000);
         isTicking = true;
      }
   });


   $('#stop-timer').click(function () {
      clearInterval(begin);
      isTicking = false;
   });

   function countSecond() {

      let hours = +$('#hours').text();
      let minutes = +$('#minutes').text();
      let seconds = +$('#seconds').text();

      if (seconds == 59) {
         seconds = -1;

         if (minutes < 9) {
            $('#minutes').text(`0${minutes + 1}`);
         } else {

            if (minutes == 59) {
               minutes = -1;

               if (hours < 9) {
                  $('#hours').text(`0${hours + 1}`);
               } else {
                  $('#hours').text(`${hours + 1}`);
               }
            }

            if (minutes < 9) {
               $('#minutes').text(`0${minutes + 1}`);
            } else {
               $('#minutes').text(`${minutes + 1}`);
            }

         }
      }

      if (seconds < 9) {
         $('#seconds').text(`0${seconds + 1}`);
      } else {
         $('#seconds').text(`${seconds + 1}`);
      }
   }
}