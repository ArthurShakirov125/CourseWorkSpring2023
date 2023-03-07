var uploadField = document.getElementById("avatar");

uploadField.onchange = function () {
    if (this.files[0].size > 2097152) {
        let errorsFiled = document.getElementById("Input_avatar-error");
        errorsFiled.innerText = "Размер изображения не должен превышать 2 мегабайта";

        this.value = "";
    }
    else {
        $("#Input_avatar-error").text("");
    };
};