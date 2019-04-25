function attachEvents() {
	
	let selectedTowns = [];	
	
	$('#items li').each(function() {
		$(this).click(function() {
			
			if ($(this).attr('data-selected')) {

				$(this).removeAttr('data-selected');
				$(this).css('background', '');
				selectedTowns.slice(selectedTowns.indexOf($(this).text()), 1);

			} else {

				$(this).attr('data-selected', true);
				$(this).css('background', '#DDD');
				selectedTowns.push($(this).text());
			}
		})
	});

	$('#showTownsButton').click(function() {		
		$('#selectedTowns').text(selectedTowns.join(', '));
		selectedTowns.length = 0;
	});
}