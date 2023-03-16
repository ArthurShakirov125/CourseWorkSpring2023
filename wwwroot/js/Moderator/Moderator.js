window.onload = function () {

    let dataObject = new Object();

    $(".moder_btn_hide").click(function () {
        FindId($(this));
        dataObject.Action = "hide";
        MyRequest();
    });

    $(".moder_btn_unhide").click(function () {
        FindId($(this));
        dataObject.Action = "unhide";
        MyRequest();
    });

    $(".moder_btn_delete").click(function () {
        FindId($(this));
        if ($(this).closest(".moder_tools").attr("data-content-type") == "post") {
            dataObject.Action = "delete_post";
            $(this).closest(".post").remove();
        }
        else if ($(this).closest(".moder_tools").attr("data-content-type") == "comment") {
            dataObject.Action = "delete_comment";
            $(this).closest(".comment").remove();
        }
        MyRequest();
    });

    function MyRequest() {
        $.ajax({
            type: "POST",
            url: "/Home/GetAjax",
            data: dataObject,
            success: function (data) {
                console.log(data);
                if (data.reply == 200) {
                }
                else if (data.reply == 400) {
                    alert("error 400");
                }
            },
            failure: function (err) {

            }
        });
    }

    function FindId(elem) {
        let id = elem.closest(".moder_tools").attr("data-id");
        dataObject.Id = id;
    }
}
