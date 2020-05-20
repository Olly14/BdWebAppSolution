var registrationValidation = (function () {

    var emailInputIsValid = true;
    var emailInputMatchIsValid = true;
    var passwordInputIsValid = true;
    var passwordInputMatchIsValid = true;
    var confirmedPasswordInputIsValid = true;
    var cPasswordInputMatchedIsValid = true;
    var passwordAndConfirmedPasswordEquals = true;


    var validateEmailInput = function () {

        if ($('#EmailInputId').val().length <= 0) {
            $('#EmailInputId').addClass("errorBox")
            $('#EmailInputErrorId').show();
            emailInputIsValid = false;
        } else {
            emailInputIsValid = true;
        }
    };
    var validateEmailInputMatch = function () {

        if ($('#EmailInputId').val().length > 0) {
            //var requiredPattern = new RegExp('^([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$');
            //var requiredPattern = new RegExp('^([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$', 'gi');
            var requiredPattern = new RegExp("([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})");
            var isAMatch = requiredPattern.test($('#EmailInputId'));
            if (!isAMatch) {

                emailInputMatchIsValid = false;
                $('#EmailInputId').addClass("errorBox");
                $('#EmailInputMatchErrorId').show();
            } else {
                emailInputMatchIsValid = true;
            }
        }
    };

    var validatePasswordInput = function () {

        if ($('#PasswordInputId').val().length <= 0) {
            $('#PasswordInputId').addClass("errorBox")
            $('#PasswordInputErrorId').show();
            passwordInputIsValid = false;
        } else {
            passwordInputIsValid = true
        }
    };

    var validatePasswordMatches = function () {

        if ($('#PasswordInputId').val().length > 0) {

            var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,20})$","i");
            var isAMatch = requiredPattern.test($('#PasswordInputId'));
            if (!isAMatch) {

                passwordInputMatchIsValid = false;
                $('#PasswordInputId').addClass("errorBox");
                $('#PasswordInputMatchErrorId').show();
            } else {
                passwordInputMatchIsValid = true;
            }
        }
    };

    var validateConfirmedPasswordInput = function () {

        if ($('#ConfirmedPasswordInputId').val().length <= 0) {

            $('#ConfirmedPasswordInputId').addClass("errorBox")
            $('#ConfirmedPasswordInputErrorId').show();
            confirmedPasswordInputIsValid = false;
        } else {
            confirmedPasswordInputIsValid = true;
        }
    };

    var validateConfirmedPasswordMatches = function () {

        if ($('#PasswordInputId').val().length > 0  && $('#ConfirmedPasswordInputId').val().length > 0) {

            var passwordVal = $('#PasswordInputId').val();
            var cPasswordVal = $('#ConfirmedPasswordInputId').val();
            var sameTrue = passwordVal == cPasswordVal;
            var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,15})$");
            var isAMatchPassword = requiredPattern.test($('#PasswordInputId'));
            var isAMatchConfirmedPassword = requiredPattern.test($('#ConfirmedPasswordInputId'));
            if (!((isAMatchPassword && isAMatchConfirmedPassword) && sameTrue)) {

                cPasswordInputMatchedIsValid = false;
                $('#ConfirmedPasswordInputId').addClass("errorBox");
                $('#ConfirmedPasswordMatchErrorId').show();
            } else {
                cPasswordInputMatchedIsValid = true;
            }
        }
    };

    var validatePasswordAndConfirmedPasswordMatches = function () {

        if ($('#PasswordInputId').val().length > 0 && $('#ConfirmedPasswordInputId').val().length > 0) {

            var passwordVal = $('#PasswordInputId').val();
            var cPasswordVal = $('#ConfirmedPasswordInputId').val();
            var sameTrue = passwordVal.localeCompare( cPasswordVal);
            var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,15})$");
            var isAMatchPassword = requiredPattern.test($('#PasswordInputId'));
            var isAMatchConfirmedPassword = requiredPattern.test($('#ConfirmedPasswordInputId'));
            if (((isAMatchPassword && isAMatchConfirmedPassword) && !sameTrue)) {

                cPasswordInputMatchedIsValid = false;

                //$('#PasswordInputId').addClass("errorBox")
                //$('#PasswordInputErrorId').show();

                $('#ConfirmedPasswordInputId').addClass("errorBox");
                $('#ConfirmedPasswordMatchErrorId').show();
            } else {
                cPasswordInputMatchedIsValid = true;
            }
        }
    };



    var resetEmailInput = function () {

        $('#EmailInputId').removeClass("errorBox")
        $('.EmailInputError').hide();
    };

    var resetEmailInputMatch = function () {

        $('#EmailInputId').removeClass("errorBox")
        $('.EmailInputMatchError').hide();
    };

    var resetPasswordInput = function () {

        $('#PasswordInputId').removeClass("errorBox")
        $('.PasswordInputError').hide();
    };

    var resetPasswordInputMatch = function () {

        $('#PasswordInputId').removeClass("errorBox")
        $('.PasswordInputMatchError').hide();
    };

    var resetConfirmedPasswordInput = function () {

        $('#ConfirmedPasswordInputId').removeClass("errorBox")
        $('.ConfirmedPasswordInputError').hide();
    };

    var resetConfirmedPasswordInputMatch = function () {

        $('#ConfirmedPasswordInputId').removeClass("errorBox")
        $('.ConfirmedPasswordMatchError').hide();
    };




    var onEmailInputFocusKeyPressedAndBackspace = function (event) {
        var emailInput = $('.EmailInput');
        var emailInputBackgroundColour = emailInput.css('backgroung-color');

        emailInput.focus(function () {

            if ((emailInputBackgroundColour === 'rgb(238,238,238)') ||
                (emailInputBackgroundColour === 'rgb(255,192,203)')) {
                emailInput.css("background", '#FFFFFF');
            }
            resetEmailInput();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((emailInputBackgroundColour === 'rgb(238,238,238)') ||
                    (emailInputBackgroundColour === 'rgb(255,192,203)')) {
                    emailInput.css("background", '#FFFFFF');
                }
                resetEmailInput();
            }

        });
    };

    var onEmailInputMatchFocusKeyPressedAndBackspace = function (event) {
        var emailInput = $('.EmailInput');
        var emailInputBackgroundColour = emailInput.css('backgroung-color');

        emailInput.focus(function () {

            if ((emailInputBackgroundColour === 'rgb(238,238,238)') ||
                (emailInputBackgroundColour === 'rgb(255,192,203)')) {
                emailInput.css("background", '#FFFFFF');
            }
            resetEmailInputMatch();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((emailInputBackgroundColour === 'rgb(238,238,238)') ||
                    (emailInputBackgroundColour === 'rgb(255,192,203)')) {
                    emailInput.css("background", '#FFFFFF');
                }
                resetEmailInputMatch();
            }

        });
    };

    var onPasswordInputFocusKeyPressedAndBackspace = function (event) {
        var passwordInput = $('.PasswordInput');
        var passwordInputBackgroundColour = passwordInput.css('backgroung-color');

        passwordInput.focus(function () {

            if ((passwordInputBackgroundColour === 'rgb(238,238,238)') ||
                (passwordInputBackgroundColour === 'rgb(255,192,203)')) {
                passwordInput.css("background", '#FFFFFF');
            }
            resetPasswordInput();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((passwordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (passwordInputBackgroundColour === 'rgb(255,192,203)')) {
                    passwordInput.css("background", '#FFFFFF');
                }
                resetPasswordInput();
            }

        });
    };


    var onConfirmedPasswordInputFocusKeyPressedAndBackspace = function (event) {
        var confirmedPasswordInput = $('.ConfirmedPasswordInput');
        var confirmedPasswordInputBackgroundColour = confirmedPasswordInput.css('backgroung-color');

        confirmedPasswordInput.focus(function () {

            if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                confirmedPasswordInput.css("background", '#FFFFFF');
            }
            resetConfirmedPasswordInput();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                    confirmedPasswordInput.css("background", '#FFFFFF');
                }
                resetConfirmedPasswordInput();
            }

        });
    };


    var onPasswordInputMatchFocusKeyPressedAndBackspace = function (event) {
        var confirmedPasswordInput = $('.PasswordInput');
        var confirmedPasswordInputBackgroundColour = confirmedPasswordInput.css('backgroung-color');

        confirmedPasswordInput.focus(function () {

            if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                confirmedPasswordInput.css("background", '#FFFFFF');
            }
            resetPasswordInputMatch();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                    confirmedPasswordInput.css("background", '#FFFFFF');
                }
                resetPasswordInputMatch();
            }

        });
    };

    var onConfirmedPasswordInputMatchFocusKeyPressedAndBackspace = function (event) {
        var confirmedPasswordInput = $('.ConfirmedPasswordInput');
        var confirmedPasswordInputBackgroundColour = confirmedPasswordInput.css('backgroung-color');

        confirmedPasswordInput.focus(function () {

            if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                confirmedPasswordInput.css("background", '#FFFFFF');
            }
            resetConfirmedPasswordInputMatch();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                    confirmedPasswordInput.css("background", '#FFFFFF');
                }
                resetConfirmedPasswordInputMatch();
            }

        });
    };



    var init = function () {

        $('#registrationBtnId').click(function (e) {

            e.preventDefault();

            validateEmailInput();
            validateEmailInputMatch();
            validatePasswordInput();
            validatePasswordMatches();
            validateConfirmedPasswordInput();
            validateConfirmedPasswordMatches();


            var submitControl = emailInputIsValid &&
                                emailInputMatchIsValid &&
                                passwordInputIsValid &&
                                passwordInputMatchIsValid &&
                                confirmedPasswordInputIsValid &&
                                cPasswordInputMatchedIsValid;



            if (submitControl) {
                $('.registrationForm').submit();
            }
        });



        validateEmailInput();
        validateEmailInputMatch();
        validatePasswordInput();
        validatePasswordMatches();
        validateConfirmedPasswordInput();
        validateConfirmedPasswordMatches();

        resetEmailInput();
        resetEmailInputMatch();
        resetPasswordInput();
        resetPasswordInputMatch();
        resetConfirmedPasswordInput();
        resetConfirmedPasswordInputMatch();

        onEmailInputFocusKeyPressedAndBackspace();
        onEmailInputMatchFocusKeyPressedAndBackspace();
        onPasswordInputFocusKeyPressedAndBackspace();
        onConfirmedPasswordInputFocusKeyPressedAndBackspace();
        onPasswordInputMatchFocusKeyPressedAndBackspace();
        onConfirmedPasswordInputMatchFocusKeyPressedAndBackspace();
    };

    return {
        init: init,
        validateEmailInput: validateEmailInput,
        validateEmailInputMatch: validateEmailInputMatch,
        resetEmailInputMatch: resetEmailInputMatch,
        validatePasswordInput: validatePasswordInput,
        validatePasswordMatches: validatePasswordMatches,
        validateConfirmedPasswordInput: validateConfirmedPasswordInput,
        validateConfirmedPasswordMatches: validateConfirmedPasswordMatches,


        resetEmailInput: resetEmailInput,
        resetPasswordInput: resetPasswordInput,
        resetPasswordInputMatch: resetPasswordInputMatch,
        resetConfirmedPasswordInput: resetConfirmedPasswordInput,
        resetConfirmedPasswordInputMatch: resetConfirmedPasswordInputMatch,

        onEmailInputFocusKeyPressedAndBackspace: onEmailInputFocusKeyPressedAndBackspace,
        onEmailInputMatchFocusKeyPressedAndBackspace: onEmailInputMatchFocusKeyPressedAndBackspace,
        onPasswordInputFocusKeyPressedAndBackspace: onPasswordInputFocusKeyPressedAndBackspace,
        onPasswordInputMatchFocusKeyPressedAndBackspace: onPasswordInputMatchFocusKeyPressedAndBackspace,
        onConfirmedPasswordInputFocusKeyPressedAndBackspace: onConfirmedPasswordInputFocusKeyPressedAndBackspace,
        onConfirmedPasswordInputMatchFocusKeyPressedAndBackspace: onConfirmedPasswordInputMatchFocusKeyPressedAndBackspace
        
    };

})();