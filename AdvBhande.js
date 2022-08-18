$(document).ready(function () {
    detail();
})

var savedata = function () {
    var reciptNo = $("#TxtReciptNo").val();
    var date = $("#TxtDate").val();
    var name = $("#TxtName").val();
    var city = $("#Txtcity").val();
    var eventDate = $("#TxtEventDate").val();
    var mob = $("#Txtmob").val();
    var item = $("#TxtItem").val();
    var rent = $("#TxtRent").val();
    var total = $("#TxtTotal").val();


    var model = {
        ReciptNo: reciptNo,
        Date: date,
        Name: name,
        City: city,
        EventDate: eventDate,
        Mob: mob,
        Items: item,
        Rent: rent,
        Total: total,
    };
    $.ajax({
        url: "/AdvBhande/SaveData",
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
}
var detail = function (Id) {
    var model = { Id: Id};
    $.ajax({
        url: "/AdvBhande/DetailData",
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
            $("#TxtDate1").text(response.model.DateString);
            $("#Txtcity1").text(response.model.City);
            $("#TxtEventDate1").text(response.model.EventDateString);
            $("#Txtmob1").text(response.model.Mob);
            $("#TxtItem1").text(response.model.Items);
            $("#TxtRent1").text(response.model.Rent);
            $("#TxtTotal1").text(response.model.Total);
        }
    });
}