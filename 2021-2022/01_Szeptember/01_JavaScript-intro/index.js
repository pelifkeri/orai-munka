let szoveg = "szoveg";
let szam2 = 2.005;
let hamis = false;
let ojjektum = {
    név: "Tanuló",
    osztály: "13",
    kor: 22
};
let tömb = [szoveg, szam2, hamis, ojjektum];

for (let i = 0; i < tömb.length; i++) {
    const element = tömb[i];
}

tömb.forEach(x => console.log(x));
tömb.filter(x => x > 2);
tömb.find(x => x.id == 22);
tömb.splice(3, 1);
let ujtomb = tömb.map(x => x > 2);


let szamlista = ["string", "string2", "string3"];
// 1. megoldás
szamlista.filter(x => x.startsWith("a"));
// 2. megoldás
for (let i = 0; i < tömb.length; i++) {
    let array = [];
    if (szamlista[i].startsWith("a")) {
        array.push(szamlista[i]);
    }
}

alert("o-ooo");
let valami3 = prompt("valami?");
console.log(valami3);

confirm("biztosan?");