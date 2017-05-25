
$(function () {
    /* smooth scrolling for scroll to top */
    $('#to-top').click(function () {
        $('body,html').animate({ scrollTop: 0 }, 1500);
    });
});
    //Easing Scroll replace Anchor name in URL and Offset Position
$(function () {
    $('a[href*=\\#]:not([href=\\#])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top - 420
                }, 3500, 'easeOutBounce');
                return false;
            }
        }
    });
});


$(document).ready(function () {

    $(".dropdown").hover(funDown,funUP);


    function funDown() {
        $('.dropdown-menu', this).not('.in .dropdown-menu').stop(true, true).slideDown('400');
     $(this).toggleClass('open');
 }
    function funUP() {
        $('.dropdown-menu', this).not('.in .dropdown-menu').slideUp('400');
     $(this).toggleClass('open');
 }
});


$(function () {

    $('#menu-toggle').mouseenter(fun_active).click(fun_active);
    $('#sidebar-wrapper').mouseleave(fun_uactive);
    $('#menu-close').click(fun_uactive);

    var sidebar_wrapper = $("#sidebar-wrapper");

    function fun_active(e) {
        sidebar_wrapper.toggleClass('active', true);
        e.preventDefault();
    }
    function fun_uactive(e) {
        sidebar_wrapper.toggleClass('active', false);
        e.stopPropagation();
        e.preventDefault();
    }

});

