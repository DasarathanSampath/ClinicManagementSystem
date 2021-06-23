$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Dropdown/GetDoctors",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Please Select a Department</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i] + '">' + data[i] + '</option>';
            }
            $("#doctor").html(s);
        }
    });
});




// ---------------------
$(function () {
    AjaxCall('/Dropdown/GetDoctors', null).done(function (response) {
        if (response.length > 0) {
            $('#doctor').html('');
            var options = '';
            options += '<option value="Select">Select</option>';
            for (var i = 0; i < response.length; i++) {
                options += '<option value="' + response[i] + '">' + response[i] + '</option>';
            }
            $('#doctor').append(options);

        }
    }).fail(function (error) {
        alert(error.StatusText);
    });

    $('#doctor').on("change", function () {
        var doctor = $('#doctor').val();
        var doct1 = $(this).find(':selected')[0].id
        //var date = $('#date').val();
        var obj1 = { doctor: doctor };
        //var obj2 = { date: date };
        AjaxCall('/Dropdown/GetSlots', JSON.stringify(obj1), 'POST').done(function (response) {
            if (response.length > 0) {
                $('#slot').html('');
                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i] + '">' + response[i] + '</option>';
                }
                $('#slot').append(options);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

});

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}