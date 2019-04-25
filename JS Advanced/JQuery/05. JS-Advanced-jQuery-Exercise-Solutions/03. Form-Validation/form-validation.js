function validate() {
	
	$('#company').click(function() {
		let companyInfo = $('#companyInfo');

		if (companyInfo.css('display') === 'none') {
			companyInfo.css('display', 'block');
		} else {
			companyInfo.css('display', 'none');
		}
	});

	$('#submit').click(onSubmit);

	function onSubmit() {
		event.preventDefault();

		let allValid = true;
		let username = $('#username').val();
		let email = $('#email').val();
		let password = $('#password').val();
		let confirmPassword = $('#confirm-password').val();
			
		let usernamePattern = /^[a-zA-Z0-9]{3,20}$/;
		let emailPattern = /^.+\@.+\..+$/;
		let passwordPattern = /^\w{5,15}$/;
		let isCompany = $('#company').css('display') === 'block';

		if (!usernamePattern.test(username)) {
			$('#username').css('border-color', 'red');
			allValid = false;
		} else {
			$('#username').css('border-color', '');
		}

		if (!emailPattern.test(email)) {
			$('#email').css('border-color', 'red');
			allValid = false;
		} else {
			$('#email').css('border-color', '');
		}

		if (!passwordPattern.test(password)) {
			$('#password').css('border-color', 'red');			
			allValid = false;
		} else {
			$('#password').css('border-color', '');	
		}

		if (!passwordPattern.test(confirmPassword) || password !== confirmPassword) {
			$('#confirm-password').css('border-color', 'red');
		} else {
			$('#confirm-password').css('border-color', '');
		}

		if (isCompany) {
			let companyNumber = $('#companyNumber').val();

			if (companyNumber < 1000 || companyNumber > 9999) {
				$('#companyNumber').css('border-color', 'red');
				allValid = false;
			} else {
				$('#companyNumber').css('border-color', '');
			}
		}

		if (allValid) {
			$('#valid').css('display', 'block');
		} else {
			$('#valid').css('display', 'none');
		}
	}	
}
