class BookCollection {
    constructor(shelfGenre, room, shelfCapacity) {
        this.shelfGenre = shelfGenre;
        this.room = room;
        this.shelfCapacity = shelfCapacity;
        this.shelf = [];

        return this;
    }

    get room() {
        return this._room;
    }

    set room(value) {
        switch (value) {
            case 'livingRoom':
            case 'bedRoom':
            case 'closet':
                this._room = value;
                break;
            default:
                throw `Cannot have book shelf in ${value}`;
        }
    }

    addBook(bookName, bookAuthor, genre) {
        if (this.shelfCondition <= 0) {
            this.shelf.shift();
        }

        this.shelf.push({
            bookName,
            bookAuthor,
            genre
        });

        this.shelf.sort((x, y) => x.bookAuthor.localeCompare(y.bookAuthor));

        return this;
    }

    throwAwayBook(bookName) {
        let book = this.shelf.find(b => b.bookName === bookName);

        if (book) {
            let indexOfBook = this.shelf.indexOf(book);
            this.shelf.splice(indexOfBook, 1);
        }        

        return this;
    }

    showBooks(genre) {
        let result = `Results for search "${genre}":\n`;

        let resultBookset = this.shelf.filter(b => b.genre === genre);

        for (const book of resultBookset) {
            result += `\uD83D\uDCD6 ${book.bookAuthor} - "${book.bookName}"\n`;
        }

        return result.trim();
    }

    get shelfCondition() {
        return this.shelfCapacity - this.shelf.length;
    }

    toString() {
        let result;

        if (this.shelf.length === 0) {
            result = `It's an empty shelf`;
        } else {
            result = `"${this.shelfGenre}" shelf in ${this.room} contains:\n`;

            for (const book of this.shelf) {
                result += `\uD83D\uDCD6 "${book.bookName}" - ${book.bookAuthor}\n`;
            }
        }

        return result.trim();
    }
}



