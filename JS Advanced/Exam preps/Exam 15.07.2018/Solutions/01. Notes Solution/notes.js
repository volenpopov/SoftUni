function addSticker() {
    let stickerList = document.getElementById('sticker-list');

    let titleEl = document.querySelector('input.title');
    let contentEl = document.querySelector('input.content');
    
    let title = titleEl.value;
    let content = contentEl.value;
    
    if (title && content) {
        createNote(title, content);
        resetInput();                
    }
    
    function resetInput() {
        titleEl.value = '';
        contentEl.value = '';
    };

    function createNote(title, content) {
        let li = document.createElement('li');
        li.classList.add('note-content');

        let a = document.createElement('a');
        a.classList.add('button');
        a.textContent = 'x';

        a.addEventListener('click', function() {
            stickerList.removeChild(li);
        });

        let h2 = document.createElement('h2');
        h2.textContent = title;

        let hr = document.createElement('hr');

        let p = document.createElement('p');
        p.textContent = content;

        li.appendChild(a);
        li.appendChild(h2);
        li.appendChild(hr);
        li.appendChild(p);

        stickerList.appendChild(li);
    }
}