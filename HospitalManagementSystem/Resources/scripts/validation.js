function VisibleTextBox() {
    var type = document.getElementById("lstEmpType");
    var typeSelected = type.options[type.selectedIndex].text;

    if (typeSelected == "Other") {
        $('#txtOther').show();
    }
    else {
        $('#txtOther').css("display", "none");
    }
}

//function myFunction() {
//    $('#txtDOB').datepicker();
//}

//function DatePicker(txt) {
//    alert("alert");
//}

function GetDOBnGender() {
    var nic = $("#txtNIC").text();

    $.ajax({
        type: "POST",
        url: "Employee.aspx/GetDOBbyNIC",
        data: JSON.stringify({ nic: $('#txtNIC').text() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        error: function (xhr, status, error) {
            try {
                var errorMsg = JSON.parse(xhr.responseText).Message;
                alert(errorMsg);
                //document.getElementById("txtUsername").style.borderColor = "#E34234";
                //document.getElementById("txtUsername").value = null;
            }
            catch (ex) {
                //alert("Internal Server error");
            }

            return false;
        }
    });
}

function ValidationThyroidReportForm() {
    var status = true;

    var patientno = document.getElementById("txtPatientId");
    var patientname = document.getElementById("txtPatientName");
    var tsh = document.getElementById("txtTSH");
    var t4total = document.getElementById("txtT4");
    var freet4 = document.getElementById("txtFreeT4");
    var freet3 = document.getElementById("txtFreeT3");

    if (!($.trim(patientno.value).match(/\d/))) {
        patientno.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(patientname.value).match(/\S/))) {
        patientname.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(tsh.value).match(/\d/))) {
        tsh.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(t4total.value).match(/\d/))) {
        t4total.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(freet4.value).match(/\d/))) {
        freet4.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(freet3.value).match(/\d/))) {
        freet3.style.borderColor = "#E34234";
        status = false;
    }

    if (status == false) {
        alert("All fields are required!");
    }

    return status;

}

function ValidationLabReportForm() {
    var status = true;

    var patientno = document.getElementById("txtPNo");
    var patientname = document.getElementById("txtPatientName");
    var email = document.getElementById("txtMail");
    var testno = document.getElementById("txtNumber");
    var testname = document.getElementById("txtTestName");
    var amount = document.getElementById("txtAmount");

    if (!($.trim(patientno.value).match(/\d/))) {
        patientno.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(patientname.value).match(/\S/))) {
        patientname.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(email.value).match(/\S/))) {
        email.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(testno.value).match(/\d/))) {
        testno.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(testname.value).match(/\S/))) {
        testname.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(amount.value).match(/\d/))) {
        amount.style.borderColor = "#E34234";
        status = false;
    }

    if (status == false) {
        alert("Mandatory fields are required!");
    }

    return status;

}

function ValidateLaboratoryForm() {
    var status = true;

    var testname = document.getElementById("txtTestName");
    var testdesc = document.getElementById("txtTestDesc");
    var amount = document.getElementById("txtTestAmount");

    if (!($.trim(testname.value).match(/\S/))) {
        testname.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(testdesc.value).match(/\S/))) {
        testdesc.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(amount.value).match(/\S/))) {
        amount.style.borderColor = "#E34234";
        status = false;
    }

    if (status == false) {
        alert("All fields are required!");
    }

    return status;
}

function ValidateEmployeeForm() {
    var status = true;

    var type = document.getElementById("lstEmpType");
    var typeSelected = type.options[type.selectedIndex].text;

    var type_other = document.getElementById("txtTitle");
    var firstname = document.getElementById("txtFirstName");
    var lastname = document.getElementById("txtLastName");
    var address = document.getElementById("txtAddress");
    var nic = document.getElementById("txtNIC");
    var dob = document.getElementById("txtDOB");
    var genderMale = document.getElementById("radioBtnMale");
    var genderFemale = document.getElementById("radioBtnFemale");
    var mail = document.getElementById("txtMail");
    var contact = document.getElementById("txtContact");
    var salary = document.getElementById("txtSalary");

    if (typeSelected == "") {
        type.style.borderColor = "#E34234";
        status = false;
    }

    if (typeSelected == "Other") {
        if (!($.trim(type_other.value).match(/\S/)))
        {
            typetype_other.style.borderColor = "#E34234";
            status = false;
        }
    }

    if (!($.trim(firstname.value).match(/\S/))) {
        firstname.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(lastname.value).match(/\S/))) {
        lastname.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(address.value).match(/\S/))) {
        address.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(nic.value).match(/\S/))) {
        nic.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(dob.value).match(/\S/))) {
        dob.style.borderColor = "#E34234";
        status = false;
    }

    if (genderMale.checked == false)
    {
        if (genderFemale.checked == false)
        {
            status = false;
        }
    }

    if (!($.trim(mail.value).match(/\S/))) {
        mail.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(contact.value).match(/\S/))) {
        contact.style.borderColor = "#E34234";
        status = false;
    }

    if (!($.trim(salary.value).match(/\S/))) {
        salary.style.borderColor = "#E34234";
        status = false;
    }

    if (status == false) {
        alert("All fields are required!");
    }

    return status;
}