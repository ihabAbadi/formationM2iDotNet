import React, { FC, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { Carte } from './Carte';
import { Joueur } from './Joueur';



const App: FC = (props: any) => {

  const [joueur1, setJoueur1] = useState(new Joueur())
  const [joueur2, setJoueur2] = useState(new Joueur())
  const [jeu, setJeu] = useState(new Array<Carte>())
  let tabCartes: Array<Carte> = new Array<Carte>()

  const generateurCartes = (): void => {
    const types: Array<String> = ["trefle", "carreau", "coeur", "pique"]
    for (let t of types) {
      for (let i = 2; i <= 14; i++) {
        tabCartes = [...tabCartes, new Carte(t, i)]
      }
    }
    melangerCartes()
    distribuerCarte()
  }

  const melangerCartes = (): void => {
    for (let i = 0; i < tabCartes.length; i++) {
      let tmpIndex: number = Math.floor(Math.random() * (tabCartes.length - 1))
      let tmpCarte: Carte = tabCartes[i]
      tabCartes[i] = tabCartes[tmpIndex]
      tabCartes[tmpIndex] = tmpCarte
    }
  }

  const distribuerCarte = (): void => {
    const cartes1: Array<Carte> = new Array<Carte>()
    const cartes2: Array<Carte> = new Array<Carte>()
    for (let i = 0; i < tabCartes.length; i++) {
      if (i % 2 == 0) {
        cartes1.push(tabCartes[i])
      }
      else {
        cartes2.push(tabCartes[i])
      }
    }
    let tmpJoueur = new Joueur()
    tmpJoueur.tabCartes = cartes1
    setJoueur1(tmpJoueur)
    tmpJoueur = new Joueur()
    tmpJoueur.tabCartes = cartes2
    setJoueur2(tmpJoueur)
  }
  const jouer = (joueur: Joueur): void => {
    let tmpJeu = [...jeu, joueur.tabCartes[joueur.tabCartes.length - 1]]
    if (tmpJeu.length % 2 == 0) {
      if (tmpJeu[tmpJeu.length - 1].valeur > tmpJeu[tmpJeu.length - 2].valeur) {
        let tmpJoueur = new Joueur()
        tmpJoueur.tabCartes = [...tmpJeu,...joueur2.tabCartes]
        setJoueur2(tmpJoueur)
      }
      else if(tmpJeu[tmpJeu.length - 1].valeur < tmpJeu[tmpJeu.length - 2].valeur) {
        let tmpJoueur = new Joueur()
        tmpJoueur.tabCartes = [...tmpJeu,...joueur1.tabCartes]
        setJoueur1(tmpJoueur)
      }
      setJeu(new Array<Carte>())
    }
    else {
      setJeu(tmpJeu)
    }
  }
  return (
    <div>
      <div><button onClick={() => { generateurCartes() }}>Start</button></div>
      <div>
        Joueur1 Nombre Carte : {joueur1.tabCartes.length} <button onClick={() => jouer(joueur1)}>Play</button>
      </div>
      <div>
        Joueur2 Nombre Carte : {joueur2.tabCartes.length} <button onClick={() => jouer(joueur2)}>Play</button>
      </div>
      <div>
        carte 1 : {(jeu.length > 0) ? jeu[0].valeur : ''} 
      </div>
      <div>
        carte 2 : {(jeu.length > 1) ? jeu[1].valeur : ''} 
      </div>
    </div>
  )
}

export default App;
