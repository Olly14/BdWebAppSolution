var appUserRegistrationValidation = (function () {

    var FirstNameInputIsValid = true;
    var FirstNameLengthIsValid = true;
    var LastNameInputIsValid = true;
    var LastNameLengthIsValid = true;
    var FirstLineOfAddressInputIsValid = true;
    var FirstLineOfAddressLengthIsValid = true;
    var SecondLineOfAddressInputIsValid = true;
    var SecondLineOfAddressLengthIsValid = true;
    var TownInputIsValid = true;
    var TownLengthIsValid = true;
    var PostcodeInputIsValid = true;
    var PostcodeLengthIsValid = true;
    var DateOfBirthInputIsValid = true;
    var DateOfBirthMatchedIsValid = true;
    var CountryIdInputIsValid = true;
    var GenderIdInputIsValid = true;



    //validations
    var validateFirstNameInput = function () {
        if ($('#FirstNameInputId').val().length <= 0) {

            FirstNameInputIsValid = false;
            $('#FirstNameInputId').addClass("errorBox");
            $('#FirstNameInputErrorId').show();
        } else {
            FirstNameInputIsValid = true;
        }
    }

    var validateFirstNameLength = function () {
        if ($('#FirstNameInputId').val().length < 3 || $('#FirstNameInputId').val().length > 20) {

            FirstNameLengthIsValid = false;
            $('#FirstNameInputId').addClass("errorBox");
            $('#FirstNameInputLengthErrorId').show();
        } else {
            FirstNameLengthIsValid = true;
        }
    }

    var validateLastNameInput = function () {
        if ($('#LastNameInputId').val().length <= 0) {

            LastNameInputIsValid = false;
            $('#LastNameInputId').addClass("errorBox");
            $('#LastNameInputErrorId').show();
        } else {
            LastNameInputIsValid = true;
        }
    }

    var validateLastNameLength = function () {
        if ($('#LastNameInputId').val().length < 3 || $('#LastNameInputId').val().length > 20) {

            FirstNameLengthIsValid = false;
            $('#LastNameInputId').addClass("errorBox");
            $('#LastNameInputLengthErrorId').show();
        } else {
            LastNameLengthIsValid = true;
        }
    }

    var validateFirstLineOfAddressInput = function () {
        if ($('#FirstLineOfAddressInputId').val().length <= 0) {

            FirstLineOfAddressInputIsValid = false;
            $('#FirstLineOfAddressInputId').addClass("errorBox");
            $('#FirstLineOfAddressInputErrorId').show();
        } else {
            FirstLineOfAddressInputIsValid = true;
        }
    }

    var validateFirstLineOfAddressLength = function () {
        if ($('#FirstLineOfAddressInputId').val().length < 3 || $('#FirstLineOfAddressInputId').val().length > 20) {

            FirstLineOfAddressLengthIsValid = false;
            $('#FirstLineOfAddressInputId').addClass("errorBox");
            $('#FirstLineOfAddressInputLengthErrorId').show();
        } else {
            FirstLineOfAddressLengthIsValid = true;
        }
    }

    var validateSecondLineOfAddressInput = function () {
        if ($('#SecondLineOfAddressInputId').val().length <= 0) {

            SecondLineOfAddressInputIsValid = false;
            $('#SecondLineOfAddressInputId').addClass("errorBox");
            $('#SecondLineOfAddressInputErrorId').show();
        } else {
            SecondLineOfAddressInputIsValid = true;
        }
    }

    var validateSecondLineOfAddressLength = function () {
        if ($('#SecondLineOfAddressInputId').val().length < 3 || $('#SecondLineOfAddressInputId').val().length > 20) {

            SecondLineOfAddressLengthIsValid = false;
            $('#SecondLineOfAddressInputId').addClass("errorBox");
            $('#SecondLineOfAddressInputLengthErrorId').show();
        } else {
            SecondLineOfAddressLengthIsValid = true;
        }
    }

    var validateTownInput = function () {
        if ($('#TownInputId').val().length <= 0) {

            TownInputIsValid = false;
            $('#TownInputId').addClass("errorBox");
            $('#TownInputErrorId').show();
        } else {
            TownInputIsValid = true;
        }
    }

    var validateTownLength = function () {
        if ($('#TownInputId').val().length < 3 || $('#TownInputId').val().length > 20) {

            TownLengthIsValid = false;
            $('#TownInputId').addClass("errorBox");
            $('#TownInputLengthErrorId').show();
        } else {
            TownLengthIsValid = true;
        }
    };

    var validatePostcodeInput = function () {
        if ($('#PostcodeInputId').val().length <= 0) {

            TownInputIsValid = false;
            $('#PostcodeInputId').addClass("errorBox");
            $('#PostcodeInputError').show();
        } else {
            PostcodeInputIsValid = true;
        }
    };

    var validatePostcodeMatched = function () {
        if ($('#PostcodeInputId').val().length < 3 || $('#PostcodeInputId').val().length > 20) {

            PostcodeLengthIsValid = false;
            $('#PostcodeInputId').addClass("errorBox");
            $('#PostcodeInputMatchError').show();
        } else {
            PostcodeLengthIsValid = true;
        }
    };

    var validateDateOfBirthInput = function () {
        if ($('#DateOfBirthInputId').val().length <= 0) {

            DateOfBirthInputIsValid = false;
            $('#DateOfBirthInputId').addClass("errorBox");
            $('#DateOfBirthInputError').show();
        } else {
            DateOfBirthInputIsValid = true;
        }
    };

    var validateDateOfBirthMatches = function () {
        var requiredPattern = new RegExp("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");
        var isAMatch = requiredPattern.test($('#DateOfBirthInputId'));
        if (!isAMatch) {

            DateOfBirthMatchedIsValid = false;
            $('#DateOfBirthInputId').addClass("errorBox");
            $('#DateOfBirthInputLengthError').show();
        } else {
            DateOfBirthMatchedIsValid = true;
        }
    };

    var validateCountryIdInput = function () {
        if ($('#CountryIdInputId').val().length <= 0) {

            CountryIdInputIsValid = false;
            $('#CountryIdInputId').addClass("errorBox");
            $('#CountryIdInputErrorId').show();
        } else {
            CountryIdInputIsValid = true;
        }
    };

    var validateGenderIdInput = function () {
        if ($('#GenderIdInputId').val().length <= 0) {

            GenderIdInputIsValid = false;
            $('#GenderIdInputId').addClass("errorBox");
            $('#GenderIdInputErrorId').show();
        } else {
            GenderIdInputIsValid = true;
        }
    };




    //reset
    var resetFirstNameInputRequiredError = function () {
        $('#FirstNameInputId').removeClass("errorBox");
        $('#FirstNameInputErrorId').hide();
        //$('.idHelpBlockErrorMsgInRed').addClass('hidden');
    }

    var resetFirstNameInputLengthRequiredError = function () {
        $('#FirstNameInputId').removeClass("errorBox");
        $('#FirstNameInputLengthErrorId').hide();
    }

    var resetLastNameInputRequiredError = function () {
        $('#LastNameInputId').removeClass("errorBox");
        $('#LastNameInputErrorId').hide();
    }

    var resetLastNameInputLengthRequiredError = function () {
        $('#LastNameInputId').removeClass("errorBox");
        $('#LastNameInputLengthErrorId').hide();
    }

    var resetFirstLineOfAddressInputRequiredError = function () {
        $('#FirstLineOfAddressInputId').removeClass("errorBox");
        $('#FirstLineOfAddressInputError').hide();
    }

    var resetFirstLineOfAddressInputLengthRequiredError = function () {
        $('#FirstLineOfAddressInputId').removeClass("errorBox");
        $('#FirstLineOfAddressInputLengthError').hide();
    }

    var resetSecondLineOfAddressInputRequiredError = function () {
        $('#SecondLineOfAddressInputId').removeClass("errorBox");
        $('#SecondLineOfAddressInputError').hide();
    }

    var resetSecondLineOfAddressInputLengthRequiredError = function () {
        $('#SecondLineOfAddressInputId').removeClass("errorBox");
        $('#SecondLineOfAddressInputLengthError').hide();
    }

    var resetTownInputRequiredError = function () {
        $('#TownInputId').removeClass("errorBox");
        $('#TownInputErrorId').hide();
    }

    var resetTownInputLengthRequiredError = function () {
        $('#TownInputId').removeClass("errorBox");
        $('#TownInputLengthErrorId').hide();
    }

    var resetPostcodeInputRequiredError = function () {
        $('#PostcodeInputId').removeClass("errorBox");
        $('#PostcodeInputErrorId').hide();
    }

    var resetPostcodeInputMatchedRequiredError = function () {
        $('#PostcodeInputId').removeClass("errorBox");
        $('#PostcodeInputMatchErrorId').hide();
    }

    var resetDateOfBirthInputRequiredError = function () {
        $('#DateOfBirthInputId').removeClass("errorBox");
        $('#DateOfBirthInputErrorId').hide();;
    }

    var resetDateOfBirthInputMatchedRequiredError = function () {
        $('#DateOfBirthInputId').removeClass("errorBox");
        $('#DateOfBirthInputMatchErrorId').hide();
    }

    var resetCountryIdInputRequiredError = function () {
        $('#CountryIdInputId').removeClass("errorBox");
        $('#CountryIdInputErrorId').hide();
    }

    var resetGenderIdInputRequiredError = function () {
        $('#GenderIdInputId').removeClass("errorBox");
        $('#GenderIdInputErrorId').hide();
    }




    var onFirstNameInputFocusKeyPressedAndBackspace = function (event) {
        var firstNameInput = $('.FirstNameInput');
        var firstNameInputBackgroundColour = firstNameInput.css('backgroung-color');

        firstNameInput.focus(function () {

            if ((firstNameInputBackgroundColour === 'rgb(238,238,238)') ||
                (firstNameInputBackgroundColour === 'rgb(255,238,238)')) {
                firstNameInput.css("background", '#FFFFFF');
            }
            resetFirstNameInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((firstNameInputBackgroundColour === 'rgb(238,238,238)') ||
                    (firstNameInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstNameInput.css("background", '#FFFFFF');
                }
                resetFirstNameInputRequiredError();
            }

        });;
    }

    var onFirstNameInputLengthFocusKeyPressedAndBackspace = function (event) {
        var firstNameInput = $('.FirstNameInput');
        var firstNameInputBackgroundColour = firstNameInput.css('backgroung-color');

        firstNameInput.focus(function () {

            if ((firstNameInputBackgroundColour === 'rgb(238,238,238)') ||
                (firstNameInputBackgroundColour === 'rgb(255,238,238)')) {
                firstNameInput.css("background", '#FFFFFF');
            }
            resetFirstNameInputLengthRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((firstNameInputBackgroundColour === 'rgb(238,238,238)') ||
                    (firstNameInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstNameInput.css("background", '#FFFFFF');
                }
                resetFirstNameInputLengthRequiredError();
            }

        });;
    }

    var onLastNameInputFocusKeyPressedAndBackspace = function (event) {
        var lastNameInput = $('.LastNameInput');
        var lastNameInputBackgroundColour = lastNameInput.css('backgroung-color');

        lastNameInput.focus(function () {

            if ((lastNameInputBackgroundColour === 'rgb(238,238,238)') ||
                (lastNameInputBackgroundColour === 'rgb(255,238,238)')) {
                lastNameInput.css("background", '#FFFFFF');
            }
            resetLastNameInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((lastNameInputBackgroundColour === 'rgb(238,238,238)') ||
                    (lastNameInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstNameInput.css("background", '#FFFFFF');
                }
                resetLastNameInputRequiredError();
            }

        });;
    }

    var onLastNameInputLengthFocusKeyPressedAndBackspace = function (event) {
        var lastNameInput = $('.LastNameInput');
        var lastNameInputBackgroundColour = lastNameInput.css('backgroung-color');

        lastNameInput.focus(function () {

            if ((lastNameInputBackgroundColour === 'rgb(238,238,238)') ||
                (lastNameInputBackgroundColour === 'rgb(255,238,238)')) {
                lastNameInput.css("background", '#FFFFFF');
            }
            resetLastNameInputLengthRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((lastNameInputBackgroundColour === 'rgb(238,238,238)') ||
                    (lastNameInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstNameInput.css("background", '#FFFFFF');
                }
                resetLastNameInputLengthRequiredError();
            }

        });;
    }

    var onFirstLineOfAddressInputFocusKeyPressedAndBackspace = function (event) {
        var firstLineOfAddressInput = $('.FirstLineOfAddressInput');
        var firstLineOfAddressInputBackgroundColour = firstLineOfAddressInput.css('backgroung-color');

        firstLineOfAddressInput.focus(function () {

            if ((firstLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                (firstLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                lastNameInput.css("background", '#FFFFFF');
            }
            resetFirstLineOfAddressInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((firstLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                    (firstLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstLineOfAddressInput.css("background", '#FFFFFF');
                }
                resetFirstLineOfAddressInputRequiredError();
            }

        });;
    }

    var onFirstLineOfAddressInputLengthFocusKeyPressedAndBackspace = function (event) {
        var firstLineOfAddressInput = $('.FirstLineOfAddressInput');
        var firstLineOfAddressInputBackgroundColour = firstLineOfAddressInput.css('backgroung-color');

        firstLineOfAddressInput.focus(function () {

            if ((firstLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                (firstLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                lastNameInput.css("background", '#FFFFFF');
            }
            resetFirstLineOfAddressInputLengthRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((firstLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                    (firstLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstLineOfAddressInput.css("background", '#FFFFFF');
                }
                resetFirstLineOfAddressInputLengthRequiredError();
            }

        });;
    }

    var onSecondLineOfAddressInputFocusKeyPressedAndBackspace = function (event) {
        var secondLineOfAddressInput = $('.SecondLineOfAddressInput');
        var secondLineOfAddressInputBackgroundColour = secondLineOfAddressInput.css('backgroung-color');

        secondLineOfAddressInput.focus(function () {

            if ((secondLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                (secondLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                secondLineOfAddressInput.css("background", '#FFFFFF');
            }
            resetSecondLineOfAddressInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((secondLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                    (secondLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                    secondLineOfAddressInput.css("background", '#FFFFFF');
                }
                resetSecondLineOfAddressInputRequiredError();
            }

        });;
    }

    var onSecondLineOfAddressInputLengthFocusKeyPressedAndBackspace = function (event) {
        var secondLineOfAddressInput = $('.SecondLineOfAddressInput');
        var secondLineOfAddressInputBackgroundColour = secondLineOfAddressInput.css('backgroung-color');

        secondLineOfAddressInput.focus(function () {

            if ((secondLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                (secondLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                secondLineOfAddressInput.css("background", '#FFFFFF');
            }
            resetSecondLineOfAddressInputLengthRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((secondLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                    (secondLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                    secondLineOfAddressInput.css("background", '#FFFFFF');
                }
                resetSecondLineOfAddressInputLengthRequiredError();
            }

        });;
    }

    var onTownInputFocusKeyPressedAndBackspace = function (event) {
        var townInput = $('.TownInput');
        var townInputBackgroundColour = townInput.css('backgroung-color');

        townInput.focus(function () {

            if ((townInputBackgroundColour === 'rgb(238,238,238)') ||
                (townInputBackgroundColour === 'rgb(255,238,238)')) {
                townInput.css("background", '#FFFFFF');
            }
            resetTownInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((townInputBackgroundColour === 'rgb(238,238,238)') ||
                    (townInputBackgroundColour === 'rgb(255,238,238)')) {
                    townInput.css("background", '#FFFFFF');
                }
                resetTownInputRequiredError();
            }

        });;
    }

    var onTownInputLengthFocusKeyPressedAndBackspace = function (event) {
        var townInput = $('.TownInput');
        var townInputBackgroundColour = townInput.css('backgroung-color');

        townInput.focus(function () {

            if ((townInputBackgroundColour === 'rgb(238,238,238)') ||
                (townInputBackgroundColour === 'rgb(255,238,238)')) {
                townInput.css("background", '#FFFFFF');
            }
            resetTownInputLengthRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((townInputBackgroundColour === 'rgb(238,238,238)') ||
                    (townInputBackgroundColour === 'rgb(255,238,238)')) {
                    townInput.css("background", '#FFFFFF');
                }
                resetTownInputLengthRequiredError();
            }

        });;
    }

    var onPostcodeInputFocusKeyPressedAndBackspace = function (event) {
        var postcodeInput = $('.PostcodeInput');
        var postcodeInputBackgroundColour = postcodeInput.css('backgroung-color');

        postcodeInput.focus(function () {

            if ((postcodeInputBackgroundColour === 'rgb(238,238,238)') ||
                (postcodeInputBackgroundColour === 'rgb(255,238,238)')) {
                postcodeInput.css("background", '#FFFFFF');
            }
            resetPostcodeInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((postcodeInputBackgroundColour === 'rgb(238,238,238)') ||
                    (postcodeInputBackgroundColour === 'rgb(255,238,238)')) {
                    postcodeInput.css("background", '#FFFFFF');
                }
                resetPostcodeInputRequiredError();
            }

        });;
    }

    var onPostcodeInputMatchFocusKeyPressedAndBackspace = function (event) {
        var postcodeInput = $('.PostcodeInput');
        var postcodeInputBackgroundColour = postcodeInput.css('backgroung-color');

        postcodeInput.focus(function () {

            if ((postcodeInputBackgroundColour === 'rgb(238,238,238)') ||
                (postcodeInputBackgroundColour === 'rgb(255,238,238)')) {
                postcodeInput.css("background", '#FFFFFF');
            }
            resetPostcodeInputMatchedRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((postcodeInputBackgroundColour === 'rgb(238,238,238)') ||
                    (postcodeInputBackgroundColour === 'rgb(255,238,238)')) {
                    postcodeInput.css("background", '#FFFFFF');
                }
                resetPostcodeInputMatchedRequiredError();
            }

        });;
    }

    var onDateOfBirthInputFocusKeyPressedAndBackspace = function (event) {
        var DateOfBirthInput = $('.DateOfBirthInput');
        var DateOfBirthInputBackgroundColour = DateOfBirthInput.css('backgroung-color');

        DateOfBirthInput.focus(function () {

            if ((DateOfBirthInputBackgroundColour === 'rgb(238,238,238)') ||
                (DateOfBirthInputBackgroundColour === 'rgb(255,238,238)')) {
                DateOfBirthInput.css("background", '#FFFFFF');
            }
            resetDateOfBirthInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((DateOfBirthInputBackgroundColour === 'rgb(238,238,238)') ||
                    (DateOfBirthInputBackgroundColour === 'rgb(255,238,238)')) {
                    DateOfBirthInput.css("background", '#FFFFFF');
                }
                resetDateOfBirthInputRequiredError();
            }

        });;
    }

    var onDateOfBirthInputMatchFocusKeyPressedAndBackspace = function (event) {
        var DateOfBirthInput = $('.DateOfBirthInput');
        var DateOfBirthInputBackgroundColour = DateOfBirthInput.css('backgroung-color');

        DateOfBirthInput.focus(function () {

            if ((DateOfBirthInputBackgroundColour === 'rgb(238,238,238)') ||
                (DateOfBirthInputBackgroundColour === 'rgb(255,238,238)')) {
                DateOfBirthInput.css("background", '#FFFFFF');
            }
            resetDateOfBirthInputMatchedRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((DateOfBirthInputBackgroundColour === 'rgb(238,238,238)') ||
                    (DateOfBirthInputBackgroundColour === 'rgb(255,238,238)')) {
                    DateOfBirthInput.css("background", '#FFFFFF');
                }
                resetDateOfBirthInputMatchedRequiredError();
            }

        });;
    }

    var onCountryIdInputFocusKeyPressedAndBackspace = function (event) {
        var countryIdInput = $('.CountryIdInput');
        var countryIdInputBackgroundColour = countryIdInput.css('backgroung-color');

        countryIdInput.focus(function () {

            if ((countryIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (countryIdInputBackgroundColour === 'rgb(255,238,238)')) {
                countryIdInput.css("background", '#FFFFFF');
            }
            resetCountryIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((countryIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (countryIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    countryIdInput.css("background", '#FFFFFF');
                }
                resetCountryIdInputRequiredError();
            }

        });;
    }

    var onGenderIdInputFocusKeyPressedAndBackspace = function (event) {
        var genderIdInput = $('.GenderIdInput');
        var genderIdInputBackgroundColour = genderIdInput.css('backgroung-color');

        genderIdInput.focus(function () {

            if ((genderIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (genderIdInputBackgroundColour === 'rgb(255,238,238)')) {
                genderIdInput.css("background", '#FFFFFF');
            }
            resetGenderIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((genderIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (genderIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    genderIdInput.css("background", '#FFFFFF');
                }
                resetGenderIdInputRequiredError();
            }

        });
    }










    var init = function () {

        validateFirstNameInput();
        validateFirstNameLength();
        validateLastNameInput();
        validateLastNameLength();
        validateFirstLineOfAddressInput();
        validateFirstLineOfAddressLength();
        validateSecondLineOfAddressInput();
        validateSecondLineOfAddressLength();
        validateTownInput();
        validateTownLength();
        validatePostcodeInput();
        validatePostcodeMatched();
        validateDateOfBirthInput();
        validateDateOfBirthMatches();
        validateCountryIdInput();
        validateGenderIdInput();
       

        //reset objects init
        resetFirstNameInputRequiredError();
        resetFirstNameInputLengthRequiredError();
        resetLastNameInputRequiredError();
        resetLastNameInputLengthRequiredError();
        resetFirstLineOfAddressInputRequiredError();
        resetFirstLineOfAddressInputLengthRequiredError();
        resetSecondLineOfAddressInputRequiredError();
        resetSecondLineOfAddressInputLengthRequiredError();
        resetTownInputRequiredError();
        resetTownInputLengthRequiredError();
        resetPostcodeInputRequiredError();
        resetPostcodeInputMatchedRequiredError();
        resetDateOfBirthInputRequiredError();
        resetDateOfBirthInputMatchedRequiredError();
        resetCountryIdInputRequiredError();
        resetGenderIdInputRequiredError();



        //keypress event
        onFirstNameInputFocusKeyPressedAndBackspace();
        onFirstNameInputLengthFocusKeyPressedAndBackspace();
        onLastNameInputFocusKeyPressedAndBackspace();
        onLastNameInputLengthFocusKeyPressedAndBackspace();
        onFirstLineOfAddressInputFocusKeyPressedAndBackspace();
        onFirstLineOfAddressInputLengthFocusKeyPressedAndBackspace();
        onSecondLineOfAddressInputFocusKeyPressedAndBackspace();
        onSecondLineOfAddressInputLengthFocusKeyPressedAndBackspace();
        onTownInputFocusKeyPressedAndBackspace();
        onTownInputLengthFocusKeyPressedAndBackspace();
        onPostcodeInputFocusKeyPressedAndBackspace();
        onPostcodeInputMatchFocusKeyPressedAndBackspace();
        onDateOfBirthInputFocusKeyPressedAndBackspace();
        onDateOfBirthInputMatchFocusKeyPressedAndBackspace();
        onCountryIdInputFocusKeyPressedAndBackspace();
        onGenderIdInputFocusKeyPressedAndBackspace();


        $('#registrationBtnId').click(function (e) {

            e.preventDefault();

            validateFirstNameInput();
            validateFirstNameLength();
            validateLastNameInput();
            validateLastNameLength();
            validateFirstLineOfAddressInput();
            validateFirstLineOfAddressLength();
            validateSecondLineOfAddressInput();
            validateSecondLineOfAddressLength();
            validateTownLength();
            validatePostcodeInput();
            validatePostcodeMatched();
            validateDateOfBirthInput();
            validateDateOfBirthMatches();
            validateCountryIdInput();
            validateGenderIdInput();





            var submitControl = FirstNameInputIsValid &&
                FirstNameLengthIsValid &&
                LastNameInputIsValid &&
                LastNameLengthIsValid &&
                FirstLineOfAddressInputIsValid &&
                FirstLineOfAddressLengthIsValid &&
                SecondLineOfAddressInputIsValid &&
                SecondLineOfAddressLengthIsValid &&
                TownInputIsValid &&
                TownLengthIsValid &&
                PostcodeInputIsValid &&
                PostcodeLengthIsValid &&
                GenderIdInputIsValid &&
                DateOfBirthInputIsValid &&
                DateOfBirthMatchedIsValid &&
                GenderIdInputIsValid &&
                CountryIdInputIsValid;


            if (submitControl) {
                $('.registrationForm').submit();
            }
        });
    };

    return {
        init: init,
        validateFirstNameInput: validateFirstNameInput,
        validateFirstNameLength: validateFirstNameLength,
        validateLastNameInput: validateLastNameInput,
        validateLastNameLength: validateLastNameLength,
        validateFirstLineOfAddressInput: validateFirstLineOfAddressInput,
        validateFirstLineOfAddressLength: validateFirstLineOfAddressLength,
        validateSecondLineOfAddressInput: validateSecondLineOfAddressInput,
        validateSecondLineOfAddressLength: validateSecondLineOfAddressLength,
        validateTownLength: validateTownLength,
        validatePostcodeInput: validatePostcodeInput,
        validatePostcodeMatched: validatePostcodeMatched,
        validateDateOfBirthInput: validateDateOfBirthInput,
        validateCountryIdInput: validateCountryIdInput,
        validateGenderIdInput: validateGenderIdInput,


        //reset properties
        resetFirstNameInputRequiredError: resetFirstNameInputRequiredError,
        resetFirstNameInputLengthRequiredError: resetFirstNameInputLengthRequiredError,
        resetLastNameInputRequiredError: resetLastNameInputRequiredError,
        resetLastNameInputLengthRequiredError: resetLastNameInputLengthRequiredError,
        resetFirstLineOfAddressInputRequiredError: resetFirstLineOfAddressInputRequiredError,
        resetFirstLineOfAddressInputLengthRequiredError: resetFirstLineOfAddressInputLengthRequiredError,
        resetSecondLineOfAddressInputRequiredError: resetSecondLineOfAddressInputRequiredError,
        resetSecondLineOfAddressInputLengthRequiredError: resetSecondLineOfAddressInputLengthRequiredError,
        resetTownInputRequiredError: resetTownInputRequiredError,
        resetTownInputLengthRequiredError: resetTownInputLengthRequiredError,
        resetPostcodeInputRequiredError: resetPostcodeInputRequiredError,
        resetPostcodeInputMatchedRequiredError: resetPostcodeInputMatchedRequiredError,
        resetDateOfBirthInputRequiredError: resetDateOfBirthInputRequiredError,
        resetDateOfBirthInputMatchedRequiredError: resetDateOfBirthInputMatchedRequiredError,
        resetCountryIdInputRequiredError: resetCountryIdInputRequiredError,
        resetGenderIdInputRequiredError: resetGenderIdInputRequiredError,

        //keypress event properties
        onFirstNameInputFocusKeyPressedAndBackspace: onFirstNameInputFocusKeyPressedAndBackspace,
        onFirstNameInputLengthFocusKeyPressedAndBackspace: onFirstNameInputLengthFocusKeyPressedAndBackspace,
        onLastNameInputFocusKeyPressedAndBackspace: onLastNameInputFocusKeyPressedAndBackspace,
        onLastNameInputLengthFocusKeyPressedAndBackspace: onLastNameInputLengthFocusKeyPressedAndBackspace,
        onFirstLineOfAddressInputFocusKeyPressedAndBackspace: onFirstLineOfAddressInputFocusKeyPressedAndBackspace,
        onFirstLineOfAddressInputLengthFocusKeyPressedAndBackspace: onFirstLineOfAddressInputLengthFocusKeyPressedAndBackspace,
        onSecondLineOfAddressInputFocusKeyPressedAndBackspace: onSecondLineOfAddressInputFocusKeyPressedAndBackspace,
        onSecondLineOfAddressInputLengthFocusKeyPressedAndBackspace: onSecondLineOfAddressInputLengthFocusKeyPressedAndBackspace,
        onTownInputFocusKeyPressedAndBackspace: onTownInputFocusKeyPressedAndBackspace,
        onTownInputLengthFocusKeyPressedAndBackspace: onTownInputLengthFocusKeyPressedAndBackspace,
        onPostcodeInputFocusKeyPressedAndBackspace: onPostcodeInputFocusKeyPressedAndBackspace,
        onPostcodeInputMatchFocusKeyPressedAndBackspace: onPostcodeInputMatchFocusKeyPressedAndBackspace,
        onDateOfBirthInputFocusKeyPressedAndBackspace: onDateOfBirthInputFocusKeyPressedAndBackspace,
        onDateOfBirthInputMatchFocusKeyPressedAndBackspace: onDateOfBirthInputMatchFocusKeyPressedAndBackspace,
        onCountryIdInputFocusKeyPressedAndBackspace: onCountryIdInputFocusKeyPressedAndBackspace,
        onGenderIdInputFocusKeyPressedAndBackspace: onGenderIdInputFocusKeyPressedAndBackspace,



    }

})();