function solve() {
	let qSections = Array.from(document.getElementsByTagName('section'));

	let btns = Array.from(document.getElementsByTagName('button'));
	btns[0].addEventListener('click', clickEvent);
	btns[1].addEventListener('click', clickEvent);
	btns[2].addEventListener('click', displayResults);

	
	function displayResults() {
		let resultDiv = document.getElementById('result');

		let answers = [];

		for (let q = 0; q < 3; q++) {
			for (let an of qSections[q].getElementsByTagName('input')) {
				if (an.checked === true) {
					answers[q] = an.value;
				}
			}
		}

		let wrongAnswers = 0;
		if (answers[0] != '2013') {	wrongAnswers++;}

		if (answers[1] != 'Pesho') { wrongAnswers++;}
			 
		if (answers[2] != 'Nakov') {wrongAnswers++;}

		let output = document.createElement('p');

		if (wrongAnswers > 0) {
			output.textContent = `You have ${3 - wrongAnswers} right answers`;
		} else {
			output.textContent = 'You are recognized as top SoftUni fan!';
		}
		
		resultDiv.appendChild(output);
	}

	function clickEvent(e) {

		let answered = Array.from(e.target.parentNode.getElementsByTagName('input'))
			.some((an) => an.checked === true);
		
		if (answered) {
			let index = (qSections.indexOf(e.target.parentNode) + 1);

			if (index >= 0 && index < qSections.length) {
				qSections[index].style.display = 'block';	
			}		
		}
		
	}	
}