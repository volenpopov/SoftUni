(function stringExtension() {    
    String.prototype.ensureStart = function (str) {
        let pattern = new RegExp(`^${str}`);

        if (!this.toString().match(pattern)) {
            return `${str}${this.toString()}`;
        } else {
            return this.toString();
        }
    };

    String.prototype.ensureEnd = function (str) {
        let pattern = new RegExp(`${str}$`);

        if (!this.toString().match(pattern)) {
            return `${this.toString()}${str}`;
        } else {
            return this.toString();
        }
    };

    String.prototype.isEmpty = function () {
        return this.toString().length === 0
            ? true
            : false
    };

    String.prototype.truncate = function (n) {
        let length = this.toString().length;

        if (length <= n) {
            return this.toString();
        } else {
            let arr = this.toString().split(' ');

            if (arr.length > 1) {
                while (true) {                    
                    let newStr = '';
                    arr.pop();

                    for (let str of arr) {
                        newStr += ` ${str}`;
                    }

                    newStr = newStr.trim();

                    if (newStr.length + 3 <= n) {
                        return `${newStr}...`;
                    }
                }
            } else {
                this.toString() = this.toString().substr(0, n - 3);
                if (n < 4) {
                    return `${this.toString()}${'.'.repeat(n)}`; 
                } else {
                    return `${this.toString()}...`;
                }
            }
        }
    };

    String.format = function(str, ...params) {
        let pattern = new RegExp('{[0-9]+?}', 'g');
        let strParamsCount = str.match(pattern).length;
        let iterations = 0;

        if (strParamsCount < params.length) {
            iterations = strParamsCount;
        } else {
            iterations = params.length;
        }

        for (let i = 0; i < iterations; i++) { 
            let regex = new RegExp(`\\{${i}\\}`);           
            str = str.replace(regex, params[i]);
        }

        return str;
    };   
    
})();