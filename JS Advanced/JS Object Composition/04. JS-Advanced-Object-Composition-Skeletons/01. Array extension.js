(function arrayExtension () {
    Array.prototype.last = function() {
        return this.length === 0
            ? 'Array is empty!'
            : this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        if (n > this.length || this.length - n <= 0) {
            return 'Cannot skip that many elements!';
        } else {
            return this.slice(n);
        }
    };

    Array.prototype.take = function (n) {
        if (n > this.length) {
            return 'Cannot take that many elements, because the array is smaller!';
        } else {
            return this.slice(0, n);
        }
        
    };

    Array.prototype.sum = function () {
        if (this.length === 0) {
            return 'Array is empty!';
        } else {
            return this.reduce((a, b) => a + b);
        }        
    };

    Array.prototype.average = function () {
        return this.length === 0 
            ?  0
            :  this.sum() / this.length      
    };
})();