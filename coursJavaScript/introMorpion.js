const section = document.querySelector("section")

section.addEventListener('click', function(e) {
    e.target.innerText = "Coucou"
    alert(e.target.getAttribute('data-x') +" "+e.target.getAttribute("data-y"))
})