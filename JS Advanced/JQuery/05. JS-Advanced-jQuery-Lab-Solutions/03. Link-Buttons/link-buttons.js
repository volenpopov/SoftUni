function attachEvents() {
    let btns = $('a.button');

    btns.each(function() {        
        $(this).click(function() {
            btns.removeClass('selected');
            $(this).addClass('selected');
        })
    })
                
}