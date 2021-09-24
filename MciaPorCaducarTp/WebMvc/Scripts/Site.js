/********funcion para abrir la ventana de error********/
function abrirError(nombreFlag) {
    if (document.getElementById("flagError").value != "") {

        document.getElementById("Error").style.display = "block";

        var form = document.getElementById(nombreFlag).value;
        var ele = document.getElementById(form);
        ele.style.display = "none";

        document.body.style.backgroundColor = "gray";
        document.getElementById("btnOk").focus();
    }
}

/********es el boton de "OK" de la ventana de error********/
function myFuncionOK() {

    document.body.style.backgroundColor = "white";
    document.getElementById("Error").style.display = "none";
    document.getElementById("flagError").value = "";

    funReady();
    SetFocus();
}

/********valida que se den opciones 1 y 2********/
function soloOpciones(e) {
    debugger;
    var keynum = window.event ? window.event.keyCode : e.which;
    //if (keynum > 31 && (keynum < 49 || keynum > 50) )
    //    return false;

    //return true;
    switch (keynum) {
        case 48:
        case 49:
        case 50:
        case 76:
        case 72:
        case 108:
        case 104:
            return true;
            break;
        default:
            return false;
            break;
    }
}

/********valida que se de opcion 1********/
function soloOpcionUnica(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    //if (keynum > 31 && (keynum < 49 || keynum > 49))
    //    return false;

    //return true;
    switch (keynum) {
        case 48:
        case 49:
        case 76:
        case 72:
        case 108:
        case 104:
            return true;
            break;
        default:
            return false;
            break;
    }
}

/********valida que se den opciones del 1 - 4********/
function soloVariasOpciones(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    //if (keynum > 31 && (keynum < 49 || keynum > 52))
    //    return false;

    //return true;
    switch (keynum) {
        case 48:
        case 49:
        case 50:
        case 51:
        case 52:
        case 76:
        case 72:
        case 108:
        case 104:
            return true;
            break;
        default:
            return false;
            break;
    }
}

/********funcion que permite escribir numero enteros********/
function soloNumeros(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if (keynum > 31 && (keynum < 48 || keynum > 57))
        return false;

    return true;
}

/********funcion que permite escibir numeros decimales********/
function soloDecimal(e, thix) {
    var keynum = window.event ? window.event.keyCode : e.which;

    if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
        return false;
    if ((keynum == 8 || keynum == 48 || keynum == 46))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}

/********abrir un cmb dependiendo la cantidad de elementos que tenga********/
function expand(obj) {
    var length = obj.options.length;
    if (length > 10) {
        obj.size = 10;
    }
    else {
        obj.size = length;
    }

    obj.selectedIndex = "0";
}

/********regresar el cmb a su tamaño normal********/
function unexpand(obj) {
    obj.size = 1;
}

/********dehabilita el regresa a la pagina anterior********/
function nobackbutton() {
    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button" //chrome
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
}

/****para posicionarse al final de cada input*****/
function posicion(thix) {

    //var x = document.getElementsByTagName("form");
    //x.addEventListener("focus", myFocusFunction, true);

    //function myFocusFunction() {
    var val = document.getElementById(thix.id).value;
    document.getElementById(thix.id).value = '';
    document.getElementById(thix.id).value = val;
    //}
}

/****funciones para el comportamiento de opera*****/
var IsOperaMobile = (navigator.userAgent.indexOf("Opera") >= 0) && (navigator.userAgent.indexOf("Mobile") >= 0)

var tFocus = setTimeout(SetFocus, 800);/*tenia 500*/

function SetFocus() {
    document.getElementById('B').click();
    tFocus = null;
}

function CheckFocus() {
    var focusOn = document.getElementById('FocusOn');
    if (focusOn) {
        if (focusOn.value != "") {
            document.getElementById(focusOn.value).focus();
        }
    }
}