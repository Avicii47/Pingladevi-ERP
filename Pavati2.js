$(document).ready(function () {
    detail();
    getPavati2List(); 
})

var savePavati = function () {
    var id = $("#txtId").val();
    var date = $("#txtDate").val();
    var name = $("#txtName").val();
    var mobileno = $("#txtMobileno").val();
    var category = $("#txtcategory").val();
    var subcategory = $("#txtsubcategory").val();
    var unit = $("#txtunit").val();

    var model = {
        Id: id,
        Date: date,
        Name: name,
        Mobileno: mobileno,
        Category: category,
        SubCategory: subcategory,
        Unit: unit,
    };
    if (date == "") {
        alert("Please enter Date");
    }
    else if (name == "") {
        alert("Please enter  Name ");
    }
    else if (mobileno == "") {
        alert("Please enter  Mobile_No ");
    } if (mobileno == "/[0-9]{10}") {
        alert("Please enter  Mobile_No ");
    }
    else if (category == "") {
        alert("Please enter Category");
    }
    else if (subcategory == "") {
        alert("Please enter Subcategory ");
    }
    else if (unit == "") {
        alert("Please enter unit ");
    }
    $.ajax({
        url: "/Pavati2/SavePavati",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",

        success: function (response) {
            console.log(response.message);
            alert("Successfull");

            detail(response.message);
        }
    })
};
var detail = function (id) {
    var model = { Id: id };

    $.ajax({
        url: "/Pavati2/DetailData",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            console.log(response);
            $("#txtId").text(response.model.Id);
            $("#lblDate").text(response.model.DateString);
            $("#lblName").text(response.model.Name);
            $("#lblMobileno").text(response.model.Mobileno);
            $("#lblcategory").text(response.model.Category);
            $("#lblsubcategory").text(response.model.SubCategory);
            $("#lblunit").text(response.model.Unit);
        }
    });
}
var getPavati2List = function () {
    var FromDate = $("#txtfromdate").val();
    var ToDate = $("#txttodate").val();
    var model = { FromDate: FromDate, ToDate: ToDate }
    $.ajax({
        url: "/Pavati2/GetPavati2List",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Tbl_Pavati2 tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.DateString + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.Mobileno + "</td><td>" + elementValue.Category + "</td><td>" + elementValue.SubCategory + "</td><td>" + elementValue.Unit + "</td></tr>";
            });
            $("#Tbl_Pavati2 tbody").append(html);
        }
    });
}
