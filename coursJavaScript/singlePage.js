const contenuPages = {
    page1 : 'contenuPage 1',
    page2 : 'contenuPage 2',
    page3 : 'contenuPage 3',
}

const header = document.querySelector("header")
const main = document.querySelector("main")

for(let page in contenuPages) {
    header.innerHTML += "<a>"+page+"</a>"
}