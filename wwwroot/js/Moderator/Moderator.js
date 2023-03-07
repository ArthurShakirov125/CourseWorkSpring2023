window.onload = function () {

    let dataObject = new Object();

    $(".moder_btn_hide").click(function () {
        let id = $(this).parent().attr("data-id");
        dataObject.Action = "hide_post";
        dataObject.Id = id;
        MyRequest();
    });

    $(".moder_btn_unhide").click(function () {
        let id = $(this).parent().attr("data-id");
        dataObject.Action = "unhide_post";
        dataObject.Id = id;
        MyRequest();
    });

    $(".moder_btn_delete").click(function () {
        let id = $(this).parent().attr("data-id");
        dataObject.Action = "delete_post";
        dataObject.Id = id;
        MyRequest();
    });

    function MyRequest() {
        $.ajax({
            type: "POST",
            url: "/Home/GetAjax",
            data: dataObject,
            success: function (data) {
                if (data == "200") {
                }
                else if (data = "400") {
                    alert("error 400");
                }
            },
            failure: function (err) {

            }
        });
    }
}
