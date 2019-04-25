function solution() {
	let toyTypeField = $('#toyType');
	let toyPriceField = $('#toyPrice');
	let toyDescrField = $('#toyDescription');

	if (toyTypeField.val() && +toyPriceField.val() && toyDescrField.val()) {
		let newOfferDiv = $('<div>');
		newOfferDiv.addClass('gift');

		let img = $('<img>');
		img.attr('src', 'gift.png');

		let h2 = $('<h2>');
		h2.text(toyTypeField.val());

		let par = $('<p>');
		par.text(toyDescrField.val());

		let buyBtn = $('<button>');
		buyBtn.text(`Buy it for $${toyPriceField.val()}`);
		buyBtn.click(() => newOfferDiv.remove());

		newOfferDiv.append(img);
		newOfferDiv.append(h2);
		newOfferDiv.append(par);
		newOfferDiv.append(buyBtn);

		$('#christmasGiftShop').append(newOfferDiv);
	}

	toyTypeField.val('');
	toyPriceField.val('');
	toyDescrField.val('');
}


