
let ddlStockId = document.getElementById("ddlStockId");
let ddlProduct = document.getElementById("ddlProduct");
let quntity = document.getElementById("quntity");
let price = document.getElementById("price");
let discount = document.getElementById("discount");
let barcode = document.getElementById("barcode");
let Orderquentity = document.getElementById("Orderquentity");
let quentityStockNow = document.getElementById("quentityStockNow");
let quentityStock = document.getElementById("quentityStock");
console.log(ddlStockId);

//Retuer Product Where CategoryId

ShowProduct = () => {
    console.log(ddlStockId);
    console.log("huda");
    if ($('#ddlStockId').val() == "") {
        $('#ddlProduct').html(`<option value="">اخترالمخزن</option>`);
        console.log("huda1");
    }
    else {
        console.log("huda2");
        $.ajax({
        /* //   url: `/Home/GetProduct/${ddlStockId.value}`*/
            url: '/BayInvoice/GetProduct/'+ ddlStockId.value,
            method: 'GET',
            cache: false,
            success: (data) => {
                console.log(data)
                let Product = '';
                Product += `<option value="">أختر المنتج .....</option>`;
                for (x in data) {

                    Product += `<option value="${data[x].id}">${data[x].name}</option>`;
                }
                $('#ddlProduct').html(Product);
            }
        });
    }
   

}
//GetOrderQuentity
GetOrderQuentity = () => {
    $.ajax({
        url: '/BayInvoice/GetQOrderdetails/' + ddlProduct.value,

        method: 'GET',
        cache: false,
        success: (data) => {

            console.log(data);
            console.log(data.orderquentity);
            console.log(data[0].orderquentity);
            $('#Orderquentity').val(data[0].orderquentity);
            $('#quentityStockNow').val($('#quentityStock').val() - $('#Orderquentity').val());


        }
    });
}

ShowPrice = () => {
    GetOrderQuentity();
    $.ajax({
        url: '/BayInvoice/GetPriceProduct/'+ddlProduct.value,

      method: 'GET',
        cache: false,
        success: (data) => {
          
           

            
            $('#price').val(data.pricePruchase);
            $('#barcode').val(data.barcode);
            $('#quentityStock').val(data.quentityStock);
        }
    });
}

SavaPrducts = () => {

    let objPrduct = {

        ProductId: ddlProduct.value,
        StockId: ddlStockId.value,
        PriceSale: price.value,
        Quentit: quntity.value,
        Total: price.value * quntity.value,
        Discount: discount.value,
        Barcode:barcode.value
    };
    let data = JSON.stringify(objPrduct);
    $.ajax({
        url: '/api/APIInvoice',
        method: 'POST',
        contentType: 'application/json',
        data: data,
        cache: false,
        success: (data) => {
         
            console.log(data);
          ResetData();
           ShowTable();
           GetTotal();
        }

   });

};

ResetData = () => {
    ddlProduct.value = '';
    discount.value = 0;
    quntity.value = 1;
    price.value = 0;
    barcode.value = '';
    Orderquentity.value = '';
    quentityStockNow.value = '';
    quentityStock.value = '';
};

ShowTable = () => {

    $.ajax({

        url: '/api/APIInvoice',
        method: 'GET',
        cache: false,
        success: (data) => {
            console.log(data);
            let Table = '';

            for (x in data) {

                Table += `
                  <tr>
                    <td>#</td>
                    <td>${data[x].barcode}</td>
                    <td>${data[x].product.name}</td>
                    <td>${data[x].priceSale}</td>
                    <td>${data[x].quentit}</td>
                    <td>${data[x].discount}</td>
                    <td>${data[x].total}</td>
                    <td><a class="btn btn-danger" onclick="DeleteProduct(${data[x].invoiceId})"  style="color:#ffff"><i class="bi bi-trash"></i></a></td>
                </tr>`;
            }
            $('#tablebody').html(Table);
        }
    });

};

DeleteProduct = (id) => {
   
    Swal.fire({
        title: "؟؟هل تريد الحذف",
        text: "لايمكن التراجع عن حذف الصنف!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        cancelButtonText:"الغاء",
        confirmButtonText: "نعم احذفها!",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                    url: `/api/APIInvoice/${id}`,
                    method: 'DELETE',
                    cache: false,
                    success: () => {
                       
                        Swal.fire({
                            title: "حذف!",
                            text: "تم الحذف بنجاح",
                            icon: "success"
                        });
                        ShowTable();
                        GetTotal();
                    }
                })
           
        }
    });
    
    

};
//delete bayinvoice
$(document).ready(function () {
    $('.jss-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'هل انت متاكد من حذف هذه الفاتوره',

            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'نعم ',
            cancelButtonText: 'الغاء!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/BayInvoice/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'حذف!',
                            'تم حذف الفاتوره',
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
GetTotal = () => {

    $.ajax({
        url: `/api/APIInvoice/GetAllTotal`,
        method: 'GET',
        cache: false,
        success: (data) => {
            $('#allTotal').val(data);
            $('#afterDescount').val(data);

        }
    });

};

Discount = () => {

    $('#afterDescount').val($('#allTotal').val() - $('#discountTotal').val());
};

document.getElementById("discountTotal").addEventListener('change', Discount);
document.getElementById("discountTotal").addEventListener('keyup', Discount);

$(document).ready(()=>{
    ShowTable();
    GetTotal();
});

