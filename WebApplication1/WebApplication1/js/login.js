/* Get from elements values */
function Login() {
    var password = $("#psw").val(); 
    var username = $("#uname").val();
    
    var userVM = { Username: username, Password: password };

    $.ajax({
        url: "/Login/LoginUser",
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(userVM),
        success: function (response) {
            if (response == true) {
                alert("loged successfully!!!");
            } else {
                alert("didnt loged!!!");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
            
        }
    });
        
}
    
    
