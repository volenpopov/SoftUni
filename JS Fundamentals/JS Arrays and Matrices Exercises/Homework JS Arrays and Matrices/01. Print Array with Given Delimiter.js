function main(input) {
    let arr = input.slice(0, input.length - 1);
    let delimeter = input[input.length - 1];

    console.log(arr.join(delimeter));
}

main(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']);