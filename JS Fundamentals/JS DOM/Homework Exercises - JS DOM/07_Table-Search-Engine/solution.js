function solve() {
    document.getElementById('searchBtn').addEventListener('click', search);

    function search() {
        
        let searchInput = document.getElementById('searchField').value;
        let searchPattern = new RegExp(searchInput.toLowerCase());
        
        let tblRows = document.getElementsByTagName('tbody')[0].children;
        
        Array.from(tblRows).forEach((row) => row.classList.remove('select'));

        for (let row of tblRows) {
            
            let columns = row.children;

            for (let col of columns) {
                let word = col.textContent.toLowerCase();

                if (word.match(searchPattern)) {
                    row.classList.add('select');
                }
            }            
        }
        document.getElementById('searchField').value = '';
    }
   
}