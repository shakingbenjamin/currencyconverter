import React from 'react';
// allows properties to be passed to a user defined class when there's no constructor
export default class FetchWordList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      baseUrl: 'https://localhost:5001/api/currency/',
      fromCode: '',
      fromAmount: '',
      toCode: '',
      hasResponse: false,
      response: '',
      isAlt: false,
    };

    this.handleSubmit = this.handleSubmit.bind(this);
  }

  async handleSubmit(event) {
    event.preventDefault();
    const url = `${this.state.baseUrl}getliveconversion?fromCode=${this.state.fromCode}&fromAmount=${this.state.fromAmount}&toCode=${this.state.toCode}`;
    const response = await fetch(url, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
      },
    });

    var dto = await response.json();
    console.log(dto);

    this.setState({
      response: `${dto.amount}${dto.fromCode} to ${dto.toCode} at a rate of ${dto.rate} is ${dto.result}${dto.toCode}`,
      hasResponse: true,
    });
  }

  handleChange(event, name) {
    this.setState({
      [name]: event.target.value,
    });
  }

  render() {
    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          <label htmlFor="fromCode">
            Enter the currency code to convert from:
          </label>
          <input
            type="text"
            value={this.state.fromCode}
            onChange={(e) => this.handleChange(e, 'fromCode')}
          />
          <br />
          <label htmlFor="fromAmount">
            Enter the amount you wish to convert:
          </label>
          <input
            type="text"
            value={this.state.fromAmount}
            onChange={(e) => this.handleChange(e, 'fromAmount')}
          />
          <br />
          <label htmlFor="toCode">Enter the currecny code to convert to:</label>
          <input
            type="text"
            value={this.state.toCode}
            onChange={(e) => this.handleChange(e, 'toCode')}
          />
          <br />
          <button>Convert</button>
          <br />
          <strong>
            {!this.state.hasResponse
              ? 'Please enter a conversion.'
              : this.state.response}
          </strong>
        </form>
      </div>
    );
  }
}
