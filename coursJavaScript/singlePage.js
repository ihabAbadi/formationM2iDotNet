const contenuPages = {
    page1 : 'contenuPage 1',
    page2 : 'contenuPage 2',
    page3 : 'contenuPage 3',
}

const header = document.querySelector("header")
const main = document.querySelector("main")

for(let page in contenuPages) {
    header.innerHTML += "<a href='"+page+"'>"+page+"</a>"
}
header.addEventListener('click', (e) => {
    e.preventDefault()
    const page = e.target.getAttribute("href")
    main.innerHTML = contenuPages[page]
})