/* Get from elements values */
function register() {
    var email = $("#email").val();
    var password = $("#psw").val(); 
    var confirmPassword = $("#psw-repeat").val();
    var username = $("#username").val();
    
    var userVM = { Username: username, Password: password, Email: email };
    if (password == confirmPassword) {
        $.ajax({
            url: "/Register/CreateUser",
            type: "POST",
            contentType: 'application/json',
            data: JSON.stringify(userVM),
            success: function (response) {

                console.log(response)
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    } else {
        alert('the passwords didn\'t match!');
    }
    
}