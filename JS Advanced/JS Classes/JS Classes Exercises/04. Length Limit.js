function solve() {
    class Stringer {
        constructor(string, length) {
            this.innerString = string,
            this.innerLength = Number(length)
        }

        increase(length) {
            this.innerLength += length;
        }

        decrease(length) {
            this.innerLength -= length;

            if (this.innerLength < 0) {
                this.innerLength = 0;
            }
        }

        toString() {
            let result = '';

            if (this.innerLength === 0) {
                result = '...';
            }
            if (this.innerString.length > this.innerLength) {
                result = this.innerString
                    .substr(0, this.innerLength) + '...';
            }

            return result;
        }
    }
}