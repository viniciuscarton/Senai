//Sistema de contagem de alunos.

let numeroAlunos = 100

for(let contador = 0; contador < numeroAlunos; contador++){
    if(contador % 2 == 0 & contador !== 0) {
        console.log (`O número ${contador} é par.`);
        } else if (contador % 2 !== 0) {
            console.log (`O número ${contador} é impar.`);
            } else if (contador == 0) {
                console.log (`O número ${contador} é zero.`);
            }
        }