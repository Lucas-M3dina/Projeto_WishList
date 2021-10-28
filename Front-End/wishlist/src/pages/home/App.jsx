// import './App.css';
import { Component } from "react";

export default class Repositorios extends Component {

  constructor(props) {
    super(props);
    this.state = {
      listaDesejosUsuarios: [],
      Desejo: '',
      IdUsuario: ''
    }
  };

  atualizaEstadoDesejo = async (event) => {
    await this.setState({
      Desejo: event.target.value
    });

    console.log(this.state.Desejo);
  }

  atualizaEstadoIdUsuario = async (event) => {
    await this.setState({
      IdUsuario: event.target.value
    });

    console.log(this.state.IdUsuario);
  }

  buscarDesejos = async (event) => {

    console.log('agora vamos fazer a chamada para a api.')

    fetch('http://localhost:5000/api/Desejo')
      .then(resposta => resposta.json())
      .then(dados => this.setState({ listaDesejosUsuarios: dados }))
      .catch(erro => console.log(erro));

      await console.log(this.state.listaDesejosUsuarios);

      
      
    }

    componentDidMount(){
      this.buscarDesejos();
  }
    
  render() {

    return (
      <div className="App">
        <header className="App-header">
          <h1>I Wish More</h1>
        </header>
        <main>
          <form action="submit">
            <input onChange={this.atualizaEstadoIdUsuario} type="number" placeholder="   Digite seu id" />
            <input onChange={this.atualizaEstadoDesejo} type="text" placeholder="   Digite um desejo" />
            <button type="submit" disabled={this.state.Desejo || this.state.IdUsuario === '' ? 'none' : ''}>+</button>
          </form>

          <h2>Lista de desejos</h2>
          <table>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Desejo</th>
                  <th>Nome</th>
                </tr>
              </thead>
              <tbody>
                {
                  this.state.listaDesejosUsuarios.map((Desejo) => {
                    return (
                      <tr key={Desejo.idDesejo}>
                        <td>{Desejo.idDesejo}</td>
                        <td>{Desejo.descricao}</td>
                        <td>{Desejo.idUsuarioNavigation.nome}</td>
                      </tr>
                    )
                  })
                }
              </tbody>
            </table>
        </main>
      </div>
    );
  }
}
