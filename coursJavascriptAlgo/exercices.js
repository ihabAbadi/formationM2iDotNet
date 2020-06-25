/* #region Exercice 1 */
// let AB = 7
// let BC = '7'
// let AC = 10

// if(AB === AC) {
//     if(AC === BC) {
//         console.log("Triangle équilatéral")
//     }
//     else {
//         console.log("isocèle en A")
//     }
// }
// else if(AB === BC) {
//     console.log("isocèle en B")
// }
// else if(AC === BC) {
//     console.log("isocèle en C")
// }
// else {
//     console.log("le triangle n'est isocèle ni en A, ni en B, ni en C")
// }
/* #endregion */
/* #region Exercice 2 */
// let poids = 46
// let taille = 148
// if((taille >= 145 && taille <= 169 && poids >= 43 && poids <= 47) || (taille >= 145 && taille <= 166 && poids >= 48 && poids <= 53) || (taille >= 145 && taille <= 163 && poids >= 54 && poids <= 59) || (taille >= 145 && taille <= 160 && poids >= 60 && poids <= 65)) {
//     console.log("taille 1")
// } else if((taille >= 169 && taille <= 178 && poids >= 48 && poids <= 53) || (taille >= 169 && taille <= 175 && poids >= 54 && poids <= 59) || (taille >= 163 && taille <= 172 && poids >= 60 && poids <= 65) || (taille >= 160 && taille <= 169 && poids >= 66 && poids <= 71))  {
//     console.log("taille 2")
// } else if((taille >= 178 && taille <= 183 && poids >= 54 && poids <= 59) || (taille >= 175 && taille <= 183 && poids >= 60 && poids <= 65) || (taille >= 172 && taille <= 183 && poids >= 66 && poids <= 71)|| (taille >= 163 && taille <= 183 && poids >= 72 && poids <= 77)) {
//     console.log("taille 3")
// }
// else {
//     console.log("error taille")
// }
/* #endregion */
/* #region exercice 4 serie 2 */
// let masse_1 = 1
// let masse_2 = 0.5
// let prix_1 = 2
// let prix_2 = 1
// if(masse_1 > 0 && masse_2 > 0 && prix_1 >= 0 && prix_2 >= 0) {
//     if(prix_1/masse_1 > prix_2/masse_2) {
//         console.log("le prix est meilleur pour la pizza 2")
//     }
//     else if(prix_1/masse_1 < prix_2/masse_2) {
//         console.log("le prix est meilleur pour la pizza 1")
//     }
//     else {
//         console.log("même prix")
//     }
// }
// else {
//     console.log('paramètres incorrect')
// }
/* #endregion */
/* #region exercice 5 */
let mois = 1
switch(mois) {
    case 1 :
        console.log("Janvier, 31 jours")
        break;
    case 2 :
        console.log("Février, 28 ou 29 jours")
        break;
    case 3 :
        console.log("Mars, 31 jours")
        break;
    case 4 :
        console.log("Avril, 30 jours")
        break;    
    case 5 :
        console.log("Mai, 31 jours")
        break;
    case 6 :
        console.log("Juin, 30 jours")
        break;
    case 7 :
        console.log("Juillet, 31 jours")
        break;
    case 8 :
        console.log("Août, 31 jours")
        break;
    case 9 :
        console.log("Septembre, 30 jours")
        break;
    case 10 :
        console.log("Octobre, 31 jours")
        break;
    case 11 :
        console.log("Novembre, 30 jours")
        break;
    case 12 :
        console.log("Décembre, 31 jours")
        break;
    default:
        console.log("Erreur mois")
        break;
}
/* #endregion */