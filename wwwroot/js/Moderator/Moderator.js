window.onload = function () {

    let dataObject = new Object();

    $(".moder_btn_hide").click(function () {
        let id = $(this).parent().attr("data-id");
        dataObject.Action = "hide";
        dataObject.Id = id;
        MyRequest();
    });

    $(".moder_btn_unhide").click(function () {
        let id = $(this).parent().attr("data-id");
        dataObject.Action = "unhide";
        dataObject.Id = id;
        MyRequest();
    });

    $(".moder_btn_delete").click(function () {
        let id = $(this).parent().attr("data-id");
        console.log($(this).parent().attr("data-content-type"));
        if ($(this).parent().attr("data-content-type") == "post") {
            dataObject.Action = "delete_post";
        }
        else if ($(this).parent().attr("data-content-type") == "comment") {
            dataObject.Action = "delete_comment";
        }
        
        dataObject.Id = id;
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
}
