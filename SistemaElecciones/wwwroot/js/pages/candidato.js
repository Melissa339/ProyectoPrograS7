$(document).ready(function () {
    CreateTable();
});

function CreateTable() {
    $('#tableCandidato').DataTable({
        "autoWidth": true,
        "ordering": true,
        "lengthChange": true,
        dom: 'Bfrtip',
        "pageLength": 20,
        "language": {
            searchPlaceholder: 'Buscar Candidato',
            sSearch: '',
            lengthMenu: 'MENU items/page',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente',
            },
            info: "Mostrando _START_ a _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando 0 a 0 de 0 registros",
            infoFiltered: "(Filtrado de _TOTAL_ registros)",
            processing: `<div class="progress" style="margin: 0; width: 100%">
                                      <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
                                    </div>`,
            emptyTable: "No hay datos disponibles en esta tabla",
            buttons: {
                copyTitle: "Copiar al portapapeles",
                copySuccess: {
                    1: "Copi&oacute; una fila al portapapeles",
                    _: "Se copiaron %d filas al portapapeles"
                },
            }
        },
        buttons: [
            {
                extend: 'copy',
                text: '<i class="fas fa-clone"></i><strong>Copiar</strong>',
                messageTop: '',
                className: "btn btn-outline-dark",
                title: "Cargos",
                filename: "Cargos",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5],
                    page: 'all'
                },
                orientation: "landscape",
                pageSize: "LEGAL"
            },
            {
                extend: 'excel',
                text: '<i class="fas fa-file-excel"></i><strong>Excel </strong>',
                messageTop: '',
                className: "btn btn-outline-dark",
                title: "Cargos",
                filename: "Cargos",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5],
                    modifier: {
                        page: 'all',
                        search: 'none'
                    }
                },
                orientation: "landscape",
                pageSize: "LEGAL"
            }, {
                extend: 'pdf',
                text: '<i class="fas fa-file-excel"></i><strong>PDf </strong>',
                messageTop: '',
                className: "btn btn-outline-dark",
                title: "Cargos",
                filename: "Cargos",
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5],
                },
                orientation: "landscape",
                pageSize: "LEGAL"
            }]
    });
}

function ShowCreateModal() {
    $('#modalCreate').modal('show');
    $.ajax({
        url: '/Candidato/Create',
        async: true,
        type: "GET",
        atType: 'html',
        success: function (res) {
            $('#modalCreate').find('.modal-body').html(res);
        }
    });
}

function ShowEditModal(id) {
    $('#modalEdit').modal('show');

    $.ajax({
        url: '/Candidato/Editar',
        data: { candidatoId: id },
        async: true,
        type: "GET",
        atType: 'html',
        success: function (res) {
            $('#modalEdit').find('.modal-body').html(res);
        }
    });
}