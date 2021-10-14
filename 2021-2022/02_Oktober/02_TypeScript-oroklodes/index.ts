interface IEmber {
    hajszin: string;
    koszones(): void;
  }
  
  class Ember implements IEmber {
    hajszin: string;
    szemekSzama: number;
    nev: string;
  
    koszones(): void {
      console.log(`Szia, ${this.nev} vagyok.`);
    }
  
    constructor(nev: string) {
      this.szemekSzama = 2;
      this.nev = nev;
    }
  }
  
  class Boxolo extends Ember {
    constructor(nev: string) {
      super(nev);
      this.koszones();
    }
  }
  
  class Lacika extends Boxolo {
    sargaLapos: boolean;
  
    constructor() {
      super('Lacika');
      this.sargaLapos = Math.random() > 0.5;
    }
  
    koszones(): void {
      console.log(`Csá tesám, van egy százasod?`);
    }
  }
  
  var lacika = new Lacika();
  console.log(lacika);
  
  var boxolo = new Boxolo('Géza');
  