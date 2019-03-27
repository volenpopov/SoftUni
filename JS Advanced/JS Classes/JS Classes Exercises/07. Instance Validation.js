class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.setClientId(clientId);
        this.setEmail(email);
        this.setFirstName(firstName);
        this.setLastName(lastName);
        this.products = [];
    }

    setClientId(id) {
        let idPattern = /^\d{6}$/;

        if (!idPattern.test(id)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this.clientId = id;
    }

    setEmail(email) {
        let emailPattern = /^(\w+?)@([a-zA-Z]+|\.+?)+?$/;

        if (!emailPattern.test(email)) {
            throw new TypeError('Invalid e-mail');
        }

        this.email = email;
    }
    
    checkName(name, nameToUse) {
        let nameToUseInError = nameToUse === 'firstName'
            ? 'First name'
            : 'Last name';

        let namePattern = /^[a-zA-Z]+$/;

        if (name.length < 3 || name.length > 20) {
            throw new TypeError(`${nameToUseInError} must be between 3 and 20 characters long`);
        } else if (!namePattern.test(name)) {
            throw new TypeError(`${nameToUseInError} must contain only Latin characters`);
        }
    }

    setFirstName(name) {
        if (this.checkName(name, 'firstName')) {
            this.firstName = name;
        }
    }

    setLastName(name) {
        if (this.checkName(name, 'lastName')) {
            this.lastName = name;
        }
    }
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov');
