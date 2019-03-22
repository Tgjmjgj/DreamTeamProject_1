
const errorTextBoxColor = "rgba(254, 100, 100, 0.8)";
const normalTextBoxColor = window.getComputedStyle(document.getElementById("name")).backgroundColor;
function register() {

    let name = document.getElementById("name");
    let surname = document.getElementById("surname");
    let email = document.getElementById("email");
    let phone = document.getElementById("phone");
    let password = document.getElementById("password");
    let confirm_password = document.getElementById("confirm_password");

    function checkElementAnEmpy(el) {

        if (el.value === "") {

            el.style.backgroundColor = errorTextBoxColor;
            return false;

        } else {
            
            el.style.backgroundColor = normalTextBoxColor;
            return true;
        }
    }

    let isOk = [name, surname, email, phone, password, confirm_password].every(checkElementAnEmpy);
    if (!isOk) return;

    if (password.value !== confirm_password.value) {

        password.style.backgroundColor = errorTextBoxColor;
        confirm_password.style.backgroundColor = errorTextBoxColor;
        return;

    }

    fetch("/api/users",
        {
            method: "POST",
            cache: "no-cache",
            headers: {
                "Content-Type": "application/json"  
            },
            body: {
                name, surname, email, phone, password, confirm_password
            }
        })
}

document.getElementById("register").addEventListener("click", register);