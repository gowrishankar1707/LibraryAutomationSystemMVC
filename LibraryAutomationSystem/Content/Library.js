
function delete_Function(name) {
    return confirm("Are you shure you want to delete:" + name + "")
}

$(document).ready(function () {
    $(".bookImage img").hover(function () {
        $(".bookaccessories").css("margin-left", "20px");
    });
});
/************************************************************************* 
 * ******************************REGISTER VALIDATION ***********************
 * **************************************************************************/

$(document).ready(function () {
    let IsName = true;
    /****************************** CHECK MEMBER NAME ********************************************* */
    function CheckName() {
        let memberName = $("#MemberName").val();
        if (memberName.length == '') {
            $(".validateMemberName").html("Member name is Null");
            IsName = false;
            return false;
        }
        else if ((memberName.length < 3) || (memberName.length > 35)) {
            $(".validateMemberName").html("Member name is Should be Greater than 3 and Lesser than 35");
            IsName = false;
            return false;
        }
        else {
            IsName = true
            return true;

        }
    }
    $("#MemberName").blur(function () { CheckName(); }); // Detect while change from Text box
    /******************************    CHECK USER NAME***************************/
//    @* $("#MemberUserName").blur(function () {
//        $.ajax(
//            {

//                type: "POST",
//                async: true,
//                url:@Url.Action("CheckUserName", "Account"),
//        data: { userName: this.val() },
//        contentType: "application/json; charset=utf-8",
//            dataType: 'json',
//                success: function (data) {
//                    if (data == true) {
//                        $(".validateMemberUserName").html("Username already exist");
//                    }
//                    else {
//                        $(".validateMemberUserName").html("Username Available");
//                    }

//                }


//    });
    //});*@
    function CheckUserName() {
        let userName = $("#MemberUserName").val();
        if (userName.length == "") {
            $(".validateMemberUserName").html("Username should not be null");
            return false;
        }
        else {
            $(".validateMemberUserName").html("");
            return true;
        }
       
    }

    $("#MemberUserName").blur(function () { CheckUserName(); });
/********************************** CHECK PASSWORD  ***********************************/
function CheckPassword() {
    let password = $("#password").val();
    if (password.length == '') {
        $(".validatePassword").html("Password Missing");
        return false;
    }
    else {
        $(".validatePassword").html("");
        return true;
    }
}

$("#password").blur(function () {
    CheckPassword();
})


/********************************   CHECK CONFIRM PASSWORD ************************** */


function ConfirmPassword() {
    let password = $("#password").val();
    let confirmPassword = $("#confirmPassword").val();
    if (password != confirmPassword) {
        $(".validateConformPassword").html("Password Mismatch").css("color", "red");
        return false;
    }
    else {
        $(".validateConformPassword").html("Password match").css("color", "green");
        return true;
    }
}

$("#confirmPassword").keyup(function () {
    ConfirmPassword();
});
    /*********************************CHECK GENDER******************************************* */
    function checkGender() {
       
        if ($('input[name="gender"]:checked').length == '') {
            $(".validateGender").html("Please select the gender");
            return false;
        }
        else {
            $(".validateGender").html("");
            return true;
        }
    }
/****************************** CHECK DATE OF BIRTH ***************************************************/
function CheckDataofBirth() {
    let DOB = $("#DOB").val();
    if (DOB.length=="") {
        $(".validateDOB").html("Date of Birth Missing");
        return false;
    }
    else {
        $(".validateDOB").html("");
        return true;
    }
}
/********************************************* CHECK DATE OF JOINING *************************** */
function CheckDataOfJoining() {
    let DOJ = $("#DOJ").val();
    if (DOJ.length == "") {
        $(".validateDOJ").html("Date of Joining Missing");
        return false;
    }
    else {
        $(".validateDOJ").html("");
        return true;
    }
}
/*************************************** CHECK PHONE NUMBER************************* */
function CheckPhoneNumber() {
    let phoneNumber = $("#phoneNumber").val();
    if (phoneNumber.length == "") {
        $(".validatePhoneNumber").html("Phone number is null...its mandatory ex:94875 00123")
        return false;
    }
    else {
        $(".validatePhoneNumber").html("");
        return true;
    }
}
$("#phoneNumber").blur(function () {
    CheckPhoneNumber();
});
/***************************** CHECK EMAIL ***************************/
function checkMail() {
    let mail = $("#mail").val();
    if (mail.length == "") {
        $(".validateMail").html("Email is mandatory");
        return false;
    }
    else {
        $(".validateMail").html("");
        return true;
    }

}
    $("#mail").blur(function () { checkMail(); });
 /****************    REGISTER CLICK OPERATION   *********************************/

    $("#submitRegister").click(function () {
        
      
        CheckName();
        CheckUserName();
        CheckPassword();
        CheckDataofBirth();
        CheckDataOfJoining();
        checkMail();
        CheckPhoneNumber();
        checkGender();
        let name = CheckName();
        let userName = CheckUserName();
        let password = CheckPassword();
        let DOB = CheckDataofBirth();
        let DOJ = CheckDataOfJoining();
        let email = checkMail();
        let phoneNumber = CheckPhoneNumber();
        let Gender = checkGender();
   

        if ((name == true) && (password == true) && (userName == true) && (DOB == true) &&
            (DOJ == true) && (email == true) && (phoneNumber == true) && (Gender == true))
        {
            return true;
        }
        else {
            return false;
        }
      
    });


  });