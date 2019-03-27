const Warehouse = require('../09. Warehouse').Warehouse;
const expect = require('chai').expect;
const assert = require('chai').assert;

describe('Warehouse Tests', function() {
    // let warehouse;

    // beforeEach(function() {
    //     warehouse = new Warehouse();
    // });

    it('Initialized with negative number, throws message', function() {
        assert.equal(() => {new Warehouse(-1)}, 'Invalid given warehouse space');
    });
    
});