function solve(array, sortingCriteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination,
            this.price = price,
            this.status = status
        }
    }

    let tickets = array.map(e => {
        let elementArgs = e.split('|');

        let destination = elementArgs[0];
        let price = Number(elementArgs[1]);
        let status = elementArgs[2];

        return new Ticket(destination, price , status);  
    });

    tickets.sort((a, b) => {
        let propObjOne = a[sortingCriteria];
        let propObjTwo = b[sortingCriteria];

        let propTypeObjtOne = typeof(propObjOne);
        let propTypeObjTwo = typeof(propObjTwo);

        if (propTypeObjTwo === 'string' && propTypeObjTwo === 'string') {
            return propObjOne.localeCompare(propObjTwo);
        } else {
            return propObjOne - propObjTwo;
        }
    });
    
    // switch (sortingCriteria) {
    //     case 'destination':
    //         tickets.sort((a, b) => a.destination.localeCompare(b.destination));            
    //         break;

    //     case 'price':
    //         tickets.sort((a, b) => a.price - b.price);            
    //         break;

    //     case 'status':
    //         tickets.sort((a, b) => a.status.localeCompare(b.status));            
    //         break;
    // }

    return tickets;   
}

console.log(solve(
    ['Philadelphia|94.20|available',
 'New York City|95.99|available',
 'New York City|95.99|sold',
 'Boston|126.20|departed'],
'destination'

));
