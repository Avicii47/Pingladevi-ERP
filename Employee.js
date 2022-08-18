$(document).ready(function () {

    //alert("Category added Sucessfully");
    getEmployeeList();
});

var saveEmployee = function () {
    var id = $("#txtId").val();
    var name = $("#txtname").val();
    var address = $("#txtaddress").val();
    var mobileno = $("#txtmobileno").val();
    var email = $("#txtemail").val();
    var city = $("#txtcity").val();
    var qualification = $("#txtqualification").val();
    var designation = $("#txtdesignation").val();
    var salary = $("#txtsalary").val();
    var jobtype = $("#txtjobtype").val();

    var model = {
        EmpID: id,
        EmpName: name,
        EmpAddress: address,
        EmpMibileno: mobileno,
        EmpEmail: email,
        EmpCity: city,
        EmpQualification: qualification,
        EmpDesignation: designation,
        Salary: salary,
        JobType: jobtype,

    };
    $.ajax({
        url: "/Employee/SaveEmployee",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",

        success: function (response) {
            
            alert("Successfull");
            getEmployeeList();
           
        }
    })
};
var getEmployeeList = function () {
    $.ajax({
        url: "/Employee/GetEmployeeList",
        method: "Post",
        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#Tbl_Employee tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.EmpID + "</td><td>" + elementValue.EmpName + "</td><td>" + elementValue.EmpAddress + "</td><td>" + elementValue.EmpMibileno + "</td><td>" + elementValue.EmpEmail + "</td><td>" + elementValue.EmpCity + "</td><td>" + elementValue.EmpQualification + "</td><td>" + elementValue.EmpDesignation + "</td><td>" + elementValue.Salary + "</td><td>" + elementValue.JobType + "</td></tr>";
            });
            $("#Tbl_Employee tbody").append(html);
        }
    });
}
