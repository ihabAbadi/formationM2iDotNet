import React, { Component } from "react"
import { Link } from "react-router-dom"

class Header extends Component {

    render() {
        return (
            <header className="container-fluid">
                <nav className="navbar navbar-expand-lg navbar-light bg-light">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <Link to='/' className="nav-link">Accueil</Link>
                        </li>
                        <li className="nav-item">
                            <Link to='/FormAnnonce' className="nav-link">Déposer une annonce</Link>
                        </li>
                    </ul>
                </nav>
            </header>
        )
    }
}

export default Header