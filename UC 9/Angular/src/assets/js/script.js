function mostrarMenu() {
    let menu = document.getElementById("menu");

    if (getComputedStyle(menu).display == 'none') {
    menu.style.display = 'flex';
    } else {
    menu.style.display = "none";
    }
}

function pesquisar() {
    let texto = document.getElementById("pesquisar").value;

    alert("Por favor, insira um item para a busca.")
}
