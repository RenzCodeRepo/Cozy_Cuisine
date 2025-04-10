document.addEventListener("DOMContentLoaded", function () {
    new Swiper(".meal-swiper", {
        slidesPerView: 3,
        spaceBetween: 5,
        loop: true,
        navigation: {
            nextEl: ".meal-next",
            prevEl: ".meal-prev",
        },
        breakpoints: {
            768: { slidesPerView: 2 },
            576: { slidesPerView: 1 }
        }
    });
    new Swiper(".ingredient-swiper", {
        slidesPerView: 3,
        spaceBetween: 5,
        loop: true,
        navigation: {
            nextEl: ".ingredient-next",
            prevEl: ".ingredient-prev",
        },
        breakpoints: {
            768: { slidesPerView: 2 },
            576: { slidesPerView: 1 }
        }
    });
    new Swiper(".equipments-swiper", {
        slidesPerView: 3,
        spaceBetween: 5,
        loop: true,
        navigation: {
            nextEl: ".equipment-next",
            prevEl: ".equipment-prev",
        },
        breakpoints: {
            768: { slidesPerView: 2 },
            576: { slidesPerView: 1 }
        }
    });
    new Swiper('#videoCarousel', {
        slidesPerView: 5,
        spaceBetween: 20,
        loop: false,
        centeredSlides: false,
        navigation: {
            nextEl: '.video-next',
            prevEl: '.video-prev',
        },
        breakpoints: {
            1024: {
                slidesPerView: 3,
            },
            768: {
                slidesPerView: 2,
            },
            576: {
                slidesPerView: 1,
            }
        }
    });
    new Swiper(".image-swiper", {
        slidesPerView: 3,
        spaceBetween: 5,
        loop: false,
        centeredSlides: false,  
        navigation: {
            nextEl: ".image-next",
            prevEl: ".image-prev",
        },
        breakpoints: {
            1024: {
                slidesPerView: 3,
            },
            768: {
                slidesPerView: 2,
            },
            576: {
                slidesPerView: 1,
            }
        }
    });

});
