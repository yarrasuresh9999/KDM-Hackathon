$(function () {
    // ADD SLIDEDOWN ANIMATION TO DROPDOWN //
    $('.dropdown').on('show.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().slideDown();
    });

    // ADD SLIDEUP ANIMATION TO DROPDOWN //
    $('.dropdown').on('hide.bs.dropdown', function (e) {
        $(this).find('.dropdown-menu').first().slideUp();
    });

    /*Enable Tooltips*/
    $('[data-toggle="tooltip"]').tooltip();

    $(".navbar-nav>li>a").filter(function (index) {
        if ((this.href).slice(-1) != '#' && ((location.pathname).slice(-1) != "/")) {
            $(".navbar-nav>li").removeClass("active");
            return this.href.search(location.pathname) !== -1;
        }
    }).parent("li").addClass("active");

    $("#lbtnLogin").click(function (e) {
        $("#btnLogin").button('loading');
        $(".login-alert").fadeIn("slow", function () { $("#btnLogin").button('reset'); }).delay(2000).fadeOut("slow");
    });

    $("#primary-search").click(function (e) {
        $("#primary-search").button('loading');
        $(".search-result").remove();
        $(".search-menu").append('<li class="search-result"><a href="#">Student Test</a></li><li class="search-result"><a href="#">Employee Test</a></li><li class="search-result"><a href="#">Result Test</a></li>');
        $("#primary-search").button('reset');
    });

});