export interface IPlants {
    hasRoot: boolean;
    height: number;
    getHeight(): number;
}

export class Plant implements IPlants {
    hasRoot: boolean;
    height: number;

    constructor() {
        this.height = this.getHeight();
        this.hasRoot = this.height > 28;
    }

    getHeight(): number {
        return Math.floor(Math.random() * (30 - 20) + 20);
    }
}

export class Tree extends Plant {
    name: string;

    constructor(name: string) {
        super();
        this.name = name;
    }

    getDescription(): string {
        return `Én egy ${this.name} vagyok, ${this.height} magas és ${
            this.hasRoot ? 'van' : 'nincs'
            } gyökerem.`;
    }
}

const trees: string[] = [
    'Cseresznyefa',
    'Almafa',
    'Körtefa',
    'Banánfa',
    'Citromfa',
];

for (let i = 0; i < 100; i++) {
    let randomSzam = Math.floor(Math.random() * trees.length);
    let fa = new Tree(trees[randomSzam]);
    let p = document.createElement('p');
    p.textContent = fa.getDescription();
    document.body.appendChild(p);
}
