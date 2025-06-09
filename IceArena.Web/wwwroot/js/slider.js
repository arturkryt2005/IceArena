function initializeMainCarousel() {
    const images = [
        'images/ledoviy.jpg',
        'images/ledoviyelka.jpg',
        'images/ledoviyotkryt.jpg'
    ];
    let currentIndex = 0;
    const imgElement = document.querySelector('.carousel img');
    const leftArrow = document.querySelector('.carousel .left');
    const rightArrow = document.querySelector('.carousel .right');

    function changeImage(nextIndex, direction) {
        imgElement.style.transition = 'transform 0.3s ease-in-out';
        imgElement.style.transform = `translateX(${direction === 'left' ? '-100%' : '100%'})`;
        setTimeout(() => {
            imgElement.style.transition = 'none';
            imgElement.src = images[nextIndex];
            imgElement.style.transform = `translateX(${direction === 'left' ? '100%' : '-100%'})`;
            setTimeout(() => {
                imgElement.style.transition = 'transform 0.3s ease-in-out';
                imgElement.style.transform = 'translateX(0)';
            }, 50);
        }, 300);
    }

    leftArrow.addEventListener('click', () => {
        currentIndex = (currentIndex === 0) ? images.length - 1 : currentIndex - 1;
        changeImage(currentIndex, 'right');
    });

    rightArrow.addEventListener('click', () => {
        currentIndex = (currentIndex === images.length - 1) ? 0 : currentIndex + 1;
        changeImage(currentIndex, 'left');
    });

    setInterval(() => {
        currentIndex = (currentIndex === images.length - 1) ? 0 : currentIndex + 1;
        changeImage(currentIndex, 'left');
    }, 5000);
}

function initializeAnnouncementsCarousel() {
    const carousel = new bootstrap.Carousel(document.getElementById('announcementsCarousel'), {
        interval: 5000,
        ride: 'carousel',
        wrap: true
    });

    // Кастомные стрелки
    const prevButton = document.querySelector('#announcementsCarousel .carousel-control-prev');
    const nextButton = document.querySelector('#announcementsCarousel .carousel-control-next');

    if (prevButton && nextButton) {
        prevButton.innerHTML = '<span class="carousel-control-prev-icon" aria-hidden="true"></span><span class="visually-hidden">Previous</span>';
        nextButton.innerHTML = '<span class="carousel-control-next-icon" aria-hidden="true"></span><span class="visually-hidden">Next</span>';
    }
}

window.initializeMainCarousel = initializeMainCarousel;
window.initializeAnnouncementsCarousel = initializeAnnouncementsCarousel;