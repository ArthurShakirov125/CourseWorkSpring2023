function Show(Id) {
    var elem = document.getElementById(Id);
    elem.classList.remove("custom-postIsHidden");
}

function Hide(Id) {
    var elem = document.getElementById(Id);
    elem.classList.add("custom-postIsHidden");
}

function Delete(Id) {
    var elem = document.getElementById(Id);
    elem.remove();
}