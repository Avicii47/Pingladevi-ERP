$(document).ready(function () {
    getList();
})

var savedata = function () {
   /* var reciptno = $("#TxtReciptNo").val();*/
    var date = $("#Txtdate").val();
    var name = $("#TxtName").val();
    var city = $("#TxtCity").val();
    var address = $("#TxtAddress").val();
    var mobileNo = $("#TxtMobile").val();
    var item = $("#TxtItem").val();
    var quantity = $("#TxtQuantity").val();
    var weight = $("#TxtWeight").val();
    var perGramRate = $("#TxtPerGramRate").val();
    var total = $("#TxtTotal").val();;

    var model = {
        /*ReciptNo: reciptno,*/
        Date: date,
        Name: name,
        City: city,
        Address: address,
        MobileNo: mobileNo,
        Item: item,
        Quantity: quantity,
        Weight: weight,
        PerGramRate: perGramRate,
        Total: total,
    };

    $.ajax({
        url: "/DaginePavatiModel/SaveData",
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
//var getList = function () {
//    $.ajax({
//        url: "/DaginePavatiModel/GetList",
//        method: "post",
//        //data:JSON.stringify(model),
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (responce) {
//            console.log(responce);
//            var html = "";
//            $("#TblDagine tbody").empty();
//            $.each(responce.model, function (index, elementValue) {
//                html += "<tr><td>" + elementValue.ReciptNo + "</td><td>" + elementValue.Item + "</td><td>" + elementValue.Quantity + "</td><td>" + elementValue.Weight + "</td><td>" + elementValue.PerGramRate + "</td><td>" + elementValue.Total + "</td ></tr>"
//            });
//            $("#TblDagine tbody").append(html);
//            getList();

//        }
//    });

//};
