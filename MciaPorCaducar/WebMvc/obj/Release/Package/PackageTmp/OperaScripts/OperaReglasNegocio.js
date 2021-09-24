function myTrim(x) {
    return x.replace(/^\s+|\s+$/gm, '');
}

var IsOperaMobile = (navigator.userAgent.indexOf("Opera") >= 0) && (navigator.userAgent.indexOf("Mobile") >= 0)

var tFocus = setTimeout(SetFocus, 500);

function SetFocus() {
    document.getElementById('B').click();
    tFocus = null;
}

function CheckFocus() {
    var focusOn = document.getElementById('FocusOn');
    if (focusOn) {
        if (focusOn.value != "") {
            document.getElementById(focusOn.value).focus()
        }
    }
}

function setValue(currentId, valueField) {
    document.getElementById(currentId).value = valueField;
    document.getElementById(currentId).innerHTML = valueField;
}

function setValueName(currentId, valueField) {
    debugger;
    var inputfields = document.getElementsByName(currentId);
    var ar_inputflds = inputfields.length;

    for (var i = 0; i < ar_inputflds; i++) {
        inputfields[i].innerHTML = valueField;
    }
}

function setEmptyValue(currentId) {
    document.getElementById(currentId).value = "";
    document.getElementById(currentId).innerHTML = "";
}

function enabledForm(formId) {
    var form = formId;
    if (form != "") {
        var ele = document.getElementById(form);
        if (ele.style.display == "block") {
            ele.style.display = "none";
        }
        else {
            ele.style.display = "block";
        }
    }
}

function GetReponseAjax(url, inputField, formName) {
    var xmlHttp;
    //Let us create the XML http object
    xmlHttp = null;

    if (window.XMLHttpRequest) {
        //for new browsers
        xmlHttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        //for old ones
        var strName = "Msxml2.XMLHTTP"
        if (navigator.appVersion.indexOf("MSIE 5.5") >= 0) {
            strName = "Microsoft.XMLHTTP"
        }
        try {
            xmlHttp = new ActiveXObject(strName);
        }
        catch (e) {
            alert("Error. Scripting for ActiveX might be disabled")
            return false;
        }
    }

    if (xmlHttp != null) {
        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                switch (formName) {
                    //Captura de Mercancia
                    case "formCapturaMcia":
                        switch (inputField) {
                            case "inArt":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValueName("DescCod", respon[0]);

                                    setValue("flagOpcion", "Lote");
                                    funReady('Lote', formName);
                                    document.getElementById("inLot").focus();
                                }
                                break;
                            case "inLot":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FechaCad", respon[0]);

                                    if (respon[1] == "FecCad") {
                                        setValue("flagOpcion", "FecCad");
                                        funReady('FecCad', formName);
                                        document.getElementById("inFec").focus();
                                    }
                                    else if (respon[1] == "LoteReg") {
                                        setValue("CanCap", respon[2]);

                                        setValue("flagOpcion", "LoteReg");
                                        funReady('LoteReg', formName);
                                        document.getElementById("op").focus();
                                    }
                                }
                                break;
                            case "inFec":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FechaCad", document.getElementById(inputField).value);

                                    if (respon[0] == "ConservaFec") {
                                        setValue("flagOpcion", "ConservaFec");
                                        funReady('ConservaFec', formName);
                                        document.getElementById("op2").focus();
                                    }
                                    else if (respon[0] == "CoincideFec") {
                                        setValue("flagOpcion", "CoincideFec");
                                        funReady('CoincideFec', formName);
                                        document.getElementById("op3").focus();
                                    }
                                    else if (respon[0] == "CapturaCant") {
                                        setValue("flagOpcion", "CapturaCant");
                                        funReady('CapturaCant', formName);
                                        document.getElementById("inCan").focus();
                                    }
                                }
                                break;
                            case "op2":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    if (respon[0] == "CoincideFec") {
                                        setValue("flagOpcion", "CoincideFec");
                                        funReady('CoincideFec', formName);
                                        document.getElementById("op3").focus();
                                    }
                                    else if (respon[0] == "CapturaCant") {
                                        setValue("flagOpcion", "CapturaCant");
                                        funReady('CapturaCant', formName);
                                        document.getElementById("inCan").focus();
                                    }
                                }
                                break;
                            case "inCan":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    redirect('/MciaPorCaducar/CapturaMcia');
                                }
                                break;
                            case "op4":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    redirect('/Menu/Index');
                                }
                                break;

                        }
                        break;
                        //Autoriza Merma
                    case "formAutorizaMerma":
                        switch (inputField) {
                            case "cmb_JEFE":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    if (respon[0] == "GenActa") {
                                        setValue("flagOpcion", "GenActa");
                                        funReady('GenActa', formName);
                                        document.getElementById("op2").focus();
                                    }
                                    else if (respon[0] == "CapArt") {
                                        setValueName("NomJefe", respon[1]);

                                        setValue("flagOpcion", "CapArt");
                                        funReady('CapArt', formName);
                                        document.getElementById("inArt").focus();
                                    }
                                    else if (respon[0] == "Inicio") {
                                        redirect('/Menu/Inicio');
                                    }
                                }
                                break;
                            case "inArt":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("DesArt", respon[0]);
                                    setValue("Lote", respon[1]);
                                    setValue("Fecha", respon[2]);
                                    setValue("Existe", respon[3]);

                                    if (respon[4] == "ModCant") {
                                        setValue("CantArt", respon[5]);

                                        setValue("flagOpcion", "ModCant");
                                        funReady('ModCant', formName);
                                        document.getElementById("op").focus();
                                    }
                                    else if (respon[4] == "CapCantMerma") {
                                        setValue("flagOpcion", "CapCantMerma");
                                        funReady('CapCantMerma', formName);
                                        document.getElementById("inCan").focus();
                                    }
                                }
                                break;
                            case "inCan":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("flagOpcion", "CapArt");
                                    funReady('CapArt', formName);
                                    document.getElementById("inArt").focus();
                                }
                                break;
                            case "op2":
                                if (xmlHttp.responseText.indexOf("Error") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    setValue("FocusOn", inputField);
                                    setEmptyValue(inputField);

                                    if (IsOperaMobile) {
                                        setValue("ErrorMsjs", respon[0]);
                                        document.body.style.backgroundColor = "gray";
                                        funReady('Error', formName);
                                        document.getElementById("btnOk").focus();
                                    } else {
                                        bootbox.alert(respon[0]);
                                        $('.bootbox').on('hidden.bs.modal', function () {
                                            var ctr = document.getElementById("FocusOn").value;
                                            setEmptyValue(ctr);
                                            document.getElementById(ctr).focus();
                                        });
                                    }
                                }

                                if (xmlHttp.responseText.indexOf("Continuar") > 0) {
                                    var response1 = xmlHttp.responseText.replace('"', '');
                                    var response = response1.split("~");
                                    var respon = response[1].replace('"', '').split(';');

                                    if (respon[0] == "FolGen") {
                                        setValue("NumActaDestruccion", respon[1]);
                                        setValue("FechaSKU", respon[2]);

                                        setValue("flagOpcion", "FolGen");
                                        funReady('FolGen', formName);
                                        document.getElementById("op3").focus();
                                    }
                                    else if (respon[4] == "NoGen") {
                                        setValue("flagOpcion", "NoGen");
                                        funReady('NoGen', formName);
                                        document.getElementById("op4").focus();
                                    }
                                }
                                break;
                        }
                        break;

                }
            }
        }
    }

    //Pass the value to a web page on server as query string using XMLHttpObject.
    xmlHttp.open("GET", url, false);

    try {
        xmlHttp.send();

        switch (formName) {
            //default:
            //    var response1 = xmlHttp.responseText.replace('"', '');
            //    var response = response1.split("-");

            //    setValue("FocusOn", inputField);
            //    setEmptyValue(inputField);

            //    if (IsOperaMobile) {
            //        setValue("ErrorMsjs", response[1]);
            //        document.body.style.backgroundColor = "gray";
            //        funReady('Error', formName);
            //        document.getElementById("btnOk").focus();
            //    } else {
            //        bootbox.alert(response[1]);
            //        $('.bootbox').on('hidden.bs.modal', function () {
            //            var ctr = document.getElementById("FocusOn").value;
            //            setEmptyValue(ctr);
            //            document.getElementById(ctr).focus();
            //        });
            //    }
            //    break;
        }
    }
    catch (err) {
        //alert(err.description);
    }
    xmlHttp.onerror = function () {
        alert(xmlHttp.responseText);
    };
}

function GetReponseAjax2(url, inputField) {
    var xmlHttp2;
    //Let us create the XML http object
    xmlHttp2 = null;

    if (window.XMLHttpRequest) {
        //for new browsers
        xmlHttp2 = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        //for old ones
        //xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        var strName = "Msxml2.XMLHTTP"
        if (navigator.appVersion.indexOf("MSIE 5.5") >= 0) {
            strName = "Microsoft.XMLHTTP"
        }
        try {
            xmlHttp2 = new ActiveXObject(strName);
        }
        catch (e) {
            alert("Error. Scripting for ActiveX might be disabled")
            return false;
        }
    }

    if (xmlHttp2 != null) {
        xmlHttp2.onreadystatechange = function () {
            //alert(xmlHttp.readyState);
            if (xmlHttp2.readyState == 4 && xmlHttp2.status == 200) {
                //alert(xmlHttp.responseText);
                if (inputField == "inCC") {

                    if (xmlHttp2.responseText.indexOf("Error") > 0) {
                        var form = "Segunda";
                        if (form != "") {
                            var ele = document.getElementById(form);
                            if (ele.style.display == "block") {
                                ele.style.display = "none";
                            }
                            else {
                                ele.style.display = "block";
                            }
                        }

                        var ele = document.getElementById("Error");
                        if (ele.style.display == "block") {
                            ele.style.display = "none";
                        }
                        else {
                            ele.style.display = "block";
                        }

                        document.getElementById("labelError").innerText = xmlHttp.responseText;
                    }

                    if (xmlHttp2.responseText.indexOf("Continuar") > 0) {
                        //var response = xmlHttp.responseText.split("-");
                        //document.getElementById("lblDesc").innerText = response[1];
                        document.getElementById("inC").innerText = "";
                        document.getElementById("inCC").innerText = "";
                        document.getElementById("inC").value = "";
                        document.getElementById("inCC").value = "";

                        document.getElementById("inC").focus();
                    }
                }
            }
        }

        //Pass the value to a web page on server as query string using XMLHttpObject.
        xmlHttp2.open("GET", url, false);
        xmlHttp2.send();
    }

}

function KeyPressed(currentId, nextId, formName) {
    if (IsOperaMobile) {
        //esc
        if (event.keyCode == 83 || event.keyCode == 115) {
            switch (formName) {
                //Captura de Mercancia
                case "formCapturaMcia":
                    switch (currentId) {
                        case "inArt":
                            //Panatlla 8
                            var elem = document.getElementById("Principal");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("NoCerrado");
                            elem.style.display = (true ? "block" : "none");

                            document.getElementById(currentId).value = "";
                            document.getElementById("op4").focus();
                            break;
                        case "inLot":
                            redirect('/MciaPorCaducar/CapturaMcia');
                            break;
                        case "inFec":
                            var elem = document.getElementById("FecCad");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("Lote");
                            elem.style.display = (true ? "block" : "none");

                            setEmptyValue("inLot");
                            document.getElementById(currentId).value = "";
                            document.getElementById("inLot").focus();
                            break;
                        case "inCan":
                            var elem = document.getElementById("CapturaCant");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("FecCad");
                            elem.style.display = (true ? "block" : "none");

                            setEmptyValue("inFec");
                            document.getElementById(currentId).value = "";
                            document.getElementById("inFec").focus();
                            break;
                        case "op4":
                            redirect('/MciaPorCaducar/CapturaMcia');
                            break;
                        default:

                            break;
                    }
                    break;
                    //Autoriza Merma
                case "formAutorizaMerma":
                    switch (currentId) {
                        case "inArt":
                            redirect('/MciaPorCaducar/AutorizaMerma');
                            //Pantalla 1
                            break;
                        case "inCan":
                            var elem = document.getElementById("CapCantMerma");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("CapArt");
                            elem.style.display = (true ? "block" : "none");

                            document.getElementById(currentId).value = "";
                            document.getElementById("inArt").focus();
                            break;
                    }
                    break;
                default:


                    break;
            }
        }
            //enter
        else {
            switch (formName) {
                //Captura de Mercancia
                case "formCapturaMcia":
                    if (document.getElementById(currentId).value != "") {
                        switch (currentId) {
                            case "inArt":
                                var in_url = 'CaducaArticulo';
                                var u = in_url + "?inArt=" + document.getElementById(currentId).value
								+ "&t=" + Math.random();
                                GetReponseAjax(u, 'inArt', formName);
                                break;
                            case "inLot":
                                var in_url = 'CaducaLote';
                                var u = in_url + "?inLot=" + document.getElementById(currentId).value
								+ "&t=" + Math.random();
                                GetReponseAjax(u, 'inLot', formName);
                                break;
                            case "op":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        //Pantalla 7
                                        var elem = document.getElementById("LoteReg");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapturaCant");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "CapturaCant");
                                        document.getElementById(currentId).value = "";
                                        document.getElementById("inCan").focus();
                                        break;
                                    case "2":
                                        //Pantalla 2
                                        var elem = document.getElementById("LoteReg");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("Lote");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "Lote");
                                        document.getElementById(currentId).value = "";
                                        setEmptyValue("inLot");
                                        document.getElementById("inLot").focus();
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "inFec":
                                var in_url = 'CaducaFecCaducidad';
                                var u = in_url + "?inFec=" + document.getElementById(currentId).value
                                + "&inLot=" + document.getElementById("inLot").value
								+ "&t=" + Math.random();
                                GetReponseAjax(u, 'inFec', formName);
                                break;
                            case "op2":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var in_url = 'ValPantalla';
                                        var u = in_url + "?t=" + Math.random();
                                        GetReponseAjax(u, 'op2', formName);
                                        break;
                                    case "2":
                                        var elem = document.getElementById("ConservaFec");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("FecCad");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "FecCad");
                                        setEmptyValue("inFec");
                                        document.getElementById("op2").value = "";
                                        document.getElementById("inFec").focus();
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "op3":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var elem = document.getElementById("CoincideFec");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapturaCant");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "CapturaCant");
                                        setEmptyValue(currentId);
                                        setEmptyValue("inCan");
                                        document.getElementById("inCan").focus();
                                        break;
                                    case "2":
                                        var elem = document.getElementById("ConservaFec");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("FecCad");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "FecCad");
                                        setEmptyValue(currentId);
                                        setEmptyValue("inFec");
                                        document.getElementById("inFec").focus();
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "inCan":
                                if (parseFloat(document.getElementById(currentId).value) > 0) {
                                    var in_url = 'CaducaCantidad';
                                    var u = in_url + "?inCan=" + document.getElementById(currentId).value
                                    + "&inLot=" + document.getElementById("inLot").value
                                    + "&inFec=" + document.getElementById("inFec").value
									+ "&t=" + Math.random();
                                    GetReponseAjax(u, 'inCan', formName);
                                }
                                else {
                                    document.getElementById(currentId).focus();
                                }
                                break;
                            case "op4":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                    case "2":
                                        var in_url = 'CaducaSalir';
                                        var u = in_url + "?op4=" + document.getElementById(currentId).value
										+ "&t=" + Math.random();
                                        GetReponseAjax(u, 'op4', formName);
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            default:
                                document.getElementById(nextId).focus();
                                break;
                        }
                    }
                    else {
                        document.getElementById(currentId).focus();
                    }
                    break;
                    //Autoriza Merma
                case "formAutorizaMerma":
                    if (document.getElementById(currentId).value != "") {
                        switch (currentId) {
                            case "cmb_JEFE":
                                var combo = document.getElementById("cmb_JEFE");
                                var selected = combo.options[combo.selectedIndex].value;

                                if (selected == "Salir") {
                                    var in_url = 'AutMermaValidaCodigos';
                                    var u = in_url + "?t=" + Math.random();
                                    GetReponseAjax(u, 'cmb_JEFE', formName);
                                }
                                else {
                                    var in_url = 'AutMermaMostrarJD';
                                    var u = in_url + "?cmb_JEFE=" + selected
									+ "&t=" + Math.random();
                                    GetReponseAjax(u, 'cmb_JEFE', formName);
                                }
                                break;
                            case "inArt":
                                var combo = document.getElementById("cmb_JEFE");
                                var selected = combo.options[combo.selectedIndex].value;

                                var in_url = 'AutMermaArticulo';
                                var u = in_url + "?cmb_JEFE=" + selected
                                + "&inArt=" + document.getElementById(currentId).value
								+ "&t=" + Math.random();
                                GetReponseAjax(u, 'inArt', formName);
                                break;
                            case "op":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var elem = document.getElementById("ModCant");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapCantMerma");
                                        elem.style.display = (true ? "block" : "none");

                                        document.getElementById(currentId).value = "";
                                        document.getElementById("inCan").focus();
                                        break;
                                    case "2":
                                        var elem = document.getElementById("ModCant");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapArt");
                                        elem.style.display = (true ? "block" : "none");

                                        document.getElementById(currentId).value = "";
                                        document.getElementById("inArt").focus();
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "inCan":
                                var in_url = 'AutMermaCantidad';
                                var u = in_url + "?Existe=" + document.getElementById("Existe").innerHTML
                                + "&inCan=" + document.getElementById(currentId).value
                                + "&inArt=" + document.getElementById("inArt").value
								+ "&t=" + Math.random();
                                GetReponseAjax(u, 'inCan', formName);
                                break;
                            case "op2":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var in_url = 'AutMermaSalir';
                                        var u = in_url + "?t=" + Math.random();
                                        GetReponseAjax(u, 'op2', formName);
                                        break;
                                    case "2":
                                        redirect('/MciaPorCaducar/AutorizaMerma');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;

                            case "op3":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "op4":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            default:
                                document.getElementById(nextId).focus();
                                break;
                        }
                    }
                    else {
                        document.getElementById(currentId).focus();
                    }
                    break;
                default:

                    break;
            }
        }

    }
        //OTRO NAVEGADOR
    else {
        //enter
        if (event.keyCode == 13) {
            switch (formName) {
                //Captura de Mercancia
                case "formCapturaMcia":
                    debugger;
                    if (document.getElementById(currentId).value != "") {
                        switch (currentId) {
                            case "inArt":
                                var in_url = 'CaducaArticulo';
                                var u = in_url + "?inArt=" + document.getElementById(currentId).value
                                + "&t=" + Math.random();
                                GetReponseAjax(u, 'inArt', formName);
                                break;
                            case "inLot":
                                var in_url = 'CaducaLote';
                                var u = in_url + "?inLot=" + document.getElementById(currentId).value
                                + "&t=" + Math.random();
                                GetReponseAjax(u, 'inLot', formName);
                                break;
                            case "op":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        //Pantalla 7
                                        var elem = document.getElementById("LoteReg");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapturaCant");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "CapturaCant");
                                        document.getElementById(currentId).value = "";
                                        document.getElementById("inCan").focus();
                                        break;
                                    case "2":
                                        //Pantalla 2
                                        var elem = document.getElementById("LoteReg");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("Lote");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "Lote");
                                        document.getElementById(currentId).value = "";
                                        setEmptyValue("inLot");
                                        document.getElementById("inLot").focus();
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "inFec":
                                var in_url = 'CaducaFecCaducidad';
                                var u = in_url + "?inFec=" + document.getElementById(currentId).value
                                + "&inLot=" + document.getElementById("inLot").value
                                + "&t=" + Math.random();
                                GetReponseAjax(u, 'inFec', formName);
                                break;
                            case "op2":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var in_url = 'ValPantalla';
                                        var u = in_url + "?t=" + Math.random();
                                        GetReponseAjax(u, 'op2', formName);
                                        break;
                                    case "2":
                                        var elem = document.getElementById("ConservaFec");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("FecCad");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "FecCad");
                                        setEmptyValue("inFec");
                                        document.getElementById("op2").value = "";
                                        document.getElementById("inFec").focus();
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "op3":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var elem = document.getElementById("CoincideFec");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapturaCant");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "CapturaCant");
                                        setEmptyValue(currentId);
                                        setEmptyValue("inCan");
                                        document.getElementById("inCan").focus();
                                        break;
                                    case "2":
                                        var elem = document.getElementById("ConservaFec");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("FecCad");
                                        elem.style.display = (true ? "block" : "none");

                                        setValue("flagOpcion", "FecCad");
                                        setEmptyValue(currentId);
                                        setEmptyValue("inFec");
                                        document.getElementById("inFec").focus();
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "inCan":
                                if (parseFloat(document.getElementById(currentId).value) > 0) {
                                    var in_url = 'CaducaCantidad';
                                    var u = in_url + "?inCan=" + document.getElementById(currentId).value
                                    + "&inLot=" + document.getElementById("inLot").value
                                    + "&inFec=" + document.getElementById("inFec").value
                                    + "&t=" + Math.random();
                                    GetReponseAjax(u, 'inCan', formName);
                                }
                                else {
                                    document.getElementById(currentId).focus();
                                }
                                break;
                            case "op4":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                    case "2":
                                        var in_url = 'CaducaSalir';
                                        var u = in_url + "?op4=" + document.getElementById(currentId).value
                                        + "&t=" + Math.random();
                                        GetReponseAjax(u, 'op4', formName);
                                        break;
                                    case "L":
                                    case "l":
                                        redirect('/Menu/logOut');
                                        break;
                                    case "H":
                                    case "h":
                                        redirect('/Menu/pagLog');
                                        break;
                                    case "0":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            default:
                                document.getElementById(nextId).focus();
                                break;
                        }
                    }
                    else {
                        document.getElementById(currentId).focus();
                    }
                    break;
                    //Autoriza Merma
                case "formAutorizaMerma":
                    debugger;
                    if (document.getElementById(currentId).value != "") {
                        switch (currentId) {
                            case "cmb_JEFE":
                                var combo = document.getElementById("cmb_JEFE");
                                var selected = combo.options[combo.selectedIndex].value;

                                if (selected == "Salir") {
                                    var in_url = 'AutMermaValidaCodigos';
                                    var u = in_url + "?t=" + Math.random();
                                    GetReponseAjax(u, 'cmb_JEFE', formName);
                                }
                                else {
                                    var in_url = 'AutMermaMostrarJD';
                                    var u = in_url + "?cmb_JEFE=" + selected
                                    + "&t=" + Math.random();
                                    GetReponseAjax(u, 'cmb_JEFE', formName);
                                }
                                break;
                            case "inArt":
                                var combo = document.getElementById("cmb_JEFE");
                                var selected = combo.options[combo.selectedIndex].value;

                                var in_url = 'AutMermaArticulo';
                                var u = in_url + "?cmb_JEFE=" + selected
                                + "&inArt=" + document.getElementById(currentId).value
                                + "&t=" + Math.random();
                                GetReponseAjax(u, 'inArt', formName);
                                break;
                            case "op":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var elem = document.getElementById("ModCant");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapCantMerma");
                                        elem.style.display = (true ? "block" : "none");

                                        document.getElementById(currentId).value = "";
                                        document.getElementById("inCan").focus();
                                        break;
                                    case "2":
                                        var elem = document.getElementById("ModCant");
                                        elem.style.display = (false ? "block" : "none");
                                        var elem = document.getElementById("CapArt");
                                        elem.style.display = (true ? "block" : "none");

                                        document.getElementById(currentId).value = "";
                                        document.getElementById("inArt").focus();
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "inCan":
                                var in_url = 'AutMermaCantidad';
                                var u = in_url + "?Existe=" + document.getElementById("Existe").innerHTML
                                + "&inCan=" + document.getElementById(currentId).value
                                + "&inArt=" + document.getElementById("inArt").value
                                + "&t=" + Math.random();
                                GetReponseAjax(u, 'inCan', formName);
                                break;
                            case "op2":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        var in_url = 'AutMermaSalir';
                                        var u = in_url + "?t=" + Math.random();
                                        GetReponseAjax(u, 'op2', formName);
                                        break;
                                    case "2":
                                        redirect('/MciaPorCaducar/mAutorizaMerma');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;

                            case "op3":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            case "op4":
                                var op = document.getElementById(currentId).value;
                                switch (op) {
                                    case "1":
                                        redirect('/Menu');
                                        break;
                                    default:
                                        document.getElementById(currentId).focus();
                                        break;
                                }
                                break;
                            default:
                                document.getElementById(nextId).focus();
                                break;
                        }
                    }
                    else {
                        document.getElementById(currentId).focus();
                    }
                    break;

            }
        }
            //esc
        else if (event.keyCode == 27 || event.keyCode == 83 || event.keyCode == 115 || document.getElementById(x.id).value == 's' || document.getElementById(x.id).value == 'S') {
            switch (formName) {
                //Captura de Mercancia
                case "formCapturaMcia":
                    switch (currentId) {
                        case "inArt":
                            //Panatlla 8
                            var elem = document.getElementById("Principal");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("NoCerrado");
                            elem.style.display = (true ? "block" : "none");

                            document.getElementById(currentId).value = "";
                            document.getElementById("op4").focus();
                            break;
                        case "inLot":
                            redirect('/MciaPorCaducar/mCapturaMcia');
                            break;
                        case "inFec":
                            var elem = document.getElementById("FecCad");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("Lote");
                            elem.style.display = (true ? "block" : "none");

                            setEmptyValue("inLot");
                            document.getElementById(currentId).value = "";
                            document.getElementById("inLot").focus();
                            break;
                        case "inCan":
                            var elem = document.getElementById("CapturaCant");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("FecCad");
                            elem.style.display = (true ? "block" : "none");

                            setEmptyValue("inFec");
                            document.getElementById(currentId).value = "";
                            document.getElementById("inFec").focus();
                            break;
                        case "op4":
                            redirect('/MciaPorCaducar/mCapturaMcia');
                            break;
                        default:

                            break;
                    }
                    break;
                    //Autoriza Merma
                case "formAutorizaMerma":
                    switch (currentId) {
                        case "inArt":
                            redirect('/MciaPorCaducar/mAutorizaMerma');
                            //Pantalla 1
                            break;
                        case "inCan":
                            var elem = document.getElementById("CapCantMerma");
                            elem.style.display = (false ? "block" : "none");
                            var elem = document.getElementById("CapArt");
                            elem.style.display = (true ? "block" : "none");

                            document.getElementById(currentId).value = "";
                            document.getElementById("inArt").focus();
                            break;
                    }
                    break;
                default:


                    break;
            }

        }
        else {
            switch (formName) {
                case "formAutorizaMerma":
                    if (document.getElementById(currentId).value != "") {
                        switch (currentId) {
                            case "cmb_JEFE":
                                var combo = document.getElementById("cmb_JEFE");
                                var selected = combo.options[combo.selectedIndex].value;

                                if (selected == "Salir") {
                                    var in_url = 'AutMermaValidaCodigos';
                                    var u = in_url + "?t=" + Math.random();
                                    GetReponseAjax(u, 'cmb_JEFE', formName);
                                }
                                else {
                                    var in_url = 'AutMermaMostrarJD';
                                    var u = in_url + "?cmb_JEFE=" + selected
                                    + "&t=" + Math.random();
                                    GetReponseAjax(u, 'cmb_JEFE', formName);
                                }
                                break;
                        }
                    }
                    else {
                        document.getElementById(currentId).focus();
                    }
                    break;
            }
        }
    }
}

function funReady(idDiv, form) {
    //debugger;
    if (idDiv != "" && idDiv != undefined) {
        var ele = document.getElementById(idDiv);

        var divs = document.getElementsByTagName("div"), i = divs.length;
        while (i--) {
            if (divs[i].getAttribute(["id"]) != null && divs[i].getAttribute(["id"]) != undefined && divs[i].getAttribute(["id"]) != "") {
                var formulario = document.getElementById(divs[i].getAttribute(["id"])).parentNode;
                if (formulario.id == form) {
                    // alert(divs[i].getAttribute(["id"]));
                    document.getElementById(divs[i].getAttribute(["id"])).style.display = "none";
                }
            }
        }
        ele.style.display = "block";

        if (form == "" || form == undefined) {
            form = document.getElementById(idDiv).parentNode.id;

        }
    }
    else {
        idDiv = document.getElementById("flagOpcion").value;
        var ele = document.getElementById(idDiv);
        ele.style.display = "block";

        if (form == "" || form == undefined) {
            form = document.getElementById("flagOpcion").parentNode.id;
        }
    }

    switch (form) {
        //Captura de Mercancia
        case "formCapturaMcia":
            switch (idDiv) {
                default:
                    SetFocus();
                    break;
            }
            break;
            //Autoriza Merma
        case "formAutorizaMerma":
            switch (idDiv) {
                case "FolGen":
                    if (!IsOperaMobile) {
                        document.getElementById("op3").value = 1;
                        document.getElementById("op3").focus();
                    }
                    SetFocus();
                    break;
                case "NoGen":
                    if (!IsOperaMobile) {
                        document.getElementById("op4").value = 1;
                        document.getElementById("op4").focus();
                    }
                    SetFocus();
                    break;
                default:
                    SetFocus();
                    break;
            }
            break;
        default:

            break;
    }

    for (i = 0; i < 11; i++) {
        if (i == 10) {
            document.getElementById("FocusOn").focus();
        }
    }
}

function redirect(url) {
    debugger;
    var ua = navigator.userAgent.toLowerCase(),
        isIE = ua.indexOf('msie') !== -1,
        version = parseInt(ua.substr(4, 2), 10);

    var varName = document.getElementById("nombreSitio").value;

    // Internet Explorer 8 and lower
    if (isIE && version < 9) {
        var link = document.createElement('a');
        link.href = "/" + varName + url;
        document.body.appendChild(link);
        link.click();
    }
        // All other browsers can use the standard window.location.href (they don't lose HTTP_REFERER like Internet Explorer 8 & lower does)
    else {
        window.location.href = "/" + varName + url;
    }
}