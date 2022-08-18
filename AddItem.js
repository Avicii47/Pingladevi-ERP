$(document).ready(function () {
    getList();
})

var savedata = function () {
    var itemNo = $("#hdnid").val();
    var name = $("#TxtName").val();
    var perdayrate = $("#TxtPerdayRate").val();
    var availablestock = $("#TxtStock").val();
    
    var model = {
        Itemno: itemNo,
        Name: name,
        PerDayRate: perdayrate,
        AvaiableStock: availablestock,
    };

    $.ajax({
        url: "/AddItem/SaveData",
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

var getList = function () {
    $.ajax({
        url: "/AddItem/GetList",
        method: "post",
        //data:JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce) {
            console.log(responce);
            var html = "";
            $("#TblAddItem tbody").empty();
            $.each(responce.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ItemNo + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.PerDayRate + "</td><td>" + elementValue.AvailableStock + "</td><td>" + "</td ><td>  <input type='submit' value='delete' class='btn btn-Danger' onClick='deleteItem (" + elementValue.ItemNo + ")' /> </td ><td>  <input type='submit' value='Edit' class='btn btn-Secondary' onClick='Editdata(" + elementValue.ItemNo + ")' /> </td ></tr>"

            });
            $("#TblAddItem tbody").append(html);
            getList();

        }
    });
};

var deleteItem = function (ItemNo) {
    var model = { Id: ItemNo };
    $.ajax({
        url: "/AddItem/deleteItem",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Item Deleted Successfully ....");
        }
    });
};

var Editdata = function (ItemNo) {
    var model = { ID: ItemNo };
    alert("Record Edit Successfully ....");
    $.ajax({
        url: "/AddItem/GetEditData ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnid").val(response.model.ID);
            $("#TxtName").val(response.model.Name);
            $("#TxtPerdayRate").val(response.model.Perdayrate);
            $("#TxtStock").val(response.model.AvailableStock);
        }
    });
}