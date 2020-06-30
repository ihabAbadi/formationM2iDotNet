const formulaire = document.querySelector("#monForm")
formulaire.addEventListener('submit', function(e) {
    //bloquer comportement par défault  => (comportement par defaut d'un formulaire est d'envoyer les données vers une action) 
    e.preventDefault()
    //Vérification avant d'envoyer le formulaire
    let error = false
    let allInputs = document.querySelectorAll('input') 
    for(let input of allInputs) {
        if(input.value == "") {
            error = true
        }
    }
    if(!error){
        this.submit()
    }
    else {
        alert("Merci de remplir la totalité des champs")
    }
})