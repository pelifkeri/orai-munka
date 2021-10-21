interface Country {
    cioc: string; //3 jegyű kód
    name: { common: string; official: string };
    flags: { png: string };
    region: string;
  }
  
  fetch('https://restcountries.com/v3.1/all')
    .then((x) => x.json())
    .then((countries: Country[]) => {
      countries = countries.filter(x => x.region == "Europe");
      listCountries(countries);
    });
  
  function listCountries(countries: Country[]): void {
    countries.forEach((country: Country) => {
      let p = document.createElement('p');
      p.innerHTML = `<img height="30" src="${country.flags.png}">${country.cioc} - ${country.name.official}`;
      document.body.appendChild(p);
    });
  }
  