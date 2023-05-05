function replace_string(e) {
    e.value = e.value.replace(/[^0-9.]/g, "");
   
}
/* follow up function to open and close page it block on click and add animation  */
function followUpPage(popId, openButton, closeBtn) {
    const openFormBtn = document.querySelectorAll(openButton);
    const closeFormBtn = document.getElementById(closeBtn);
    const pop = document.getElementById(popId);
    const form = document.querySelector(`#${popId} #myForm`);
    const body = document.querySelector("body");
    const mainPop = document.querySelectorAll(".clouse")
    openFormBtn.forEach((e) => {
        e.addEventListener("click", () => {
            pop.style.display = "grid";
            body.style.cssText = " overflow:hidden;";
            form.animate(
                [
                    { transform: "scale(0.5)", opacity: 0 },
                    { transform: "scale(1)", opacity: 1 },
                ],
                {
                    duration: 500,
                    easing: "ease-out",
                }
            );
        });
    });

    function close() {
        form.animate(
            [
                { transform: "scale(1)", opacity: 1 },
                { transform: "scale(0.5)", opacity: 0 },
            ],
            {
                duration: 500,
                easing: "ease-out",
            }
        ).onfinish = () => (
            (pop.style.display = "none"), (body.style.cssText = " overflow-x:hidden;")
        );
    }
    closeFormBtn.addEventListener("click", () => {
        close()
    });
    mainPop.forEach((e) => {
        e.addEventListener("click", () => {
            close()
        });
    });
    /* function to get the data from upload button on follow up page and add some style to input */
    function uploadInputFollowUpPage(input, fileName, fileSize, label) {
        const inputFile = document.querySelector(`.${input}`);
        const fileNameField = document.querySelector(`.${fileName}`);
        const fileSizeField = document.querySelector(`.${fileSize}`);
        const fileIcon = document.querySelector(`${label} i`);
        inputFile.addEventListener("change", function () {
            fileIcon.style.color = "#A0B63B";
            const uploadedFileName = inputFile.files[0].name;
            fileNameField.textContent = uploadedFileName;
            const uploadedFileSize =
                Math.floor(inputFile.files[0].size / 1024) +
                "kb" +
                " . " +
                getDateNow();
            fileSizeField.textContent = uploadedFileSize;
        });
    }
    uploadInputFollowUpPage(
        "follow_upload",
        "file-name-follow",
        "file-size-follow",
        ".upload-label2"
    );
    uploadInputFollowUpPage(
        "contact_upload",
        "file-name-contact",
        "file-size-contact",
        ".upload-label1"
    );
}
followUpPage("pop-follow", ".follow", "closeForm");
followUpPage("pop-ContactUs", "#contact", "closeFormContact");
/* function return date now by formate dd / mm/ yy */
function getDateNow() {
    const today = new Date();
    const yyyy = today.getFullYear();
    let mm = today.getMonth() + 1; // Months start at 0!
    let dd = today.getDate();
    if (dd < 10) dd = "0" + dd;
    if (mm < 10) mm = "0" + mm;
    const formattedToday = dd + "/" + mm + "/" + yyyy;
    return formattedToday;
}
/*  function open and close responsive nav bar */
function responsiveHamburgerButton() {
    const hamburgerButton = document.querySelector(".hamburger");
    const responsiveNavbar = document.querySelector(".responsive-navbar");
    hamburgerButton.addEventListener("click", () => {
        hamburgerButton.classList.toggle("active");
        responsiveNavbar.classList.toggle("active");
    });
}
responsiveHamburgerButton();
