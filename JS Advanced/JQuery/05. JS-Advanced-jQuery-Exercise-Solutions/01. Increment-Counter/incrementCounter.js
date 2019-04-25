function increment(selector) {
    let container = $(`${selector}`);
    
    let area = $('<textarea>');
    area.addClass('counter');
    area.attr('disabled', true);
    area.val(0);

    let incrementBtn = $('<button>');
    incrementBtn.addClass('btn');
    incrementBtn.attr('id', 'incrementBtn');
    incrementBtn.text('Increment');

    let addBtn = $('<button>');
    addBtn.addClass('btn');
    addBtn.attr('id', 'addBtn');
    addBtn.text('Add');

    let list = $('<ul>');
    list.addClass('results');

    container.append(area);
    container.append(incrementBtn);
    container.append(addBtn);
    container.append(list);

    $('#incrementBtn').click(onIncrementClick);
    $('#addBtn').click(onAddClick);
    

    function onIncrementClick() {
        let currentCounter = +$('textarea.counter').val();
        $('textarea.counter').val(currentCounter + 1);
    }

    function onAddClick() {
        let currentCounter = +$('textarea.counter').val();
        let li = $('<li>');
        li.text(currentCounter);

        $('ul.results').append(li);
    }
}
