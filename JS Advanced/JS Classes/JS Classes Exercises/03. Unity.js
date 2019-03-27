function solve() {
    class Rat {
        constructor(name) {
            this.name = name,
            this.unitedRats = []
        }
    
        unite(otherRat) {
            if (otherRat instanceof Rat) {
                this.unitedRats.push(otherRat);
            }
        } 
    
        getRats() {
            return this.unitedRats;
        }
    
        toString() {
            let result = `${this.name}`;
    
            let otherRats = this.getRats();
            if (otherRats.length > 0) {
                for (let rat of otherRats) {
                    result += `\n##${rat.name}`;
                }
            }
    
            return result;
        }
    }

    let rat = new Rat('Pesho');

    console.log(rat.getRats());
    

    rat.unite(new Rat('Gosho'));
    rat.unite(new Rat('Sasho'));

    console.log(rat.toString());    
}

solve();