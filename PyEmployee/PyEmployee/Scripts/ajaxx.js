
    //Dropdownlist Selectedchange event
    $("#EmployeeId").selected(function () {
        $("#empname").empty();
        $.get('PyInOut/GetNameById', { id: $('#EmployeeId').val() }, function (data) {
            $.each(data, function (index, row) {
                $('#empname').append("<option value='" + row.EmployeeId + "'>" + row.Employee_Name + "</option>");
            });
        });
    });

   
    $("#EmployeeId").selected(function () {
        $("#empname").empty();
        $.ajax({
            type: 'POST',
            url: '@Url.Action("GetNameById","PyInOut")', // we are calling json method
            dataType: 'json',

            data: { id: $("#EmployeeId").val() },
            // here we are get value of selected country and passing same value as inputto json method GetStates.


            success: function (Pyinout) {
                // states contains the JSON formatted list
                // of states passed from the controller

                $.each(Pyinout, function (i, Row) {
                    $("#empname").append('<option value="' + Row.Value + '">' +
                         Row.Text + '</option>');
                    // here we are adding option for States

                });
            },
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;
    });