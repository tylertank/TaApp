$(document).ready(function () {
    $('#roles_table').dataTable();
});


function Change_Role(user_id, role) {
    $.post(
        {
            url: "/Admin/Change_Role",
            data: { user_id: user_id, role: role }
        })
        .done(function (response) {
            console.log("Done");
        }).catch(error => {
            window.location.reload();
            console.log("Error");
        });
}