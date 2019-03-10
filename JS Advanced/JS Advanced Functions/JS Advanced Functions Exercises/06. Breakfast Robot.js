function solve () {
	return (function() {
    
    let robot = 
    {
        protein: 0,
        carbohydrate: 0,
        flavour: 0,
        fat: 0
    };    

    let menu = 
    {
        apple: 
            {
                carbohydrate: 1,
                flavour: 2
            },
        
        coke:
            {
                carbohydrate: 10,
                flavour: 20
            },

        burger:
            {
                carbohydrate: 5,
                flavour: 3,
                fat: 7
            },

        omelet:
            {
                protein: 5,
                fat: 1,
                flavour: 1
            },

        cheverme:
            {
                protein: 10,
                carbohydrate: 10,
                fat: 10,
                flavour: 10,
            },
    };

    return function solve(input) {

        let inputArgs = input.split(' ');
        let command = inputArgs[0];
        
        switch (command) {
            case 'restock':
                robot[inputArgs[1]] += +inputArgs[2];
                return 'Success';
    
            case 'prepare':
                let recipe = inputArgs[1];
                let quantity = +inputArgs[2];
                return prepare(recipe, quantity);

            case 'report':
                return `protein=${robot.protein} carbohydrate=${robot.carbohydrate} fat=${robot.fat} flavour=${robot.flavour}`;
        }
    
        function prepare(recipe, quantity) {
            let ingredients = menu[recipe];
    
            for (let p = 0; p < quantity; p++) {
                let enoughIngredients = true;
    
                for (let i in ingredients) {
                    
                    if (robot[i] - ingredients[i] < 0) {
                        return `Error: not enough ${i} in stock`;             
                    }               
                }
    
                if (enoughIngredients) {
                    for (let i in ingredients) {
                        robot[i] -= ingredients[i]
                     } 
                } else {
                    break;
                }

                if (p === quantity - 1 && enoughIngredients) {
                    return 'Success';                    
                }
            }
        };           
    }

})();
}