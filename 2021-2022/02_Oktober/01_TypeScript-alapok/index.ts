const nevek: string[] = ["Pistike", "Jancsika", "Zolika", "Gézuka", "Gabika", "Józsika", "Norbika", "Dávidka"];
const osztalyok: string[] = ["9/a", "9/b", "10/a", "10/b", "11/a", "11/b", "12/a", "12/b"];

function randomSzamGenerator(min: number, max: number) {
	return Math.floor(Math.random() * (max - min) + min);
}

class Tanulo {
	nev: string;
	kor: number;
	osztaly: string;
	szemuveges: boolean;
	jegyek: number[] = [];
	get nagykoru(): boolean {
		return this.kor >= 18;
	}
	get atlag(): number {
		let osszeg = 0;
		this.jegyek.forEach((x) => (osszeg += x));
		return osszeg / this.jegyek.length;
	}

	constructor() {
		this.nev = nevek[randomSzamGenerator(0, nevek.length)];
		this.kor = randomSzamGenerator(14, 20);
		this.osztaly = osztalyok[randomSzamGenerator(0, osztalyok.length)];
		this.szemuveges = Math.random() > 0.8;
		for (let i = 0; i < 10; i++) {
			this.jegyek.push(randomSzamGenerator(1, 6));
		}
	}
}

let tanulok: Tanulo[] = [];

for (let i = 0; i < 100; i++) {
	let tanulo = new Tanulo();
	tanulok.push(tanulo);
}

tanulok
	.filter((x: Tanulo) => x.nagykoru)
	.forEach((tanulo: Tanulo) => {
		let p = document.createElement("p");
		p.textContent = `${tanulo.nev} a ${tanulo.osztaly} osztályba jár, ${tanulo.kor} éves${tanulo.szemuveges ? " és szemüveges." : "."} Az átlaga ${tanulo.atlag}`;
		document.body.appendChild(p);
	});
