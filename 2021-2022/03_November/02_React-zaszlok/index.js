import React from 'react';
import './style.css';

export default class App extends React.Component {
  constructor() {
    super();
    this.state = {
      countries: [],
    };
  }

  async componentDidMount() {
    let response = await fetch('https://restcountries.com/v3.1/all');
    let data = await response.json();

    this.setState({ countries: data });
  }

  render() {
    return (
      <div>
        {this.state.countries.length > 0
          ? this.state.countries.map((country) => {
              return <Country country={country} />;
            })
          : 'Betöltés...'}
      </div>
    );
  }
}

function Country(props) {
  return (
    <div>
      {props.country.name.official}{' '}
      <img height="20" src={props.country.flags.png} />
    </div>
  );
}
