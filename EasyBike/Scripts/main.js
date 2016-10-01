//main function
$(function () {

    //load first time logo

    var xSeconds = 2000; // 2 second
    setTimeout(function () {

        $('#loadPageImage').fadeOut('fast');
        $('#loadPageImage').hide();

    }, xSeconds);

    // logo fade in
    $(document.body).ready(function () {
        $("#buttonsStart ,#logoMainPage").hide();
        setTimeout(function () {
            var page = $("#logoMainPage");
            page.fadeIn('slow');
        }, 3000);

        setTimeout(function () {
            var page = $("#buttonsStart");
            page.fadeIn('slow');
        }, 3500);

    });

    //show hide rent me button fixed 
    $("#rentCircleFixed").hide();
    $(window).scroll(function () {
        if ($(window).scrollTop() > 100) {
            $("#rentCircleFixed").fadeIn("slow");
        } else {
            $("#rentCircleFixed").fadeOut("fast");
        }
    });

    // carousel optsions
    $('.carousel').carousel({
        interval: 3000
    });

    //navbar menu side
    $("#open").click(function () {
        $("#mySidenav").css("width", "250px");
    });

    $("#closebtn").click(function () {
        $("#mySidenav").css("width", "0");
    });



    //end of main function  



});

function PackagesHandler() {

    $(".package").show();
}