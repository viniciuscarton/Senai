console.log ("Cadastro de eventos!");

//inserir a data do evento
let Hoje = new Date();
let DataEvento = new Date(2022, 2, 09);
if (DataEvento <= Hoje) {
    console.log ("Data inválida.");
} else {console.log ("Data cadastrada.");
};

//inserir a idade
let Idade = 23;
if (Idade <= 18) {
    console.log ("Cadastro recusado. Idade mín. 18.");
} else {console.log ("Usuário cadastrado.");
};

//inserir a quantidade de participantes
let Participantes = ["Matheus", "Henrique", "Mariana", "Vinicius", "Lídio", "Lucas", "José"];
let Palestrantes = ["João", "Maria", "Carol"];
if (Participantes.length + Palestrantes.length >= 100) {
    console.log ("Cadastro não realizado. Excedido o limite de participantes (100).");
} else {console.log ("Cadastro efetuado. Evento em " + (Math.floor((DataEvento - Hoje)/86400000)) + " dias com " + Participantes.length + Palestrantes.length + " participantes.");
};