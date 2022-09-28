
$('#roles_table').DataTable();

function Change_Role(user_id, role) {
    $.post(
        {
            url: "/Admin/Change_Role",
            data: { user_id: user_id, role: role}
        })
        .done(function (data) {
            console.log("Done");
        });
}
