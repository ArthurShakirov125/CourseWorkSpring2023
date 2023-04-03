function Show(Id) {
    let elem = document.getElementById(Id);
    elem.classList.remove("custom-postIsHidden");
}

function Hide(Id) {
    let elem = document.getElementById(Id);
    elem.classList.add("custom-postIsHidden");
}

function Delete(Id) {
    let elem = document.getElementById(Id);
    elem.remove();
}