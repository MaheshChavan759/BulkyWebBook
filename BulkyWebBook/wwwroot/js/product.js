﻿
$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {

    $('#tblTable').DataTable({
        "ajax": { url:'/admin/product/getall'},
        "columns": [
            { data: 'title' , "width":"10%"},
            { data: 'description' ,"width": "10%" },
            { data: 'author' ,"width": "10%" },
            { data: 'listPrise', "width": "10%" },
            { data: 'prise50', "width": "10%" },
            { data: 'prise100', "width": "10%" },
            { data: 'category.categoryName', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return ` <div class="w-75 btn-group" role="group">
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a href="" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },"width":"25"
            }
        ]
    });
}



