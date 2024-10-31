
$(document).ready(function () {
    // Delete row when delete button is clicked
    $("body").on('click', '.delete', function () {
        $(this).closest('tr').remove();
        $("#ItemTableView").find(`tr[data-id="${$(this).closest('tr').attr("data-id")}"]`).remove()

    });
    $(".input").change(function () {
        $("#" + $(this).attr('id') + "Text").text($(this).val())
    });
    $("#SaveRequest").click(function () {
        if ($("#ImporterName").val()=='') {
            ErrorMessage("Importer Name is required");
            return false;
        }
        if ($("#ImporterEmail").val() == '') {
            ErrorMessage("Importer Email is required");
            return false;
        }
        if ($("#ExportCountry").val() == '') {
            ErrorMessage("Export Country is required");
            return false;
        }
        if ($("#ImporterMobile").val() == '') {
            ErrorMessage("Importer Mobile is required");
            return false;
        }
        if ($("#ExportCity").val() == '') {
            ErrorMessage("Export City is required");
            return false;
        }
        if ($("#ImportDate").val() == '') {
            ErrorMessage("Import Date is required");
            return false;
        }
        var items = [];
        $("#ItemTable tbody tr").each(function () {
            var item = {
                id: $(this).attr("data-id"),
                count: $(this).find(".itemcount").text()
            }
            items.push(item);
        });
        var request = {
            importerName: $("#ImporterName").val(),
            importerEmail: $("#ImporterEmail").val(),
            importerMobile: $("#ImporterMobile").val(),
            exportCountry: $("#ExportCountry").val(),
            exportCity: $("#ExportCity").val(),
            importDate: $("#ImportDate").val(),
            ItemsList: items
        };

        $.ajax({
            url: '/Import/CreateNewRequest', // URL to send the request to
            type: 'post', // Method type
            data: { input: request },
            success: function (data) {
                window.location = "/import"
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle error
            }
        });
    });

    $("#AddItem").click(function () {
        if ($("#ItemCount").val() <= 0 || $("#ItemCount").val() > 5) {
            ErrorMessage("please enter valid value between 1 to 5 ")
            return false;
        }
        if ($("#itemName").val() == '') {
            ErrorMessage("Please select Item");
            return false;
        }
        if ($("#itemName").val() != '' ) {
            var isdublicated = false;
            $('#ItemTable tbody tr').each(function () {
                if ($(this).attr("data-id") == $("#itemName").val())
                    isdublicated = true;
            });
            if (isdublicated) {
                ErrorMessage("this item exist befor")
                return false;
            }
            // Create new row HTML
            const newRow = `
        <tr data-id="${$("#itemName").val()}">
          <td>${$('#itemName option:selected').text()}</td>
          <td class="itemcount">${$("#ItemCount").val()}</td>
          <td><button class="delete btn btn-danger">Delete</button></td>
        </tr>
      `;
            const newRowView = `
        <tr data-id="${$("#itemName").val()}">
          <td>${$('#itemName option:selected').text()}</td>
          <td class="itemcount">${$("#ItemCount").val()}</td>
        </tr>
      `;
            // Append new row to the table body
            $('#ItemTable tbody').append(newRow);
            $('#ItemTableView tbody').append(newRowView);

            $("#itemName").val("");
            $("#itemName").trigger('change');
            $("#ItemCount").val(1);

        }
    });

    document.querySelectorAll('.next-tab').forEach(button => {
        button.addEventListener('click', () => {
            let currentTab = document.querySelector('.nav-link.active');
            let nextTab = currentTab.parentElement.nextElementSibling?.querySelector('.nav-link');
            if (nextTab) nextTab.click();
        });
    });

    document.querySelectorAll('.prev-tab').forEach(button => {
        button.addEventListener('click', () => {
            let currentTab = document.querySelector('.nav-link.active');
            let prevTab = currentTab.parentElement.previousElementSibling?.querySelector('.nav-link');
            if (prevTab) prevTab.click();
        });

    });
    function ErrorMessage(error) {
        Swal.fire({
            title: 'Please Complete data',
            text: error ,
            icon: 'warning',
        }).then((result) => {

        }

        );

    }
    $(".Viewrequest").click(function () {
        $.ajax({
            url: '/Import/ViewRequest', // URL to send the request to
            type: 'Get', // Method type
            data: { id: $(this).attr("data-id") },
            success: function (data) {
                $("#RequestDetail").html(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle error
            }
        });
        $("#ShowRequestDetail").modal('show');
    });
});

