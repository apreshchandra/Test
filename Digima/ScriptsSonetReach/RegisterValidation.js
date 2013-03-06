$(document).ready(function () {

    var pass1 = $("#txtPassword");
    var pass2 = $("#txtRePassword");

    window.onload = function () {
        $("#txtFullName").focus();
        $("#txtFullName").val('');
        $("#txtEmailid").val('');
        $("#txtPassword").val('');
        $("#txtRePassword").val('');
        $("#txtOrganization").val('');
        $("#txtAddress").val('');
        $("#txtCity").val('');
        $("#txtState").val('');
        $("#txtZip").val('');
        $("#txtTelephone").val('');
        $("#txtMobile").val('');
        $("#txtAppname").val('');
        $("#txtAppname").val('');
        $("#ddlGender").val("-1");
        $("#ddlCountry").val("-1");
    };


    $("#txtFullName").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var username_length;
            username_length = $("#txtFullName").val().length;
            $("#username_warning").empty();
            //alert('Vijay');
            if (username_length < 1) {
                $("#username_warning").append("Please provide fullname");
                $("#txtFullName").focus();
                return false;
            }
            else {

                //$("#txtEmailid").focus();
                return true;
            }
        }

    });

    $("#txtEmailid").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var email_length;
            email_length = $("#txtEmailid").val().length;
            $("#email_warning").empty();
            var a1 = $("#txtEmailid").val();
            var filter = /^[a-za-z0-9]+[a-za-z0-9_.-]+[a-za-z0-9_-]+@[a-za-z0-9]+[a-za-z0-9.-]+[a-za-z0-9]+.[a-z]{2,4}$/;

            if (email_length < 1) {
                $("#email_warning").append("please provide email ");
                $("#txtEmailid").focus();
                return false;
            }
            else {
                if (filter.test(a1)) {
                    // $("#txtpassword").focus();
                    return true;
                }
                else {
                    $("#email_warning").append("provide valid email id");
                    $("#txtEmailid").focus();
                    return false;
                }
            }
        }
    });

    $("#txtPassword").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var password_length;

            password_length = $("#txtPassword").val().length;
            $("#password_warning").empty();

            if (password_length < 1) {
                $("#password_warning").append("Provide password");
                $('#txtPassword').focus();
                return false;
            }
            else {
                if (password_length < 6) {
                    $("#password_warning").append("Password must be atleast 6 characters");
                    $('#txtPassword').focus();
                    return false;
                }
            }
        }
    });

    $("#txtRePassword").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {

            repassword_length = $("#txtRePassword").val().length;
            $("#repassword_warning").empty();

            if (repassword_length < 1) {

                $("#repassword_warning").append("Confirm password");
                $('#txtRePassword').focus();
                return false;
            }
            else {

                if (pass1.val() != pass2.val()) {
                    $("#repassword_warning").append("Password does not match");
                    $('#txtRePassword').focus();
                    return false;
                }
            }
        }
    });

    $("#txtOrganization").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var org_length;

            org_length = $("#txtOrganization").val().length;
            $("#org_warning").empty();

            if (org_length < 1) {
                $("#org_warning").append("Provide Organization name");
                $('#txtOrganization').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtAddress").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var address_length;

            address_length = $("#txtAddress").val().length;
            $("#address_warning").empty();

            if (address_length < 1) {
                $("#address_warning").append("Provide address");
                $('#txtAddress').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#ddlGender").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            $("#gender_warning").empty();
            var value = $("#ddlGender").val();
            if (value == '-1') {
                $("#gender_warning").append("Please select gender");
                return false;
                $("#ddlGender").focus();
            }
            else
                return true;
        }
    });


    $("#ddlCountry").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            $("#country_warning").empty();
            var value = $("#ddlCountry").val();
            if (value == '-1') { //($("#ddlCountry").val("Select").attr("selected", "selected")
                $("#country_warning").append("Please select country");
                $("#ddlCountry").focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtCity").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var city_length;

            city_length = $("#txtCity").val().length;
            $("#city_warning").empty();

            if (city_length < 1) {
                $("#city_warning").append("Provide city ");
                $('#txtCity').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtState").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var state_length;

            state_length = $("#txtState").val().length;
            $("#state_warning").empty();

            if (state_length < 1) {
                $("#state_warning").append("Provide state");
                $('#txtState').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtZip").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var zip_length;

            zip_length = $("#txtZip").val().length;
            $("#zip_warning").empty();

            if (zip_length < 1) {
                $("#zip_warning").append("Provide zip code");
                $('#txtZip').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtTelephone").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var tel_length;

            tel_length = $("#txtTelephone").val().length;
            $("#tel_warning").empty();

            if (tel_length < 1) {
                $("#tel_warning").append("Provide telephone number");
                $('#txtTelephone').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtMobile").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var mob_length;

            mob_length = $("#txtMobile").val().length;
            $("#mob_warning").empty();

            if (mob_length < 1) {
                $("#mob_warning").append("Provide mobile number");
                $('#txtMobile').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#txtAppname").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var app_length;

            app_length = $("#txtAppname").val().length;
            $("#app_warning").empty();

            if (app_length < 1) {
                $("#app_warning").append("Provide appname for Facebook");
                $('#txtAppname').focus();
                return false;
            }
            else
                return true;
        }
    });

    $("#BrowserHidden").keydown(function (e) {
        if (e.keyCode == 9 || e.keyCode == 13) {
            var text = $("#BrowserHidden").text();
            if (text == '') {
                $("#img_warning").append("Provide appname for Facebook");
                $('#BrowserHidden').focus();
                return false;
            }
            else
                return true;
        }
    });

});