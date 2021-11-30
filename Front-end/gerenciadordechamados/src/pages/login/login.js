import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

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

            render()
            {
                return(
                <main className="main-lg">
                    <div className="barraLateral-lg"></div>
                    <section className="section-lg">
                        <div className="header-lg">
                            <p>login</p>
                        </div>
            
                        <div className="login-lg">
            
                            <div className="meio1-lg">
                                <div className="linha-lg"></div>
                            </div>
            
                            <div className="meio2-lg">
            
                                <div className="forms-lg">
            
                                    <form className="form-lg" onSubmit={this.efetuarlogin}>
                                        <div className="metadeForm-lg">
            
                                            <input className="input-lg" type="text" placeholder="email" name="email" value={this.state.email} onChange={this.atualizarState}/>
                
                                            <input className="input-lg" type="password" placeholder="senha" name="senha" value={this.state.senha} onChange={this.atualizarState}/>
                                        </div>
            
                                        <div className="btn-lg">
                                            
                                            <button type="submit">logar</button>
                            
                                            <p className="btn-p-lg">{this.state.errormensage}</p>
            
                                        </div>
                                    </form>
        
                                    <div className="msm-cad-lg">
                                        <p className="msm-p-lg">Não tem Login?</p>
                                        <Link to="/cadastro" className="msm-p2-lg">Cadastre-se</Link>
                                    </div>
            
                                </div>
            
                            </div>
            
                        </div>
                        
                    </section>
                </main>
                )
            }
        }
        
        export default Login;