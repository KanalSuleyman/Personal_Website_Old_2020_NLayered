$(document).ready(function () {
    var table = $('#categoriesTable').DataTable({
        dom: 'Bfrtip',
        buttons: ['copy', 'excel', 'csv', 'pdf', 'print',
            {
                text: 'Add',
                attr: {
                    id: "btnAdd",
                },
                action: function (e, dt, node, config) {

                }
            },
            {
                text: 'Reload',
                attr: {
                    id: "btnReload",
                },
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Category/GetAllCategories/',
                        contentType: "application/json",

                        beforeSend: function () {
                            $('#categoriesTable').hide();
                            $('.loader').show();
                        },
                        success: function (data) {
                            const categoryListDto = jQuery.parseJSON(data);
                            console.log(categoryListDto);
                            if (categoryListDto.ResultStatus === 0) {
                                table.rows().remove();
                                $.each(categoryListDto.Categories.$values, function (index, category) {

                                    table.rows.add([
                                        [`${category.Id}`,
                                        `${category.Name}`,
                                        `${category.Description}`,
                                        `${convertFirstLetterToUpperCase((!category.IsDeleted).toString())}`,
                                        `${convertFirstLetterToUpperCase((!category.IsActive).toString())}`,
                                        `${convertToShortDate(category.CreatedDate)}`,
                                        `${convertToShortDate(category.ModifiedDate)}`,
                                        `${category.Articles.$values.length}`,
                                        `${category.Note}`,
                                        `
                                        <div class="column-operations">
                                            <button class="btn-update" data-id="${category.Id}"><i class='bx bx-edit-alt'></i></button>
                                            <button class="btn-delete" data-id="${category.Id}"><i class='bx bxs-trash'></i></button>
                                        </div>
                                        `
                                        ]
                                    ]);
                                });
                                table.draw();
                                $('.loader').hide();
                                $('#categoriesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${categoryListDto.Message}`, 'Failed Transaction!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.loader').hide();
                            $('#categoriesTable').fadeIn(1400);
                            toastr.error(`${err.statusText}`, 'An Error Occured!');
                        }
                    });
                }
            }
        ]
    });
    /* Datatable ends here */
    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here */
    $(function () {
        const url = '/Admin/Category/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        //const card = document.querySelector('.card');

        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                //card.style.display = 'flex';
                //placeHolderDiv.find(".modal").modal('show');
            });
        });

        placeHolderDiv.on('click', '.close', function (event) {
            placeHolderDiv.html('');
        });

        placeHolderDiv.on('click', '.cancel', function (event) {
            placeHolderDiv.html('');
            return false;
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here */
        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here */
        placeHolderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-category-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {

                const categoryAddAjaxModel = jQuery.parseJSON(data);
                console.log(categoryAddAjaxModel);
                const newFormBody = $('.card', categoryAddAjaxModel.CategoryAddPartial);
                placeHolderDiv.find('.card').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name = "IsValid"]').val() === 'True';
                if (isValid) {
                    $('#modalPlaceHolder').html('');
                    const newTableRow = `<tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
                                        <td>${categoryAddAjaxModel.CategoryDto.Category.Id}</td>
                                        <td>${categoryAddAjaxModel.CategoryDto.Category.Name}</td>
                                        <td>${categoryAddAjaxModel.CategoryDto.Category.Description}</td>
                                        <td>${convertFirstLetterToUpperCase((!categoryAddAjaxModel.CategoryDto.Category.IsDeleted).toString())}</td>
                                        <td>${convertFirstLetterToUpperCase(categoryAddAjaxModel.CategoryDto.Category.IsActive.toString())}</td>
                                        <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                        <td>${convertToShortDate(categoryAddAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                        <td>0</td>
                                        <td>${categoryAddAjaxModel.CategoryDto.Category.Note}</td>
                                        <td class="column-operations">
                                            <button class="btn-update" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><i class='bx bx-edit-alt'></i></button>
                                            <button class="btn-delete" data-id="${categoryAddAjaxModel.CategoryDto.Category.Id}"><i class='bx bxs-trash'></i></button>
                                        </td>
                                    </tr>`;
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    $('#categoriesTable').append(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryAddAjaxModel.CategoryDto.Message}`, "Successfully Added!");
                } else {
                    let summeryText = "";
                    $('#asp-validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summeryText = `- ${text}`;
                        toastr.warning(summeryText);
                    });

                }
            })
        })
    });
    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */
    /* Ajax POST / Deleting a Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find(`td:eq(1)`).text();
            console.log(categoryName);
            Swal.fire({
                title: 'Are you sure?',
                text: `${categoryName} named category will be deleted.
                    It is not a permanent delete from the database. You can change it later!`,
                showCancelButton: true,
                confirmButtonColor: '#93E9FA',
                cancelButtonColor: '#F05B57',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {

                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { categoryId: id },
                        url: '/Admin/Category/Delete/',
                        success: function (data) {
                            const categoryDto = jQuery.parseJSON(data);
                            if (categoryDto.ResultStatus === 0) {

                                Swal.fire(
                                    'Deleted!',
                                    `${categoryName} named category has been deleted successfully.`,
                                    'success'
                                );
                                tableRow.fadeOut(3500);
                            }
                            else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'An error occured',
                                    text: `${result.Message}`
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}, "Error!"`);
                        }
                    });


                }
            });
        });

    $(document).on('click', '.btn-update', function (event) {

        event.preventDefault();

        const url = "/Admin/Category/Update/";
        const placeHolderDiv = $('#modalPlaceHolder');
        const id = $(this).attr('data-id');

        $.get(url, { categoryId: id }).done(function (data) {
            placeHolderDiv.html(data);
        }).fail(function (data) {
            toastr.error("An error occured");
        });

        placeHolderDiv.on('click', '.close', function (event) {
            placeHolderDiv.html('');
        });

        placeHolderDiv.on('click', '.cancel', function (event) {
            placeHolderDiv.html('');
            return false;
        });

        placeHolderDiv.on('click', '#btnSave', function (event) {
            event.preventDefault();
            const form = $('#form-category-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {

                const categoryUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(categoryUpdateAjaxModel);
                const newFormBody = $('.card', categoryUpdateAjaxModel.CategoryUpdatePartial);
                placeHolderDiv.find('.card').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name = "IsValid"]').val() === 'True';
                if (isValid) {
                    $('#modalPlaceHolder').html('');
                    const newTableRow = `<tr name="${categoryUpdateAjaxModel.CategoryDto.Category.Id}">
                                        <td>${categoryUpdateAjaxModel.CategoryDto.Category.Id}</td>
                                        <td>${categoryUpdateAjaxModel.CategoryDto.Category.Name}</td>
                                        <td>${categoryUpdateAjaxModel.CategoryDto.Category.Description}</td>
                                        <td>${convertFirstLetterToUpperCase((!categoryUpdateAjaxModel.CategoryDto.Category.IsDeleted).toString())}</td>
                                        <td>${convertFirstLetterToUpperCase(categoryUpdateAjaxModel.CategoryDto.Category.IsActive.toString())}</td>
                                        <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.CreatedDate)}</td>
                                        <td>${convertToShortDate(categoryUpdateAjaxModel.CategoryDto.Category.ModifiedDate)}</td>
                                        <td>0</td>
                                        <td>${categoryUpdateAjaxModel.CategoryDto.Category.Note}</td>
                                        <td class="column-operations">
                                            <button class="btn-update" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><i class='bx bx-edit-alt'></i></button>
                                            <button class="btn-delete" data-id="${categoryUpdateAjaxModel.CategoryDto.Category.Id}"><i class='bx bxs-trash'></i></button>
                                        </td>
                                    </tr>`;
                    const categoryTableRow = $(`[name=${categoryUpdateAjaxModel.CategoryDto.Category.Id}]`);
                    const newTableRowObject = $(newTableRow);
                    newTableRowObject.hide();
                    categoryTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${categoryUpdateAjaxModel.CategoryDto.Message}`, "Successfully Updated!");
                } else {
                    let summeryText = "";
                    $('#asp-validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summeryText = `- ${text}`;
                        toastr.warning(summeryText);
                    });

                }
            }).fail(function (response) {
                console.log(response);
            });
        });

    });
});