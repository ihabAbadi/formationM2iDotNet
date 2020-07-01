let contenuPages = {
    formulaire: "<form><div><input placeholder='titre page' type='text' name='titre' /></div><div><textarea placeholder='contenu page' name='contenu'></textarea></div><div><button type='submit'>Valider</button></div></form>",
    page1: 'contenuPage 1',
    page2: 'contenuPage 2',
    page3: 'contenuPage 3',
}
// contenuPages["titreNouvellePage"] = "contenu"
const header = document.querySelector("header")
const main = document.querySelector("main")

for (let page in contenuPages) {
    header.innerHTML += "<a href='" + page + "'>" + page + "</a>"

}
header.addEventListener('click', (e) => {
    e.preventDefault()
    const page = e.target.getAttribute("href")
    main.innerHTML = contenuPages[page]
    if (page == 'formulaire') {
        const form = document.querySelector('form')
        form.addEventListener('submit', (e) => {
            e.preventDefault()
            const titrePage = form.querySelector("input[name='titre']").value
            const contenuPage = form.querySelector('textarea').value
            contenuPages[titrePage] = contenuPage
            header.innerHTML += "<a href='" + titrePage + "'>" + titrePage + "</a>"
            // console.log(contenuPages)
        })
    }
    else {
        main.innerHTML += "<div><a class='edit' href='" + page + "'>Modifier</a></div>"
        main.innerHTML += "<div><a class='delete' href='" + page + "'>supprimer</a></div>"
    }
})

main.addEventListener('click', (e) => {
    if (e.target.classList.contains('edit')) {
        e.preventDefault()
        main.innerHTML = contenuPages['formulaire']
        main.querySelector('input[name="titre"]').value = e.target.getAttribute('href')
        main.querySelector('input[name="titre"]').disabled = true
        main.querySelector('textarea').value = contenuPages[e.target.getAttribute('href')]
        const form = document.querySelector('form')
        form.addEventListener('submit', (e) => {
            e.preventDefault()
            const titrePage = form.querySelector("input[name='titre']").value
            const contenuPage = form.querySelector('textarea').value
            contenuPages[titrePage] = contenuPage
        })
    }
    else if(e.target.classList.contains('delete')) {
        e.preventDefault()
        let tmpObject = {}
        for(let key in contenuPages) {
            if(key != e.target.getAttribute('href')) {
                tmpObject[key] = contenuPages[key]
            }
        }
        contenuPages = tmpObject
        header.innerHTML = ""
        for (let page in contenuPages) {
            header.innerHTML += "<a href='" + page + "'>" + page + "</a>"
        }
        main.innerHTML = ""
    }
})