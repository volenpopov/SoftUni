class SortedList {
    constructor() {
        this.elements = [];
        this.size = 0;
    }

    add(element) {
        this.elements.push(element);        
        this.size++;
        this.elements.sort((a, b) => a - b);

        return this.elements;
    }

    remove(index) {
        if (index >= 0 && index <= this.elements.length - 1 && this.size > 0) {
            this.elements.splice(index, 1);    
            this.size--;
            this.elements.sort((a, b) => a - b);
    
        }
               
        return this.elements;
    }

    get(index) {
        if (index >= 0 && index <= this.elements.length - 1 && this.size > 0) {
            return this.elements[index];  
        }
    }  
}

let list = new SortedList();

console.log(list.get(0));


