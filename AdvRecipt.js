$(document).ready(function () {
    detail();
})

var savedata = function () {
    var reciptno = $("#TxtReciptNo").val();
    var name = $("#TxtName").val();
    var date = $("#TxtDate").val();
    var mobileNo = $("#TxtMob").val();
    var startDate = $("#TxtStart").val();
    var endDate = $("#TxtEnd").val();
    var total = $("#TxtTotal").val();
    var advance = $("#TxtAdvance").val();
    var remaining = $("#TxtRemaining").val();;


    var model = {
        ReciptNo: reciptno,
        Name: name,
        Date: date,
        MobileNo: mobileNo,
        StartDate: startDate,
        EndDate: endDate,
        Total: total,
        Advance: advance,
        Remaining: remaining,
    };

    $.ajax({
        url: "/AdvRecipt/SaveData",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            alert("Successfull");
            detail(response.model);
        }
    })
};

var detail = function (Id) {
    var model = { Id: Id };

    $.ajax({
        url: "/AdvRecipt/DetailData",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response);
            alert(response.model.Name);
            $("#TxtReciptNo").text(response.model.ReciptNo);
            $("#TxtName1").text(response.model.Name);
            $("#Date1").text(response.model.DateString);
            $("#TxtMob1").text(response.model.MobileNo);
            $("#TxtStart1").text(response.model.StartDateString);
            $("#TxtEnd1").text(response.model.EndDateString);
            $("#TxtTotal1").text(response.model.Total);
            $("#TxtAdvance1").text(response.model.Advance);
            $("#TxtRemaining1").text(response.model.Remaining);
        }
    });
}