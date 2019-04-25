function search() {
   let searchPattern = $('#searchText').val();

   let matches = $(`#towns li:contains('${searchPattern}')`);

   $('#towns li').css('font-weight', '');

   matches.css('font-weight', 'bold');

   $('#result').text(`${matches.toArray().length} matches found`);
}