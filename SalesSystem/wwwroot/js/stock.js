//$(function () {
//    $("#loaderbody").addClass('hide');

//    $(document).bind('ajaxStart', function () {
//        $("#loaderbody").removeClass('hide');
//    }).bind('ajaxStop', function () {
//        $("#loaderbody").addClass('hide');
//    });
//});

showInPopup = (url, title) => {
    console.log(url);
    $.ajax({
       
        type: 'GET',
        url: url,
   
        success: function (res) {
         
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
          
            // to make popup draggable
            //$('.modal-dialog').draggable({
            //    handle: ".modal-header"
            //});
        }
    })
}

jQueryAjaxPost = form => {
    console.log("huda"); 
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    $.notify("تم الحفظ بنجاح", { globalPosition: 'top center', className: 'success', showAnimation: 'slideDown' });
                    
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}
$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'Are you sure that you need to delete this game?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Stocks/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'Deleted!',
                            'Game has been deleted.',
                            'success'
                        );

                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});
//delete resourcetype
$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'هل تريد حذف المجموعه?',
            text: "لا يمكن التراجع عن عملية الحذف!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'نعم, احذفها!',
            cancelButtonText: 'لا, الغاء!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/ResourceType/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'حذف!',
                            'تم الحذف .',
                            'بنجاح'
                        );

                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});

/*/delete resource*/
$(document).ready(function () {
    console.log("l");
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'هل تريد حذف المورد?',
            text: "لا يمكن التراجع عن عملية الحذف!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'نعم, احذفه!',
            cancelButtonText: 'لا, الغاء!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Resources/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'حذف!',
                            'تم الحذف .',
                            'بنجاح'
                        );

                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});