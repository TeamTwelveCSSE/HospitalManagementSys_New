
    $(document).ready(function () {
        $("#txtOrDate").datepicker({ minDate: 0, numberOfMonths: 1, onSelect: function (selected) { $("#txtReDate").datepicker("option", "minDate", selected) } });
        $("#txtReDate").datepicker({ minDate: 0, numberOfMonths: 1, onSelect: function (selected) { $("#txtOrDate").datepicker("option", "maxDate", selected) } });
        $("#txtOrDate").prop("readonly", true);
        $("#txtReDate").prop("readonly", true);

        $("#submit").click(function () {

        });
    });