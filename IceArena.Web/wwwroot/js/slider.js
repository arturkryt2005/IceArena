window.initializeCarousel = function () {
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
};