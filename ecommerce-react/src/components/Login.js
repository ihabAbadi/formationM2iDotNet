import React, {Component} from "react"
import { login } from "../services/ApiService"

export class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            user : {
                email : '',
                password : ''
            }
        }
    }
    
    updateField = (e) => {
        let tmpUser = {...this.state.user}
        tmpUser[e.target.name] = e.target.value
        this.setState({
            user: tmpUser
        })
    }
    login = () => {
        login(this.state.user).then(res=> {
            localStorage.setItem("token", res.data.token)
            localStorage.setItem("name", res.data.name)
            this.props.history.push('/Order')
        }).catch((err) => {
            alert("Erreur login")
        })
    }
    render() {
        return (
            <div className="container">
                <div className="row justify-content-center align-item-center">
                    <div className="col-5">
                        <div className="row m-1">
                            <input onChange={this.updateField} className="col form-control" type="text" name="email" placeholder="Votre email" />
                        </div>
                        <div className="row m-1">
                            <input onChange={this.updateField} className="col form-control" type="password" name="password" placeholder="Votre mot de passe" />
                        </div>
                        <div className="row m-1">
                            <button onClick={this.login} className="col form-control btn btn-info">Login</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}