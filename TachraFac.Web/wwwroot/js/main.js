(function ($) {
    "use strict";

    // ============================
    // Spinner Removal on Page Load
    // ============================
    const spinner = () => setTimeout(() => $('#spinner').removeClass('show'), 1);
    if ($('#spinner').length) spinner();

    // ============================
    // Initialize WOW.js for Animations
    // ============================
    new WOW().init();

    // ============================
    // Fixed Navbar Behavior on Scroll
    // ============================
    const $fixedTop = $('.fixed-top');
    const topBarHeight = $('.top-bar').height();
    $fixedTop.css('top', topBarHeight);

    $(window).on('scroll', function () {
        $fixedTop.toggleClass('bg-dark', $(this).scrollTop() > 0)
                 .css('top', $(this).scrollTop() > 0 ? 0 : topBarHeight);
    });

    // ============================
    // Back to Top Button Behavior
    // ============================
    const $backToTop = $('.back-to-top');

    $(window).on('scroll', function () {
        $backToTop.fadeToggle($(this).scrollTop() > 300, 'slow');
    });

    $backToTop.on('click', () => {
        $('html, body').animate({ scrollTop: 0 }, 1500, 'easeInOutExpo');
    });

    // ============================
    // Carousel Initialization (Reused)
    // ============================
    const initCarousel = (selector, options) => $(selector).owlCarousel(options);

    initCarousel(".header-carousel", {
        autoplay: false,
        smartSpeed: 1500,
        loop: true,
        nav: true,
        dots: false,
        items: 1,
        navText: ['<i class="bi bi-chevron-left"></i>', '<i class="bi bi-chevron-right"></i>']
    });

    initCarousel(".testimonial-carousel", {
        autoplay: false,
        smartSpeed: 1000,
        margin: 25,
        loop: true,
        center: true,
        dots: false,
        nav: true,
        navText: ['<i class="bi bi-chevron-left"></i>', '<i class="bi bi-chevron-right"></i>'],
        responsive: {
            0: { items: 1 },
            768: { items: 2 },
            992: { items: 3 }
        }
    });

    // ============================
    // Counter for Facts Section
    // ============================
    $('[data-toggle="counter-up"]').counterUp({
        delay: 10,
        time: 2000
    });

})(jQuery);
