$(document).ready(function () {
    $('#dataTableData').DataTable({

    })

    // Get the table elements
    var table1 = $('#myTable1');
    var table2 = $('#myTable2');
    var table3 = $('#myTable3');

    // Check if each table has already been initialised
    if (!$.fn.dataTable.isDataTable(table1)) {
        // Initialise the DataTable for table1
        table1.DataTable();
    }

    if (!$.fn.dataTable.isDataTable(table2)) {
        // Initialise the DataTable for table2
        table2.DataTable();
    }

    if (!$.fn.dataTable.isDataTable(table3)) {
        // Initialise the DataTable for table3
        table3.DataTable();
    }
});
