$("#roles_table").DataTable();

function doit(id){
    console.log("Sample of id:", id);
}
$.post(
    {
        url: "/Admin/doitcs",
        data: { id: id }
    })
    .done(function (data) {
        console.log("Sample of data:", data);
    });