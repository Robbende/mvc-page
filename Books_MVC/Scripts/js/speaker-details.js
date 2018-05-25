

$(document).ready(function () {

    $("[name='SpeakerDetail']").click(function (e) {
        e.preventDefault();

        var el = $(this)

        var url = el.attr("href")
        var id = el.attr("spid")
        var data = { spid: id }

        $.ajax({
            url:url,
            type:"POST",
            data:JSON.stringify(data),
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            success: function(response){

                var speaker_content = "<div>" + response.FirstName + "</div><div>" + response.LastName + "</div><div><img class='profile-photo' src='" + response.PictureUrl + "'/></div>"

                $("#SpeakerInfo").html(speaker_content);
            }
        })

    });
});