function solve() {
	
	let btnArray = document.getElementsByTagName('button');
	let textareaArray = document.getElementsByTagName('textarea');

	let sendBtn = btnArray[0];
	let receiveBtn = btnArray[1];

	let inputTextArea = textareaArray[0];
	let outputTextArea = textareaArray[1];

	sendBtn.addEventListener('click', sendMsg);
	receiveBtn.addEventListener('click', decodeMsg);
	
	function sendMsg() {
		let msg = inputTextArea.value;
		document.getElementsByTagName('textarea')[0].value = '';

		let encodedMsg = '';
		for (let ch of msg) {
			encodedMsg += String.fromCharCode((ch.charCodeAt() + 1));
		}

		outputTextArea.value = encodedMsg;
	}
	
	function decodeMsg() {
		let encodedMsg = outputTextArea.value;

		let decodedMsg = '';
		for (let ch of encodedMsg) {
			decodedMsg += String.fromCharCode((ch.charCodeAt() - 1));
		}

		outputTextArea.value = decodedMsg;
	}
	
}