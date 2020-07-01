const contenuPages = {
    formulaire : "<form><div><input placeholder='titre page' type='text' name='titre' /></div><div><textarea placeholder='contenu page' name='contenu'></textarea></div><div><button type='submit'>Valider</button></div></form>",
    page1 : 'contenuPage 1',
    page2 : 'contenuPage 2',
    page3 : 'contenuPage 3',
}
// contenuPages["titreNouvellePage"] = "contenu"
const header = document.querySelector("header")
const main = document.querySelector("main")

for(let page in contenuPages) {
    header.innerHTML += "<a href='"+page+"'>"+page+"</a>"
    
}
header.addEventListener('click', (e) => {
    e.preventDefault()
    const page = e.target.getAttribute("href")
    main.innerHTML = contenuPages[page]
    if(page == 'formulaire') {
        const form = document.querySelector('form')
        form.addEventListener('submit', (e) => {
            e.preventDefault()
            const titrePage = form.querySelector("input[name='titre']").value
            const contenuPage = form.querySelector('textarea').value
            contenuPages[titrePage] = contenuPage
            header.innerHTML += "<a href='"+titrePage+"'>"+titrePage+"</a>"
            // console.log(contenuPages)
        })
    }
    else {
        main.innerHTML += "<div><a>Modifier</a></div>"
    }
})