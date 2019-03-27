const assert = require('chai').assert;
const expect = require('chai').expect;
const isOddOrEven = require('../02. Even Or Odd');

describe('isOddOrEven', function() {

    it('with a number parameter, should return undefined', function() {
        assert.equal(isOddOrEven(1), undefined, 
            'Function did not return the correct result!');
    })

    it('with a object parameter, should return undefined', function() {
        assert.equal(isOddOrEven({}), undefined,
            'Function did not return the correct result!');
    });

    it('with an even length string, should return correct result', function() {
        assert.equal(isOddOrEven('roar'), 'even',
            'Function did not return the correct result!');
    });
      
    it('with an odd length string, should return correct result', function() {
        assert.equal(isOddOrEven('pesho'), 'odd',
            'Function did not return the correct result!');
    });

    it('with multiple consecutive checks, should return correct values', function() {
        expect(isOddOrEven('Cat')).to.equal('odd',
            'Function did not return the correct result!');
        expect(isOddOrEven('alabala')).to.equal('odd',
            'Function did not return the correct result!');
        expect(isOddOrEven('is it even')).to.equal('even',
            'Function did not return the correct result!');
    });
});