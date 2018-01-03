var EmployeeService = function () {
   
    var deleteEmployee = function (employeeId, done, fail) {
        $.ajax({
            url: "http://workloudchallengewebservice20171228091627.azurewebsites.net/api/employee/" + employeeId,
            type: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        deleteEmployee: deleteEmployee
    }
}();
