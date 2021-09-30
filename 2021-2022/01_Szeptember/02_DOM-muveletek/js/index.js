// let gomb = document.getElementsByTagName("button")[0];
let gomb = document.getElementById("gombocska");

gomb.style.backgroundColor = "#0000FF";

function hibauzenet() {
    alert("Ügyes voltál!");
}

setTimeout(() => {
    hibauzenet();
}, 5000);