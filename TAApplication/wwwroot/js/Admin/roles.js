$(document).ready(function () {
    $('#roles_table').DataTable();
});

function doit(id){
    $.post(
        {
            url: "/Admin/doitcs",
            data: { id: id }
        })
        .done(function (data) {
            console.log("Sample of data:", data);
        });
}
