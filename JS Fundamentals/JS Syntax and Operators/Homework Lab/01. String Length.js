function main(a, b, c) {
    let aLength = a.length;
    let bLength = b.length;
    let cLength = c.length;

    let totalLength  = aLength + bLength + cLength;

    console.log(totalLength);
    console.log(Math.floor(totalLength / 3));
}

main('chocolate', 'ice cream', 'cake');
