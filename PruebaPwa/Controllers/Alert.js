
let ReloadPage = "";

function Alert(Msg, Reload) {
    let Alert = document.getElementById("Alert");
    let AlertTitle = document.getElementById("AlertTitle");
    let AlertText = document.getElementById("AlertText");
    AlertTitle.innerText = "Importante";
    AlertText.innerText = Msg.includes("<") ? Msg.split("<")[0] : Msg;
    Alert.style.display = "block";
    ReloadPage = Reload;
};

function CloseElemnt() {
    let ElementView = document.getElementById("Alert");
    if (ElementView.style.display == "block") {
        ElementView.style.display = "none";
        if (ReloadPage == "Reload") {
            location.reload();
        }
    } else {
        ElementView.style.display = "block"
    }

}
function Close(item) {
    let ElementView = document.getElementById(item);
    if (ElementView.style.display == "block") {
        ElementView.style.display = "none";        
    } else {
        ElementView.style.display = "block"
    }

}



function Reload() {
    location.reload();

}