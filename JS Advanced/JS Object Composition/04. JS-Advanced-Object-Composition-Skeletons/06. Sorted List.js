    function SortedList() {

        let obj = (() => {
            let list = [];
        
            let add = function(element) {
                list.push(element);
                this.size++;
                return list.sort((a, b) => a - b);
            };
        
            let remove=  function(index) {
                if (index < 0 || index > list.length - 1) {
                    throw 'Index out of range!';
                } else {
                    list.sort((a, b) => {a - b});
                    list.splice(index, 1);
                    this.size--;
                    return list;
                }
            };
        
            let get = function(index) {
                if (index < 0 || index > list.length - 1) {
                    throw 'Index out of range!';
                }
        
                list.sort((a, b) => a - b);
                return list[index];                
            };
        
            let size = list.length;

            return {add, remove, get, size};
        })();

        return obj;
    }
