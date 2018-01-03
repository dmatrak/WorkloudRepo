var EmployeeSkillService = function () {

    var deleteEmployeeSkill = function (skillId, done, fail) {
        $.ajax({
            url: "http://workloudchallengewebservice20171228091627.azurewebsites.net/api/employeeSkills/" + skillId,
            type: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        deleteEmployeeSkill: deleteEmployeeSkill
    }
}();
