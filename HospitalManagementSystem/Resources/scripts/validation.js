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

function myFunction() {
    $('#txtDOB').datepicker();
}

//$(function () {
//    $('#txtDOB').datepicker({
//        dateFormat: "dd/MM/yy",
//        changeMonth: true,
//        changeYear: true
//    });
//});

function DatePicker(txt) {
    alert("alert");
}

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