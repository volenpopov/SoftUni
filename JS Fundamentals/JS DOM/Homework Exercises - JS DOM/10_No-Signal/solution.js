function solve() {

	setInterval(random, 2000);


	function random() {
		let div = document.getElementById('exercise').children[0];

		let horizontal = document.documentElement.clientWidth;
		let vertical = document.documentElement.clientHeight;

		let randomH = Math.floor(Math.random() * 81) + 1;
		let randomV = Math.floor(Math.random() * 45) + 1;

		div.style.margin = `${(randomH / 100) * vertical}px ${(randomV / 100) * horizontal}px`;
	}

}