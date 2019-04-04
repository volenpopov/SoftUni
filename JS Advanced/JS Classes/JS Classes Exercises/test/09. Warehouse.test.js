const Warehouse = require('../09. Warehouse');
const expect = require('chai').expect;
const assert = require('chai').assert;

describe('Warehouse Tests', function() {
    
    describe('Constructor tests', function() {

        it('Initialized with an input with type string, throws message', function() {            
            expect(() => {new Warehouse('a')}).throws("Invalid given warehouse space");
        });

        it('Initialized with an input with type obj, throws message', function() {            
            expect(() => {new Warehouse({})}).throws("Invalid given warehouse space");
        });
                
    });

    describe('OccupiedCapacity tests', function() {
        let warehouse;

        beforeEach(function() {
            warehouse = new Warehouse(50);
        });

        it('Occupied capacity should equal zero, if no products have been added yet', function() {
            expect(warehouse.occupiedCapacity()).to.be.equal(0);
        });

        it('Occupied capacity should equal the quantity of the first added product, which is Food', function() {
            warehouse.addProduct('Food', 'Bananas', 3);
            expect(warehouse.occupiedCapacity()).to.be.equal(3);
        });

        it('Occupied capacity should equal the quantity of the first added product, which is Drink', function() {
            warehouse.addProduct('Drink', 'Water', 5);
            expect(warehouse.occupiedCapacity()).to.be.equal(5);
        });

        it('Occupied capacity should equal the sum of quantities of all products added, which are all Food', function() {
            warehouse.addProduct('Food', 'Bananas', 3);
            warehouse.addProduct('Food', 'Peanuts', 3);
            expect(warehouse.occupiedCapacity()).to.be.equal(6);
        });

        it('Occupied capacity should equal the sum of quantities of all products added, which are all Drink', function() {
            warehouse.addProduct('Drink', 'Water', 5);
            warehouse.addProduct('Drink', 'Cola', 4);
            expect(warehouse.occupiedCapacity()).to.be.equal(9);
        });

        it('Occupied capacity should equal the sum of quantities of all products added, both Food and Drink', function() {
            warehouse.addProduct('Food', 'Burger', 10);
            warehouse.addProduct('Drink', 'Cola', 20);
            expect(warehouse.occupiedCapacity()).to.be.equal(30);
        });

        it('Occupied capacity should equal the sum of quantities of all products added, both many Food and many Drink', function() {
            warehouse.addProduct('Food', 'Burger', 10);
            warehouse.addProduct('Food', 'Pizza', 10);
            warehouse.addProduct('Food', 'Ice cream', 5);
            warehouse.addProduct('Drink', 'Cola', 4);
            warehouse.addProduct('Drink', 'Water', 6);
            warehouse.addProduct('Drink', 'Juice', 5);
            expect(warehouse.occupiedCapacity()).to.be.equal(40);
        });

        it('Occupied capacity should be negative, if negative quantity of product is added', function() {
            warehouse.addProduct('Food', 'Meat', -5)
            expect(warehouse.occupiedCapacity()).to.be.equal(-5);
        });

    });

    describe('AddProduct tests', function() {
        let warehouse;

        beforeEach(function() {
            warehouse = new Warehouse(50);
        });

        it('Add products should return the first added Food product', function() {

            expect(JSON.stringify(warehouse.addProduct('Food', 'Bananas', 5)))
            .to.be.equal(JSON.stringify({'Bananas': 5}));
        });

        it('Add products should return the first added Drink product', function() {

            expect(JSON.stringify(warehouse.addProduct('Drink', 'Water', 5)))
            .to.be.equal(JSON.stringify({'Water': 5}));
        });

        it('Add products should return the sum of quantities for one product when it is added multiple times, type Food', function() {
            warehouse.addProduct('Food', 'Bananas', 5);
            warehouse.addProduct('Food', 'Bananas', 5);

            expect(JSON.stringify(warehouse.addProduct('Food', 'Bananas', 5)))
            .to.be.equal(JSON.stringify({'Bananas': 15}));
        });

        it('Add products should return the sum of quantities for one product when it is added multiple times, type Drink', function() {
            warehouse.addProduct('Drink', 'Water', 5);
            warehouse.addProduct('Drink', 'Water', 5);

            expect(JSON.stringify(warehouse.addProduct('Drink', 'Water', 5)))
            .to.be.equal(JSON.stringify({'Water': 15}));
        });

        it('Add products should return all products of its type and their total quantity', function() {
            warehouse.addProduct('Food', 'Bananas', 5);
            warehouse.addProduct('Food', 'Pizza', 7);
            warehouse.addProduct('Food', 'Pizza', 1);
            
            expect(JSON.stringify(warehouse.addProduct('Food', 'Burger', 9)))
            .to.be.equal(JSON.stringify({
                'Bananas': 5,
                'Pizza': 8,
                'Burger': 9
            }));
        });

        it('Add product should throw message when trying to add first product above the capacity', function() {
            assert.throws(() => {warehouse.addProduct('Food', 'Bananas', 51)},
            'There is not enough space or the warehouse is already full');
        });

        it('Add product should throw message when trying to add existing products of a certain type above the capacity, Food', function() {
            warehouse.addProduct('Food', 'Bananas', 49)

            assert.throws(() => {warehouse.addProduct('Food', 'Bananas', 2)},
            'There is not enough space or the warehouse is already full');
        });

        it('Add product should throw message when trying to add existing products of a certain type above the capacity, Drink', function() {
            warehouse.addProduct('Drink', 'Water', 49)

            assert.throws(() => {warehouse.addProduct('Drink', 'Water', 2)},
            'There is not enough space or the warehouse is already full');
        });

        it('Add product should throw message when trying to add products from different types above the capacity', function() {
            warehouse.addProduct('Food', 'Bananas', 49)

            assert.throws(() => {warehouse.addProduct('Drink', 'Water', 2)},
            'There is not enough space or the warehouse is already full');
        });
    });

    describe('OrderProducts tests', function() {
        let warehouse;

        beforeEach(function() {
            warehouse = new Warehouse(50);
        });

        it('Sorts products of given type Food descending by quantity', function() {
            warehouse.addProduct('Food', 'Meat', 3);
            warehouse.addProduct('Food', 'Pizza', 6);
            warehouse.addProduct('Food', 'Veggies', 12);
            warehouse.addProduct('Food', 'Apples', 1);

            assert.equal(JSON.stringify(warehouse.orderProducts('Food')),
            JSON.stringify({
                'Veggies': 12,
                'Pizza': 6,
                'Meat': 3,
                'Apples': 1
            }));
        });

        it('Sorts products of given type Drink descending by quantity', function() {
            warehouse.addProduct('Drink', 'Meat', 3);
            warehouse.addProduct('Drink', 'Pizza', 6);
            warehouse.addProduct('Drink', 'Veggies', 12);
            warehouse.addProduct('Drink', 'Apples', 1);

            assert.equal(JSON.stringify(warehouse.orderProducts('Drink')),
            JSON.stringify({
                'Veggies': 12,
                'Pizza': 6,
                'Meat': 3,
                'Apples': 1
            }));
        });

        it('When given invalid type, throws TypeError with message', function() {
            assert.throws(() => {warehouse.orderProducts('invalid')}, 
            TypeError, 'Cannot convert undefined or null to object');
        });
    });

    describe('Revision tests', function() {
        let warehouse;

        beforeEach(function() {
            warehouse = new Warehouse(50);
        });

        it ('When warehouse is empty should return message', function() {
            assert.equal(warehouse.revision(), 'The warehouse is empty');
        });

        it('Returns correct string when we have 1 product of Food', function() {
            warehouse.addProduct('Food', 'Pizza', 3);

            assert.equal(warehouse.revision(), 
            'Product type - [Food]\n- Pizza 3\nProduct type - [Drink]');
        });

        it('Returns correct string when we have 1 product of Drink', function() {
            warehouse.addProduct('Drink', 'Water', 5);

            assert.equal(warehouse.revision(), 
            'Product type - [Food]\nProduct type - [Drink]\n- Water 5');
        });

        it('Returns correct string when we have multiple products of Food', function() {
            warehouse.addProduct('Food', 'Pizza', 5);
            warehouse.addProduct('Food', 'Burger', 2);

            assert.equal(warehouse.revision(), 
            'Product type - [Food]\n- Pizza 5\n- Burger 2\nProduct type - [Drink]');
        });

        it('Returns correct string when we have multiple products of Drink', function() {
            warehouse.addProduct('Drink', 'Water', 1);
            warehouse.addProduct('Drink', 'Cola', 4);

            assert.equal(warehouse.revision(), 
            'Product type - [Food]\nProduct type - [Drink]\n- Water 1\n- Cola 4');
        });

        it('Returns correct string when we have multiple products of both Food and Drink', function() {
            warehouse.addProduct('Food', 'Pizza', 5);
            warehouse.addProduct('Food', 'Burger', 2);
            warehouse.addProduct('Drink', 'Water', 1);
            warehouse.addProduct('Drink', 'Cola', 4);

            assert.equal(warehouse.revision(), 
            'Product type - [Food]\n- Pizza 5\n- Burger 2\nProduct type - [Drink]\n- Water 1\n- Cola 4');
        });

    });

    describe("ScrapeAProduct tests", function() {
        let warehouse;

        beforeEach(function() {
            warehouse = new Warehouse(50);
        });

        it('Scraping an unavailable product should throw message', function() {
            let product = 'invalidProductName';

            assert.throws(() => {warehouse.scrapeAProduct(product)},
            `${product} do not exists`);    
        });

        it('Scraping a product of type Food should reduce its quantity by the input amount, which is not more then the total quantity of the product', function() {
            warehouse.addProduct('Food', 'Pizza', 5);
            let scrapeOutput = JSON.stringify(warehouse.scrapeAProduct('Pizza', 1));
            let result = JSON.stringify({'Pizza': 4});

            assert.equal(scrapeOutput, result);
        });

        it('Scraping a product of type Food should reduce its quantity to zero, when the input amount is more than the available quantity', function() {
            warehouse.addProduct('Food', 'Pizza', 5);
            let scrapeOutput = JSON.stringify(warehouse.scrapeAProduct('Pizza', 15));
            let result = JSON.stringify({'Pizza': 0});

            assert.equal(scrapeOutput, result);
        });

        it('Scraping a product of type Food with zero scraping quantity should not reduce the product amount', function() {
            warehouse.addProduct('Food', 'Pizza', 5);
            let scrapeOutput = JSON.stringify(warehouse.scrapeAProduct('Pizza', 0));
            let result = JSON.stringify({'Pizza': 5});

            assert.equal(scrapeOutput, result);
        });

        it('Scraping a product of type Food with negative scraping quantity should increase the product amount', function() {
            warehouse.addProduct('Food', 'Pizza', 5);
            let scrapeOutput = JSON.stringify(warehouse.scrapeAProduct('Pizza', -2));
            let result = JSON.stringify({'Pizza': 7});

            assert.equal(scrapeOutput, result);
        });
    });
});
