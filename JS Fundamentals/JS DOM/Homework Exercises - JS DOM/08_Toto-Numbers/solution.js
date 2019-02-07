function solve() {
	let btn = document.getElementsByTagName('button')[0];
	btn.addEventListener('click', clickEvent);

	function clickEvent() {
		
		let inputField = document.getElementsByTagName('input')[0];
		let input = inputField.value;
		let numArray = input.split(' ').map(Number);
		
		for (let num of numArray) {
			if (isNaN(num) || num < 1 || num > 49 || numArray.length != 6) {
				return;
			}
		}

		let numsDiv = document.getElementById('allNumbers');

		for (let i = 1; i <= 49; i++) {
			let currentDiv = document.createElement('div');
			currentDiv.textContent = i.toString();
			currentDiv.classList.add('numbers');

			if (numArray.includes(i)) {
				currentDiv.style.background = 'orange';
			}

			numsDiv.appendChild(currentDiv);
		}

		inputField.disabled = true;
		btn.disabled = true;

	}

	

}