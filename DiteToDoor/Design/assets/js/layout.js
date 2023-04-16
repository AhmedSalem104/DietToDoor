const hamburgerButton = document.querySelector(".hamburger");
const responsiveNavbar = document.querySelector(".responsive-navbar");
hamburgerButton.addEventListener("click", () => {
    hamburgerButton.classList.toggle("active");
    responsiveNavbar.classList.toggle("active");
});
document.querySelector(".navbar-nav").addEventListener("click", (event) => {
    if (event.target.classList.contains("nav-link")) {
        hamburgerButton.classList.remove("active");
        responsiveNavbar.classList.remove("active");
    }
});
