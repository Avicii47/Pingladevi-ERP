////$(document).ready(function () {
////    detail();
////})
var savedata = function () {
    var date = $("#TxtDate").val();
    var name = $("#TxtName").val();
    var city = $("#TxtCity").val();
    var address = $("#TxtAddress").val();
    var mobile = $("#TxtMobile").val();
    var item = $("#TxtItem").val();
    var quantity = $("#TxtQuantity").val();
    var weight = $("#TxtWeight").val();
    var pergramrate = $("#TxtPerGramRate").val();
    var total = $("#TxtTotal").val();;


    var model = {
        Date: date,
        Name: name,
        City: city,
        Address: address,
        Mobile: mobile,
        Item: item,
        Quantity: quantity,
        Weight: weight,
        PerGramRate: pergramrate,
        Total: total,
    };

    $.ajax({
        url: "/Dagine/SaveData",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            /*console.log(response);*/
            alert("Successfull");
            /*detail(response.model);*/
        }
    })
};
//var detail = function (Id) {
//    var model = { Id: Id };

//    $.ajax({
//        url: "/Dagine/DetailData",
//        method: "Post",
//        data: JSON.stringify(model),
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            console.log(response);
//            alert(response.model.Name);
//            $("#TxtReciptNo").text(response.model.ReciptNo);
//            $("#TxtName1").text(response.model.Name);
//            $("#Date1").text(response.model.DateString);
//            $("#TxtMob1").text(response.model.Mobile);
//            $("#TxtAddress1").text(response.model.Address);
//            $("#TxtItem1").text(response.model.Item);
//            $("#TxtQuantity1").text(response.model.Quantity);
//            $("#TxtWeight1").text(response.model.Weight);
//            $("#TxtPerGramRate1").text(response.model.PerGramRate);
//            $("#TxtTotal1").text(response.model.Total);
//        }
//    });
//}