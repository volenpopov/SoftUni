function main() {
    let arr = [];
    
    let person = 
    {
        Name : 'Pesho',
        Age : 25 
    };

    let person2 = 
    {
        Name : 'Pesho',
        Age : 25 
    };

    arr.push(person);
    arr.push(person2);

    console.log(arr.filter(p => p.Name === 'Pesho').length);
    
}

main();