$(document).ready(function () {
    detail();
    getPavatiList();


})
var savePavati = function () {
    var id = $("#txtId").val();
    var date = $("#txtDate").val();
    var name = $("#txtName").val();
    var mobileno = $("#txtMobileno").val();
    var paymentinword = $("#txtPaymentInWord").val();
    var paymentinno = $("#txtPaymentInNo").val();

    var model = {
        Id: id,
        Date: date,
        Name: name,
        Mobileno: mobileno,
        PaymentInWord: paymentinword,
        PaymentInNo: paymentinno,
    };
    if (date == "") {
        alert("Please select Date");
    }
    else if (name == "") {

        alert("Please enter Name ");
    }
    else if (mobileno == "") {
        alert("Please enter  Mobile_No ");
    } if (mobileno == "/[0-9]{10}") {
        alert("Please enter  Mobile_No ");
    }
    else if (paymentinword == "") {
        alert("Please enter PaymentInWord");
    }
    else if (paymentinno == "") {
        alert("Please enter PaymentInNumber");
    }
    $.ajax({
        url: "/Pavati/SavePavati",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",

        success: function (response) {
            console.log(response.message);
            alert("Data Submit Successfully");

            detail(response.message);
        }
    })
};

var detail = function (id) {
    var model = { Id: id };

    $.ajax({
        url: "/Pavati/DetailData ",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response);
            $("#txtId").text(response.model.Id);
            $("#txtDate").text(response.model.DateString);
            $("#txtnamesame").text(response.model.Name);
            $("#txtmobilenosame").text(response.model.Mobileno);
            $("#txtpaymentinwordsame").text(response.model.PaymentInWord);
            $("#txtpaymentinnosame").text(response.model.PaymentInNo);
        }
    });
}

var getPavatiList = function () {
    var FromDate = $("#txtfromdate").val();
    var ToDate = $("#txttodate").val();
    var model = { FromDate: FromDate, ToDate: ToDate }
    $.ajax({
        url: "/Pavati/GetPavatiList",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Tbl_Pavati tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.DateString + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.Mobileno + "</td><td>" + elementValue.PaymentInWord + "</td><td>" + elementValue.PaymentInNo + "</td></tr>";
            });
            $("#Tbl_Pavati tbody").append(html);
        }
    });
}
