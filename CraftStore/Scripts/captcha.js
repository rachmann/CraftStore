$('#captchaimg').click(function () {
    $(this).attr('src', '@Url.Action("GetCaptcha", "Account", new {id = new Date().getTime())');

});

$(function () {

    var x = new Date().getTime();

    function getCaptcha() {
        $('#captchaimg').attr('src', '@Url.Action("GetCaptcha", "Account", new {id = new Date().getTime())');
    }

    getCaptcha();
});