function Main(arr, orderType) {
    if (orderType === 'asc') {
        return arr.sort((a, b) => a - b);
    } else {
        return arr.sort((a, b) => b - a);
    }
};

console.log(Main([14, 7, 17, 6, 8], 'asc'));


// Another option:

// function Main(array) {

//     return function getOtderType(orderType) {
//         if (orderType === 'asc') {
//             return Array.from(array.sort((a, b) => a - b));
//         } else if (orderType === 'desc') {
//             return Array.from(array.sort((a, b) => b - a));
//         } else {
//             return array;
//         }
//     };
// }