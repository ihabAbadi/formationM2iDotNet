import { Carte } from "./Carte";

export class Joueur {
    tabCartes : Array<Carte>

    constructor() {
        this.tabCartes = new Array<Carte>()
    }
}