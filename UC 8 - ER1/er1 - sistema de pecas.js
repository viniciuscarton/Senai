console.log ("Sistema de cadastramento de peças")
let PesoPeca = "200";
if (PesoPeca < 100) {
    console.log ("Cadastro não realizado. Peça excede o limite de peso (100).");
}   else { console.log ("Peso da peça cadastrado.");
}

let NumeroPecas = "5";
if (NumeroPecas > 10) {
    console.log ("Cadastro não realizado. Número de peças excede o limite (10).");
}   else { console.log ("Número de peças cadastrado.");
}

let NomePeca = "AUQR-100";
if (NomePeca.length < 3) {
    console.log ("Cadastro não realizado. Nome da peça deve ser superior a 3 caracteres.")
}   else { console.log ("Cadastro realizado.");
}