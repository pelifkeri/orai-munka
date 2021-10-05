for (let i = 0; i < 10; i++) {
    let button = document.createElement("button");
    button.textContent = "vmi";
    button.style.marginRight = "20px";
    document.body.appendChild(button);
}

// helyezzünk fel 10 darab <li> elementet
// a textContent-je legyen valami tetszőleges string
// és a string végéhez legyen hozzáfűzve az index értéke
let lista = document.getElementById("lista");

for (let i = 0; i < 10; i++) {
    let li = document.createElement("li");
    li.textContent = `Valami text ${i}`;
    li.style.color = i % 3 == 0 ? "red" : "black";
    lista.appendChild(li);
}


// 5x5-ös négyzet gombokkal
for (let sor = 0; sor < 5; sor++) {
    let div = document.createElement("div");

    for (let oszlop = 0; oszlop < 5; oszlop++) {
        let button = document.createElement("button");
        button.textContent = "X";
        button.onclick = () => { button.textContent = "O" };
        button.onclick = kattintas.bind(this, button);
        let szamitas = (sor == oszlop) || (sor + oszlop == 4);
        button.style.background = szamitas ? "red" : "white";

        div.appendChild(button);
    }

    document.body.appendChild(div);
}

function kattintas(button) {
    button.textContent = "O";
}