

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
            title: 'هل تريد الحذف?',
            text: "لا يمكن التراجع عن الحذف!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'نعم احذفها!',
            cancelButtonText: 'الغاء!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Items/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'حذف!',
                            'تم حذف  فئه الاصناف.',
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