function validate() {
    var name = document.getElementById("name").value;
    var subject = document.getElementById("subject").value;
    var email = document.getElementById("email").value;
    var message = document.getElementById("message").value;
    var error_message = document.getElementById("error_message");
    var cinsiyet = document.getElementById("cinsiyet").checked;
    var okul = document.getElementById("okul");
    var bolge = document.getElementById("bolge");
    error_message.style.padding = "10px";
    var text;
    if (name == '') {
        text = "Adınızı giriniz";
        error_message.innerHTML = text;
        return false;
    }
    if (subject == '') {
        text = "Soyadınızı giriniz.";
        error_message.innerHTML = text;
        return false;
    }
    if (email.indexOf("@") == -1 || email.length < 6) {
        text = "E mail adresinizi doğru formatta giriniz.";
        error_message.innerHTML = text;
        return false;
    }
    if (cinsiyet == false) {
        text = "Cinsiyet boş.";
        error_message.innerHTML = text;
        return false;
    }
    if (okul.checked == false) {
        text = "Okul boş";
        error_message.innerHTML = text;
        return false;
    }
    if (bolge.value == "bolgeyok") {
        text = "bolge boş";
        error_message.innerHTML = text;
        return false;
    }
    if (message == '') {
        text = "Mesajı giriniz.";
        error_message.innerHTML = text;
        return false;
    }
    return true;
}
