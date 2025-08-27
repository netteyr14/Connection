document.querySelectorAll('.fancy-hover-btn').forEach(btn => { // Select all buttons with the class 'fancy-hover-btn'
  btn.addEventListener('mousemove', (e) => {
    const rect = btn.getBoundingClientRect();
    const x = e.clientX - rect.left;
    const y = e.clientY - rect.top;
    btn.style.setProperty('--x', `${x}px`);
    btn.style.setProperty('--y', `${y}px`);
  });
});

const myCarousel = document.querySelector('#carouselWindow');
const carousel = bootstrap.Carousel.getOrCreateInstance(myCarousel);

// ✅ Start auto sliding on first load if the active slide is an image
window.addEventListener('load', () => {
  const activeSlide = myCarousel.querySelector('.carousel-item.active');
  if (activeSlide.querySelector('img')) {
    carousel.cycle(); // Start auto slide immediately
  }

  const firstSlide = myCarousel.querySelector('.carousel-item.active');
  if (firstSlide.querySelector('img')) {
    const delay = parseInt(firstSlide.getAttribute('data-interval')) || 5000;
    setTimeout(() => {
      carousel.next();
    }, delay);
  }
});

myCarousel.addEventListener('slid.bs.carousel', function () {
  // Mute and pause all videos first
  const allVideos = myCarousel.querySelectorAll('video');
  allVideos.forEach(v => {
    v.pause();
    v.currentTime = 0;
    v.muted = true;
  });

  const activeSlide = myCarousel.querySelector('.carousel-item.active');
  const activeVideo = activeSlide.querySelector('video');
  const activeImage = activeSlide.querySelector('img');

  if (activeVideo) {
    carousel.pause(); // Stop auto sliding
    activeVideo.muted = false; // Unmute the current video
    activeVideo.currentTime = 0;
    activeVideo.play();

    activeVideo.onended = () => {
      activeVideo.muted = true;
      carousel.cycle(); // Resume auto sliding after video ends
    };
  }
  
  if (activeImage) {
    carousel.cycle(); // Continue auto sliding for image-only slides
  }
});
