// This is called with the results from from FB.getLoginStatus().
function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        testAPI();
    } else if (response.status === 'not_authorized') {
        // The person is logged into Facebook, but not your app.
        document.getElementById('status').innerHTML = 'Please log ' +
          'into this app.';
    } else {
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        document.getElementById('status').innerHTML = 'Please log ' +
          'into Facebook.';
    }
}

// This function is called when someone finishes with the Login
// Button.  See the onlogin handler attached to it in the sample
// code below.
function checkLoginState() {
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            document.getElementById('Msgsuccess').innerText = "Authinticated successfully";
            eissa();
        }

        //statusChangeCallback(response);
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '{your-app-id}',
        cookie: true,  // enable cookies to allow the server to access
        // the session
        xfbml: true,  // parse social plugins on this page
        version: 'v2.2' // use version 2.2
    });

    // Now that we've initialized the JavaScript SDK, we call
    // FB.getLoginStatus().  This function gets the state of the
    // person visiting this page and can return one of three states to
    // the callback you provide.  They can be:
    //
    // 1. Logged into your app ('connected')
    // 2. Logged into Facebook, but not your app ('not_authorized')
    // 3. Not logged into Facebook and can't tell if they are logged into
    //    your app or not.
    //
    // These three cases are handled in the callback function.

    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });

};


// Load the SDK asynchronously
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.4&appId=1146274332055853";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

// Here we run a very simple test of the Graph API after login is
// successful.  See statusChangeCallback() for when this call is made.

function eissa() {
    FB.api('/me?fields=id,name,birthday,email,location,picture,hometown', function (response) {
        if (response.email != null) {
            document.getElementById('UserName').value =
                response.name;
        }
        else {
            document.getElementById('UserEmail').value =
                response.email;
        }
        if (response.location.name != null) {
            document.getElementById('Location').value =
            response.location.name;
        }
        else {
            document.getElementById('location').value =
            response.hometown.name;
        }
        document.getElementById('profile_pic').src = response.picture.data.url;

    });



}


//custom login button

(function ($) {
    $(function () {
        $("#f1 #f2 ").on("click", function () {
            FB.login(function (response) {
                if (response.authResponse) {
                    eissa();
                    _wdfb_notifyAndRedirect();
                }
            }, { scope: 'public_profile,email,publish_actions,user_friends,user_about_me,user_birthday,user_location' });
        });
        $("#f3 ").on("click", function () {
            FB.login(function (response) {
                if (response.authResponse) {
                    eissa();
                    _wdfb_notifyAndRedirect();
                }
            }, { scope: 'public_profile,email,publish_actions,user_friends,user_about_me,user_birthday,user_location' });
        });
    });
})(jQuery);




function eissa2() {
    //window.location = "http://localhost:56733/home";

}
function testAPI() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function (response) {
        console.log('Wlcome to Engezny : ' + response.name);
        document.getElementById('status').innerHTML =
          'Hi.., ' + response.name + '!';
        //document.getElementById('UserEmail').value =
        //    response.name;
    });
}

