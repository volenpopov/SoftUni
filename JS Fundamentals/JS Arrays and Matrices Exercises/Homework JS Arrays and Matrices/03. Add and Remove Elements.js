function Main(commands) {
    let num = 1;
    let arr = [];

    for (let index = 0; index < commands.length; index++) {
        let command = commands[index];

        switch (command) {
            case 'add':
                arr.push(num);
                break;

            case 'remove':
                arr.pop();
                break;
        }
        num++;
    }

    arr.length === 0 ? console.log('Empty') : console.log(arr.join('\n'));
}

Main(['add', 
'add', 
'add', 
'add']
);