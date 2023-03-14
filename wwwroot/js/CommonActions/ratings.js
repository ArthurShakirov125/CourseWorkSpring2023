function upvote() {

    let rating = parseInt($(this).parent().children(".rating").html());


    let mirror = $(this).next(".dislikeBtn");

    let dataObject = new Object();
    dataObject.Action = $(this).attr("data-action");
    dataObject.Id = $(this).attr("data-Id");

    let isDisPicked = mirror.attr("data-isPicked") == "true";
    let isLikePicked = $(this).attr("data-isPicked") == "true";



    if (!isDisPicked && !isLikePicked) { // обычный лайк
        $(this).removeClass("btn-secondary").addClass("btn-warning");
        $(this).attr("data-isPicked", "true");

        $(this).attr("data-action", "remove_upvote");
        mirror.attr("data-action", "downvote_and_remove_upvote");

        rating = rating + 1;

    }
    if (isLikePicked && !isDisPicked) { // убираем лайк
        $(this).removeClass("btn-warning").addClass("btn-secondary");
        $(this).attr("data-isPicked", "false");

        $(this).attr("data-action", "upvote");
        mirror.attr("data-action", "downvote");

        rating = rating - 1;
    }
    if (!isLikePicked && isDisPicked) { // меняем диз на лайк
        $(this).removeClass("btn-secondary").addClass("btn-warning");
        $(this).attr("data-isPicked", "true");

        mirror.removeClass("btn-warning").addClass("btn-secondary");
        mirror.attr("data-isPicked", "false");

        $(this).attr("data-action", "remove_upvote");
        mirror.attr("data-action", "downvote_and_remove_upvote");

        rating = rating + 2;
    }

    $(this).parent().children(".rating").text(rating);

    $.ajax({
        type: "POST",
        url: "/Home/GetAjax",
        data: dataObject,
        success: function (data) {
            if (data.reply == 200) {
            }
            else if (data.reply = 400) {
                alert("error 400");
            }
        },
        failure: function (err) {

        }
    })
};


function downvote() {

    let mirror = $(this).prev(".likeBtn");

    let dataObject = new Object();
    dataObject.Action = $(this).attr("data-action");
    dataObject.Id = $(this).attr("data-Id");

    let isDisPicked = mirror.attr("data-isPicked") == "true";
    let isLikePicked = $(this).attr("data-isPicked") == "true";

    let rating = parseInt($(this).parent().children(".rating").html());

    if (!isDisPicked && !isLikePicked) { // обычный диз
        $(this).removeClass("btn-secondary").addClass("btn-warning");
        $(this).attr("data-isPicked", "true");

        $(this).attr("data-action", "remove_downvote");
        mirror.attr("data-action", "upvote_and_remove_downvote");

        rating = rating - 1;

    }
    if (isLikePicked && !isDisPicked) { // убираем диз
        $(this).removeClass("btn-warning").addClass("btn-secondary");
        $(this).attr("data-isPicked", "false");

        $(this).attr("data-action", "downvote");
        mirror.attr("data-action", "upvote");

        rating = rating + 1;

    }
    if (!isLikePicked && isDisPicked) { // меняем лайк на диз
        $(this).removeClass("btn-secondary").addClass("btn-warning");
        $(this).attr("data-isPicked", "true");

        mirror.removeClass("btn-warning").addClass("btn-secondary");
        mirror.attr("data-isPicked", "false");

        $(this).attr("data-action", "remove_downvote");
        mirror.attr("data-action", "upvote_and_remove_downvote");

        rating = rating - 2;
    }

    $(this).parent().children(".rating").text(rating);

    $.ajax({
        type: "POST",
        url: "/Home/GetAjax",
        data: dataObject,
        success: function (data) {
            if (data.reply == 200) {
            }
            else if (data.reply = 400) {
                alert("error 400");
            }
        },
        failure: function (err) {

        }
    })
};

document.querySelectorAll(".likeBtn").forEach(btn => { btn.addEventListener("click", upvote) });
document.querySelectorAll(".dislikeBtn").forEach(btn => { btn.addEventListener("click", downvote) });
