function iniciar() {
    var imagen = document.getElementById('logout_img');
}
function restaurar() {
    var imagen = document.getElementById('logout_img');
    imagen.src = "./img/logout_red.png";
}

function cambiarImagen() {
    var imagen = document.getElementById('logout_img');
    imagen.src = "./img/logout.png";
}   

function CerrarSesion() {
    localStorage.setItem("UsuarioNombre", "");

    $.ajax({
        url: '/Home/LogOut',
        data: {},
        async: true,
        type: "GET",
        atType: 'html',
        success: function (res) {
            window.location.href = '/Home/Index';
        }
    });
}
