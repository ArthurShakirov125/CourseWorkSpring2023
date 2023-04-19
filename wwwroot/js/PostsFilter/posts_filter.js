let isWindowShowing = false;


$(".component-post_filter_btn").click(function () {
    if (isWindowShowing) {
        $(".component-post_filter").css("display", "none");
        isWindowShowing = false;
    }
    else {
        $(".component-post_filter").css({ "display": "flex", "flex-direction": "column" });
        isWindowShowing = true;
    }
});