var botonLogin = document.getElementById("BtnLogin");
var botonLogo = document.getElementById("BtnLogo");
var botonCreditos = document.getElementById("BtnCreditos");
var informacion = document.getElementById("BtnInformacion");
var cancelarInfo = document.getElementById("BtnCancelarInfo");
var promocion = document.getElementById("Promo1");
var login = document.getElementById("BtnLogin");
var cancelar = document.getElementById("BtnCancelar");
var informacion = document.getElementById("BtnInformacion");


botonLogin.onmouseover = function ()
{
    gsap.to('.BtnLogin', {
        duration: 0.1,
        backgroundColor: "#fff"
    })
}

botonLogin.onmouseout = function ()
{
    gsap.to('.BtnLogin', {
        duration: 0.1,
        backgroundColor: "#0275d8"
    })
}

botonLogo.onmouseover = function ()
{
    gsap.to('.BtnLogo', {
        duration: 0.1,
        backgroundColor: "#fff"
    })
}

botonLogo.onmouseout = function ()
{
    gsap.to('.BtnLogo', {
        duration: 0.1,
        backgroundColor: "#0275d8"
    })
}

informacion.onmouseover = function ()
{
    gsap.to('.BtnInformacion', {
        duration: 0.1,
        backgroundColor: "#0275d8"
    })
}

informacion.onmouseout = function ()
{
    gsap.to('.BtnInformacion', {
        duration: 0.1,
        backgroundColor: "#007bff"
    })
}

botonCreditos.onmouseover = function ()
{
    gsap.to('.BtnCreditos', {
        duration: 0.1,
        backgroundColor: "#0275d8"
    })
}

botonCreditos.onmouseout = function ()
{
    gsap.to('.BtnCreditos', {
        duration: 0.1,
        backgroundColor: "#007bff"
    })
}


document.getElementById("Info").style.display = "none";

informacion.onclick = function ()
{
    document.getElementById("Info").style.display = "block";
    document.getElementById("Info").style.visibility = "visible";
    gsap.from('.Info', {
        duration: 0.5,
        y: -700,
        ease: "slow(0.7, 0.7, false)",
    });
}

cancelarInfo.onclick = function ()
{
    document.getElementById("Info").style.display = "none";
}

document.getElementById("Login").style.display = "none";

login.onclick = function ()
{
    document.getElementById("Login").style.display = "block";
    document.getElementById("Login").style.visibility = "visible";
    gsap.from('.Login', {
        duration: 0.5,
        y: -700,
        ease: "slow(0.7, 0.7, false)",
    });
}

cancelar.onclick = function ()
{
    document.getElementById("Login").style.display = "none";
}


function AnimacionPrincipal()
{
    
    gsapInformacionfrom('.Promo1', {
        duration: 1,
        x: 800,
        ease: "slow(0.7, 0.7, false)",
    });

    gsap.from('.Promo2', {
        duration: 1,
        x: -800,
        ease: "slow(0.7, 0.7, false)",
    })
}