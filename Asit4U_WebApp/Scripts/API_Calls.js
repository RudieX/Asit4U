function SendLoginRequest()
{
    var username = document.getElementById("txtUsername").value;
    var password = document.getElementById("txtPassword").value;

    $.ajax({
        url: "http://localhost:53594/api/Auth/",
        method: "POST",
        ContentType:"application/json",
        data: {
            Username: username,
            Password: password
        },
        success: function (result) {
            let message = result.Data.Message;
            $('#txtMsg').html(message);
        },
        error: function (message) {
            alert(message);
        }

    });

}

function SendRegisterRequest() {
    var username = document.getElementById("txtUsername").value;
    var password = document.getElementById("txtPassword").value;
    var confirmPassword = document.getElementById("txtConfirmPassword").value;

    $.ajax({
        url: "http://localhost:53594/api/Users/",
        method: "POST",
        ContentType: "application/json",
        data: {
            Username: username,
            Password: password,
            ConfirmPassword: confirmPassword
        },
        success: function (result) {
            let message = result.Data.Message;
            $('#txtMsg').html(message);
            //console.log(message);
        },
        error: function (message) {
            alert(message);
        }

    });

}