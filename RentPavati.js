$(document).ready(function () {  
    listget();
})

var savedata = function () {
    var reciptno = $("#TxtReciptNo").val();
    var name = $("#TxtName").val();
    var date = $("#TxtDate").val();
    var city = $("#TxtCity").val();
    var startTime = $("#TxtStart").val();
    var endTime = $("#TxtEnd").val();
    


    var model = {
        Reciptno: reciptno,
        Name: name,
        Date: date,
        City: city,
        StartTime: startTime,
        EndTime: endTime,
        
    };
   
    
    $.ajax({
        url: "/RentPavti/SaveData",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            $.alert({
                title: 'Alert!',
                content: "Data Added Successfully..!",
                type: "red"
            }); 
            detail(response.model);

        }
    })
};

var detail = function (Id) {
    var model = { Id: Id };
    $.ajax({
        url: "/RentPavti/DetailData",
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
            $("#TxtCity1").text(response.model.City);
            $("#TxtStartTime").text(response.model.StartTime);
            $("#TxtEndTime").text(response.model.EndTime);
            getList(Id);
        }
    });
}

var getItemData = function (ItemNo) {
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
            console.log(response)

            $("#txtprice").val(response.model.PerDayRate);

        }
    });
}

var saveinvoice = function () {
    var id = $("#hdnId").val();
    var reciptno = $("#TxtReciptNo").text();
    var ddlvalue = $("#ItemNo").val();
    var perdayrate = $("#txtprice").val();
    var totalitem = $("#txtqty").val();
    var totalprice = $("#total").val();
    


    var model = {
        Id:id,
        Reciptno: reciptno,
        Item: ddlvalue,
        PerDayRate: perdayrate,
        TotalItem: totalitem,
        TotalPrice: totalprice,
        
    };

    $.ajax({
        url: "/RentPavti/SaveInvoice",
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

var getList = function (reciptNo) {
    var model = { ReciptNo: reciptNo };
    $.ajax({
        url: "/RentPavti/GetList",
        method: "post",
        data:JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce) {
            console.log(responce);
            var html = "";
            var sum = 0;
            $("#tblInvoices tbody").empty();
            $.each(responce.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Item + "</td><td>" + elementValue.PerDayRate + "</td><td>" + elementValue.TotalItem + "</td><td>" + elementValue.TotalPrice + "</td><td>" + "</td ><td>  <input type='submit' value='delete' class='btn btn-Danger' onClick='deleteItem (" + elementValue.Id + ")' /> </td ><td>  <input type='submit' value='Edit' class='btn btn-Secondary' onClick='Editdata(" + elementValue.Id + ")' /> </td ></tr>"
                sum = sum + (elementValue.TotalPrice);
            });
            $("#tblInvoices tbody").append(html);

            $("#grdtotal").val(sum);


        }
    });
};

var deleteItem = function (Id) {
    var model = { Id: Id };
    $.ajax({
        url: "/RentPavti/deleteItem",
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

var Editdata = function (Id) {
    var model = { Id: Id };
    alert("Record Edit Successfully ....");
    $.ajax({
        url: "/RentPavti/GetEditData ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#hdnid").val(response.model.Id);
            $("#ItemNo").val(response.model.Item);
            $("#txtqty").val(response.model.TotalItem);
        }
    });
};

var savefinalinvoice = function () {
    var id = $("#hdnId").val();
    var reciptno = $("#TxtReciptNo").text();
    var grandtotal = $("#grdtotal").val();
    var advance = $("#TxtAdv").val();
    var balance = $("#Bal").val();
    
    var model = {
        Id: id,
        Reciptno: reciptno,
        GrandTotal: grandtotal,
        Advance: advance,
        Balance: balance,
    };

    $.ajax({
        url: "/RentPavti/SaveFinalInvoice",
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

var listget = function () {

    $.ajax({

        url: "/RentPavti/Linqlist",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblBook tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ReciptNo +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.City +
                    "</td><td>" + elementValue.StartTime +
                    "</td><td>" + elementValue.EndTime +
                    "</td><td>" + elementValue.Date +
                    "</td><td>" + elementValue.Item +
                    "</td><td>" + elementValue.PerDayRate +
                    "</td><td>" + elementValue.TotalItem +
                    "</td><td>" + elementValue.TotalPrice +
                    "</td><td>" + elementValue.GrandTotal +
                    "</td><td>" + elementValue.Advance +
                    "</td><td>" + elementValue.Balance +
                    "</td></tr>";
            });
            $("#tblBook tbody").append(html);
        }
    });
}
