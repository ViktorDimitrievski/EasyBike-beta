$(document).ready(function () {

    CreateDataTable(($(".dataTable").length > 0 ? true : false));

});

function CreateDataTable(elExist) {
    if (elExist) {
        $('.dataTable').dataTable();
    }
}
