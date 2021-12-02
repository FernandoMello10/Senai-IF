import React, { Component } from 'react';

import '../../assets/css/cadastro.css';

class Cadastro extends Component
{
    constructor(props)
    {
        super(props);
        this.state={
            Nome : '',
            Setor : '',
            Telefone : '',
            Email : '',
            Senha : '',
            ConfirmarSenha : '',
            erroMensagem : '',
            isloading : false
            // tipoUsuario : Boolean,
        }
    }

    atualizarState = (state) => {
        this.setState({ [state.target.name] : state.target.value})

        console.log(this.state.nomeUsuario)
        console.log(this.state.email)
        console.log(this.state.senha)
    }
    cadastro = (event) =>{
        event.preventDefault()

        fetch('',{
            method : 'POST',

            body : JSON.stringify({
                nomeUsuario    : this.state.nomeUsuario,
                email       : this.state.email,
                senha       : this.state.senha,
                // tipoUsuario : this.state.tipoUsuario    
            }),

            headers : {
                "Content-Type" : "application/json",
          }
          
        })

        .then(resp => {

            if (resp.status === 201) {
                this.props.history.push('/login')
            }
        })
    }

    render()
    {
        return(
            <main className="main-cd">
            <div className="barraLateral-cd">
            <div className="letra-lg">
                            <p> Bem-vindo de volta!<br/>Entre com seu email da empresa</p>
               </div>
            </div>
            <section className="section-cd">
                <div className="header-cd">
                    <p>Cadastre-se</p>
                </div>
    
                <div className="login-cd">
    
                    <div className="meio1-cd">
                        <div className="linha-cd"></div>
                    </div>
    
                    <div className="meio2-cd">
    
                        <div className="forms-cd">
    
                            <form className="form-cd" onSubmit={this.cadastro}>
                                <div className="metadeForm-cd">
    
                                    <input className="input-cd" type="text" placeholder="Nome" name="nomeUsuario" value={this.state.nomeUsuario} onChange={this.atualizarState}/>
    
                                    <input className="input-cd" type="text" placeholder="email" name="email" value={this.state.email} onChange={this.atualizarState}/>
        
                                    <input className="input-cd" type="password" placeholder="senha" name="senha" value={this.state.senha} onChange={this.atualizarState}/>
                                </div>
    
                                <div className="btn-cd">
                                    
                                    <button className="button-cd" type="submit">cadastro</button>
    
                                </div>
                            </form>
    
                        </div>
    
    
                    </div>
    
                </div>
                
            </section>
        </main>
        )
    }
}

export default Cadastro;