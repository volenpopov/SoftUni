function initializeTable() {
    $('#createLink').click(createCountry);
    
    addCountry('Bulgaria', 'Sofia');
    addCountry('Germany', 'Berlin');
    addCountry('Russia', 'Moscow');

    function createCountry() {
        addCountry($('#newCountryText').val(), $('#newCapitalText').val());

        $('#newCountryText').val('');
        $('#newCapitalText').val('');
        fixRowLinks();
    }

    function addCountry(country, capital) {
        if (country && capital) {
            let row = $('<tr>')
            .append($('<td>').text(country))
            .append($('<td>').text(capital))
            .append($('<td>')
                .append($('<a href=\'#\'>[Up]<a/>').click(moveRowUp))
                .append($('<a href=\'#\'>[Down]<a/>').click(moveRowDown))
                .append($('<a href=\'#\'>[Delete]<a/>').click(deleteRow)));

        row.css('display', 'none');
        $('#countriesTable').append(row);
        row.fadeIn();
        fixRowLinks();
        }        
    }

    function moveRowUp() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.insertBefore(row.prev());
            row.fadeIn();
            fixRowLinks();
        });
    }

    function moveRowDown() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.insertAfter(row.next());
            row.fadeIn();
            fixRowLinks();
        });
    }

    function deleteRow() {
        let row = $(this).parent().parent().remove();
        fixRowLinks();
    }

    function fixRowLinks() {
        $('#countriesTable a').css('display', 'inline');

        let tableRows = $('#countriesTable tr');
        $('#countriesTable tr:nth-child(3)').find("a:contains('Up')").css('display', 'none');
        $('#countriesTable tr:last-child').find("a:contains('Down')").css('display', 'none');
    }
}