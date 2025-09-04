document.addEventListener('DOMContentLoaded', function () {
    const navLinks = document.querySelectorAll('.navbar-collapse .nav-link');
    const navbarCollapse = document.querySelector('.navbar-collapse');

    navLinks.forEach(link => {
        link.addEventListener('click', () => {
            new bootstrap.Collapse(navbarCollapse).hide();
        });
    });
});

// Show scroll-to-top button
window.onscroll = function () {
    const btn = document.getElementById("scrollTopBtn");
    if (btn) {
        btn.style.display = (window.scrollY > 150) ? "block" : "none";
    }
};

function scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
