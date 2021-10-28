import './App.css';
import { Component } from "react";
import user from "./Imagens/btn_grande.png"
import deletar from "./Imagens/btn_pequeno.png"

export default class Desejos extends Component {

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

  buscarDesejos = async () => {
    console.log('agora vamos fazer a chamada para a api.')

    fetch('http://localhost:5000/api/Desejo')
      .then(resposta => resposta.json())
      .then(dados => this.setState({ listaDesejosUsuarios: dados }))
      .catch(erro => console.log(erro));

    await console.log(this.state.listaDesejosUsuarios);
  }

  cadastrarDesejo = (submit_formulario) => {
    submit_formulario.preventDefault();

        fetch('http://localhost:5000/api/Desejo', {

            method: 'POST',

            body: JSON.stringify({ idUsuario: this.state.IdUsuario, descricao: this.state.Desejo }), //lembrado que aqui e um obj js e nao json.

            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(console.log("Desejo cadastrado."))

            .catch(erro => console.log(erro))

            .then(this.buscarDesejos)
    }

    excluirDesejo = (Desejo) => {
      console.log('O Tipo de Evento ' + Desejo.idDesejo + ' foi selecionado!');

      fetch('http://localhost:5000/api/Desejo/' + Desejo.idDesejo,
      {
          method: 'DELETE'
      })

      .then(resposta => {
          if (resposta.status === 204) {
              console.log('Tipo de Evento ' +  Desejo.idDesejo + ' foi excluído!')
          };
      })

      .catch(erro => console.log(erro))

      .then(this.buscarDesejos);
  };

  componentDidMount() {
    this.buscarDesejos();
  }

  render() {

    return (
      <div>

        <main className="main-desejos">
          <div className="textos">
            <h1>I Wish More</h1>
            <p>Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum sobreviveu não só a cinco séculos, como também ao salto para a editoração eletrônica, permanecendo essencialmente inalterado. Se popularizou na década de 60, quando a Letraset lançou decalques contendo passagens de Lorem Ipsum, e mais recentemente quando passou a ser integrado a softwares de editoração eletrônica como Aldus PageMaker.</p>
          </div>

          <div className="todosCards">
            {
              this.state.listaDesejosUsuarios.map((Desejo) => {
                return (
                  <div className="cards" key={Desejo.idDesejo}>
                    <img className="imagem-user" src={user} alt="Imagem do desejo" />
                    <div className="fundo-card">
                      <p>Desejo: {Desejo.descricao}</p>
                      <p>Usuario: {Desejo.idUsuarioNavigation.nome}</p>
                    </div>
                    <button onClick={() => this.excluirDesejo(Desejo)}> <img className="imagem-delete" src={deletar} alt="Imagem Botão de deletar" /> </button>
                  </div>
                )
              })
            }
          </div>

          <form className="card_input" action="submit" onSubmit={this.cadastrarDesejo}>
            <img className="imagem-user" src={user} alt="Imagem do desejo" />
            <div className="fundo-card">
              <input id="id" onChange={this.atualizaEstadoIdUsuario} value={this.state.IdUsuario} type="number" placeholder="   Digite seu id" />
              <input id="descricao" onChange={this.atualizaEstadoDesejo} value={this.state.Desejo} type="text" placeholder="   Digite um desejo" />
            </div>
            <button type="submit" disabled={this.state.Desejo === '' || this.state.IdUsuario === '' ? 'none' : ''}><img className="imagem-delete" src={deletar} alt="Imagem Botão de deletar" /></button>
          </form>
        </main>
        <footer>
          <p>Todos os direitos reservados á AWM Industries - 2021</p>
        </footer>
      </div>
    );
  }
}
