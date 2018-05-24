
$(document).ready(function () {

    $("#privacyLinkId").click(function (event) {

        event.preventDefault();

        var url = $(this).attr("href");

        $("#privacy").load(url);
    });
});