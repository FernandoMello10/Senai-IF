import React, { Component } from 'react';
import axios from 'axios';

import '../../assets/css/login.css';

class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email :'',
            senha :'',
            erroMensagem : '',
            isloading : false
        }
    };
        efetuaLogin = (event) => {
            event.preventDefafault();

            this.setState({ erroMensagem : '', isloading : true })

            axios.post('',{
                email : this.state.email,
                senha : this.state.senha
            })
            .then(resposta => {
                if(resposta.status ===20) {
                    localStorage.setItem('usuario-login',resposta.data.token)

                    console.log('Meu token é:' + resposta.data.token)
                    this.setState({ isloading : false})
                }
            })

            .catch(() => {
                this.setState({ erroMensagem : 'E-mail ou senha inaválidos! Tente novamente.', isloading : false})
            })
        }

        atualizaStateCampo = (campo) => {
                this.setState({ [campo.target.name] : campo.target.value })
        
            }

    render(){
        return(
            <div>
                <main>
                   <section>
                   <p>Bem-vindo de volta! <br/>Entre com seu email da empresa ou com seu email e senha</p>
                 <form onSubmit={this.efetuaLogin}>
                     <input
                     type="text"
                     name="email"
                     value={this.state.email}
                     onChange={this.atualizaStateCampo}
                     placeholder="username"
                     />

                     <input
                     type="password"
                     name="senha"
                     value={this.state.senha}
                     onChange={this.atualizaStateCampo}
                     placeholder="password"
                     />
                     <p style={{color : 'red'}}>{this.state.erroMensagem}</p>
                        {
                            this.state.isloading === true &&
                            <button type="submit" disabled>Loading..</button>
                        }
                        
                        {
                            this.state.isloading === false &&
                            <button
                                type="submit"
                                disabled={this.state.email === '' || this.state.senha === '' ? 'none' : '' }
                                >
                                Login
                            </button>
                        }
                    {/* <button type="submit">
                           Login
                      </button> */}

                 </form>
                   </section>
                </main>
            </div>
        )
    }
};

export default Login;
