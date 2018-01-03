var DeleteEmployeeController = function (employeeService) {

    var deleteButton;

    var initialize = function () {
        $("#deleteBtnId").click(deleteEmployee);
    };

    var deleteEmployee = function (e) {

        deleteButton = $(e.target);

        var employeeId = deleteButton.attr("data-employee-id");

        deleteButton.attr("disabled", "disabled");

        employeeService.deleteEmployee(employeeId, done, fail);
    };

    var done = function () {
        $("#alertElement").show();
        setTimeout(function () { $("#alertElement").hide(); }, 5000);
    };

    var fail = function () {
        deleteButton.removeAttr("disabled");
    };

    return {
        initialize: initialize
    }
}(EmployeeService);