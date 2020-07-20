"use strict";
var __spreadArrays = (this && this.__spreadArrays) || function () {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};
exports.__esModule = true;
var react_1 = require("react");
require("./App.css");
var Carte_1 = require("./Carte");
var Joueur_1 = require("./Joueur");
var App = function (props) {
    var _a = react_1.useState(new Joueur_1.Joueur()), joueur1 = _a[0], setJoueur1 = _a[1];
    var _b = react_1.useState(new Joueur_1.Joueur()), joueur2 = _b[0], setJoueur2 = _b[1];
    var _c = react_1.useState(new Array()), jeu = _c[0], setJeu = _c[1];
    var tabCartes = new Array();
    var generateurCartes = function () {
        var types = ["trefle", "carreau", "coeur", "pique"];
        for (var _i = 0, types_1 = types; _i < types_1.length; _i++) {
            var t = types_1[_i];
            for (var i = 2; i <= 14; i++) {
                tabCartes = __spreadArrays(tabCartes, [new Carte_1.Carte(t, i)]);
            }
        }
        melangerCartes();
        distribuerCarte();
    };
    var melangerCartes = function () {
        for (var i = 0; i < tabCartes.length; i++) {
            var tmpIndex = Math.floor(Math.random() * (tabCartes.length - 1));
            var tmpCarte = tabCartes[i];
            tabCartes[i] = tabCartes[tmpIndex];
            tabCartes[tmpIndex] = tmpCarte;
        }
    };
    var distribuerCarte = function () {
        var cartes1 = new Array();
        var cartes2 = new Array();
        for (var i = 0; i < tabCartes.length; i++) {
            if (i % 2 == 0) {
                cartes1.push(tabCartes[i]);
            }
            else {
                cartes2.push(tabCartes[i]);
            }
        }
        var tmpJoueur = new Joueur_1.Joueur();
        tmpJoueur.tabCartes = cartes1;
        setJoueur1(tmpJoueur);
        tmpJoueur = new Joueur_1.Joueur();
        tmpJoueur.tabCartes = cartes2;
        setJoueur2(tmpJoueur);
    };
    var jouer = function (joueur) {
        var tmpJeu = __spreadArrays(jeu, [joueur.tabCartes[joueur.tabCartes.length - 1]]);
        if (tmpJeu.length % 2 == 0) {
            if (tmpJeu[tmpJeu.length - 1].valeur > tmpJeu[tmpJeu.length - 2].valeur) {
                var tmpJoueur = new Joueur_1.Joueur();
                tmpJoueur.tabCartes = __spreadArrays(tmpJeu, joueur2.tabCartes);
                setJoueur2(tmpJoueur);
            }
            else if (tmpJeu[tmpJeu.length - 1].valeur < tmpJeu[tmpJeu.length - 2].valeur) {
                var tmpJoueur = new Joueur_1.Joueur();
                tmpJoueur.tabCartes = __spreadArrays(tmpJeu, joueur1.tabCartes);
                setJoueur1(tmpJoueur);
            }
            setJeu(new Array());
        }
        else {
            setJeu(tmpJeu);
        }
    };
    return (<div>
      <div><button onClick={function () { generateurCartes(); }}>Start</button></div>
      <div>
        Joueur1 Nombre Carte : {joueur1.tabCartes.length} <button onClick={function () { return jouer(joueur1); }}>Play</button>
      </div>
      <div>
        Joueur2 Nombre Carte : {joueur2.tabCartes.length} <button onClick={function () { return jouer(joueur2); }}>Play</button>
      </div>
      <div>
        carte 1 : {(jeu.length > 0) ? jeu[0].valeur : ''} 
      </div>
      <div>
        carte 2 : {(jeu.length > 1) ? jeu[1].valeur : ''} 
      </div>
    </div>);
};
exports["default"] = App;
