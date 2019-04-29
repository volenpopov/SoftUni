function addItem() {
    let inputText = document.getElementById('newItemText');
    let inputValue = document.getElementById('newItemValue');

    let newOption = document.createElement('option');
    newOption.text = inputText.value;
    newOption.value = inputValue.value;

    inputText.value = '';
    inputValue.value = '';
        
    document.getElementById('menu')
        .appendChild(newOption);        
}