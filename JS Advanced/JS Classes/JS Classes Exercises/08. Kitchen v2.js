class Kitchen {
    constructor(budget) {
        this.budget = Number(budget);
        this.productsInStock = {};   
        this.menu = {};     
        this.actionsHistory = [];
    }

    loadProducts(products) {
        for (let prod of products) {
            let prodArgs = prod.split(' ');

            let productName = prodArgs[0];
            let productQuantity = Number(prodArgs[1]);
            let price = Number(prodArgs[2]);

            if (this.budget >= price) {
                
                if (this.productsInStock[productName]) {
                    this.productsInStock[productName] += productQuantity;
                } else {
                    this.productsInStock[productName] = productQuantity;
                }

                this.budget -= price;
                
                this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);                
            } else {
                this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);                
            }
        }

        return this.actionsHistory.join('\n');        
    }

    addToMenu(meal, neededProducts, price) {
        let result = '';

        if (!this.menu[meal]) {
            this.menu[meal] =  {
                products: neededProducts,
                price: Number(price)    
            }

            result =
                `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        } else {
            result =`The ${meal} is already in our menu, try something different.`;
        }

        return result;
    }

    showTheMenu() {
        let result = '';

        for (let meal of Object.keys(this.menu)) {
            result += `${meal} - $ ${this.menu[meal].price}\n`;
        }

        if (result.length === 0) {
            result = 'Our menu is not ready yet, please come later...';
        }

        return result;
    }

    makeTheOrder(meal) {
        let currentMeal = this.menu[meal];

        let message = '';

        if (currentMeal === undefined) {
            message = `There is not ${meal} yet in our menu, do you want to order something else?`;
        } else {
            for (let product of currentMeal.products) {
                let productArgs = product.split(' ');  

                let productName = productArgs[0];
                let productQuantity = Number(productArgs[1]);
                
                let currentProduct = this.productsInStock[productName];

                if ( currentProduct === undefined || currentProduct < productQuantity) {
                    message = `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                    break;
                }
            }
            
            if (message === '') {
                for (let product of currentMeal.products) {
                    let productArgs = product.split(' ');
    
                    let productName = productArgs[0];
                    let productQuantity = Number(productArgs[1]);
    
                    this.productsInStock[productName] -= productQuantity;
                }
    
                this.budget += currentMeal.price;
    
                message = `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${currentMeal.price}.`;            
            }
        }
        return message;
    }
}

let kitchen = new Kitchen (1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.loadProducts(['Tomatoes 10 5']));

console.log(kitchen.productsInStock);

console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));

console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());
console.log(kitchen.productsInStock);

console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.productsInStock);

console.log(kitchen.makeTheOrder('frozenYogurt'));
