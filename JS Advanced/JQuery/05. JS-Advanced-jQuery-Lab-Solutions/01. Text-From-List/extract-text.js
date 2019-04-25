function extractText() {
   $('#result')
      .text($('ul#items li')
         .toArray()
         .map(li => li.textContent)
         .join(', '));       
}
