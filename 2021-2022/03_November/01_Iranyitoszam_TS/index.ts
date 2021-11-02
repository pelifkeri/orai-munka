let input = document.createElement('input');
document.body.appendChild(input);

let button = document.createElement('button');
button.textContent = 'Keresés';
button.onclick = getPostalCodeDetails;
document.body.appendChild(button);

interface ZipCode {
  name: string;
  places: any[];
}

function getPostalCodeDetails(): void {
  let code = document.getElementsByTagName('input')[0];
  let value = code.value;

  fetch(`https://api.zippopotam.us/hu/${value}`)
    .then((x) => x.json())
    .then((zip: ZipCode) => {
      console.log(zip);
      let place = zip.places[0];
      let p = document.createElement('p');
      p.innerHTML = `Város: ${place['place name']}. Megye: ${place['state']}`;
      document.body.appendChild(p);
    })
    .catch((err) => console.log(err));
}
