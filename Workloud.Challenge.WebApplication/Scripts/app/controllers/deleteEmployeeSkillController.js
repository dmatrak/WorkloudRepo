var DeleteEmployeeSkillController = function (employeeSkillService) {

    var deleteButton;

    var initialize = function () {
        $("#deleteSkillBtn").click(deleteEmployeeSkill);
    };

    var deleteEmployeeSkill = function (e) {

        deleteButton = $(e.target);

        var skillId = deleteButton.attr("data-employee-skill-id");

        deleteButton.attr("disabled", "disabled");

        employeeSkillService.deleteEmployeeSkill(skillId, done, fail);
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
}(EmployeeSkillService);