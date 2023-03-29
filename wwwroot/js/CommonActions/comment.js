$(".leave_comment_btn").click(function () {
    let txt = $(".comment_text").val();

    if (!txt) {
        // добавить валидацию
        return;
    }

    let dataObject = new Object();
    dataObject.Text = txt;
    dataObject.PostId = $(".postId").text();
    dataObject.Action = "comment";

    $.ajax({
        type: "POST",
        url: "/Home/GetAjax",
        data: dataObject,
        success: function (data) {
            if (data.reply == 200) {
                commentsSuccess(data);
            }
            else if (data.reply = 400) {
                alert("error 400");
            }
        },
        failure: function (err) {

        }
    });


    function commentsSuccess(data) {
        if ($(".comment-section").children(".no-comments").length) {
            // комментариев ещё нет
            $(".comment-section").children(".no-comments").remove();
        }

        // комменты уже есть
        let comment = $("<div></div>");

        $(comment).addClass("comment").addClass("content");
        $(comment).append("<h4>" + data.username + "</h4>");
        $(comment).append('<p>' + txt + '</p');
        $(comment).append('<p>Рейтинг:</p> <p class="rating">0</p>');
        let likeBtn = $('<button class="btn btn-secondary likeBtn" data-isPicked="false" data-Id=' + data.commentId + ' data-action="upvote">+</button> ');
        let disBtn = $('<button class="btn btn-secondary dislikeBtn" data-isPicked="false" data-Id=' + data.commentId + ' data-action="downpvote">-</button>');

        $(likeBtn).click(upvote);
        $(disBtn).click(downvote);

        $(comment).append(likeBtn);
        $(comment).append(disBtn);

        $(".comment-section").append(comment);
    }
});