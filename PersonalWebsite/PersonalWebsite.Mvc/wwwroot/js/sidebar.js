let sidebar = document.querySelector(".sidebar");
        let closeBtn = document.querySelector("#btn");
        let searchBtn = document.querySelector(".bx-search");
        let placeholder = document.querySelector("#plc-src");
        let logo_img = document.querySelector("#logo_img");
        let arrow = document.querySelectorAll(".arrow");
        for (var i = 0; i < arrow.length; i++){
            arrow[i].addEventListener("click", (e) => {
                let arrowParent = e.target.parentElement.parentElement;
                arrowParent.classList.toggle("showMenu");
            });
        }

        closeBtn.addEventListener("click", () => {
            sidebar.classList.toggle("open");
            placeholder.classList.toggle("placeholder");
            //menuBtnChange();
        });

        searchBtn.addEventListener("click", () => {
            sidebar.classList.toggle("open");
            placeholder.classList.toggle("placeholder");
            //menuBtnChange();
        });

        logo_img.addEventListener("click", () => {
            sidebar.classList.toggle("open");
            placeholder.classList.toggle("placeholder");
        })