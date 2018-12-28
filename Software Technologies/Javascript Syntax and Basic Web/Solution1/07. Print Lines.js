function PrintLines(input) {
  for (let i = 0; i < input.length; i++) {
    if (input[i] == 'Stop')
      break;
    else
      console.log(input[i]);
  }
}

PrintLines(['kor', 'das', 'Stop', 'pred']);
