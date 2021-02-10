
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/book/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "author", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/reservation/Index" class='btn btn-warning text-white' style='cursor:pointer; width:120px;'>
                                    <i class='fas fa-list'></i> Rezerwacje
                                </a>
                                &nbsp;
                                <a href="/Admin/book/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:120px;'>
                                    <i class='far fa-edit'></i> Edycja
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/book/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:120px;'>
                                    <i class='far fa-trash-alt'></i> Usuń
                                </a>
                            </div>
                            `;
                }, "width": "45%"
            }
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the content!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}