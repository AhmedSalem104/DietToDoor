$(function () {
    $("#add").click(function () {

        var isValid = true;

        if ($("#TbItem #MainRow #ItemListPop").val() == ""||0) {
            toastr.warning('اختر الصنف ...!')
             isValid = false;
        }
        if ($(".Price").val().trim() == '') {
            toastr.warning('ادخل السعر ...!')
            isValid = false;
        }
        if ($(".Qty").val().trim() == '' || 0) {
            toastr.warning('ادخل الكمية ...!')
            isValid = false;
        }
        //if (document.getElementById("StoreList").selectedIndex == 0) {
        //    toastr.warning('اختر المخزن ...!')
        //    isValid = false;
        //}
        //else {
        //    $("#ItemList").siblings('span.error').text('');

        //}

        //if (!($("#quantity").val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
        //    $("#quantity").siblings('span.error').text('plez enter quantity');
        //    isValid = false;
        //}
        //else {
        //    $("#quantity").siblings('span.error').text('');

        //}
    
        if (isValid) {
            var productID = document.getElementById("ItemListPop").value;
           
            var $newRow = $("#MainRow").clone().removeAttr('id');

            $('.ItemListPop', $newRow).val(productID);
         
            $('#add', $newRow).addClass('remove').html('<i class="fa fa-trash" aria-hidden="true"></i>').removeClass('newbtn waves-effect btn-add').addClass('deleteItem btn btn-icon btn-outline-danger');
            $('#UnitList,StoreList,#ItemListPop,#Qty,#Price,#Total,#Disper,#DisValue,#Net', $newRow).attr('disabled', true);
            $('#UnitList,StoreList,#ItemListPop,#Qty,#Price,#Total,#Disper,#DisValue,#Net', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $("#OrdersItems").append($newRow[0]).remove("#ItemCategoriesList");
            $("#OrdersItems #GroupHide").hide();
            $("#OrdersItems #ItemCode").show();
            

            document.getElementById("ItemCategoriesList").selectedIndex = 0;
            document.getElementById("UnitList").selectedIndex = 0;
            document.getElementById("StoreList").selectedIndex = 0;
            //document.getElementById("ItemList").selectedIndex = 0;
           
            $("#Price").val(0);
            $("#Qty").val(1);
            $("#Total").val('');
            $("#Disper").val(0);
            $("#DisValue").val(0);
            $("#Net").val('');
          

        }


    });

  
    $("#submit").click(function () {

        var isValid = true;
        var itemsList = [];
        $("#OrdersItems tbody tr").each(function () {
          
            var item = {
                ItemCategoriesId: $('#ItemCategoriesList', this).val(),
                ItemId: $('#ItemListPop', this).val(), 
                Price: $('.Price', this).val(),
                UnitId: $('.UnitList', this).val(),
                Amount: $('.Qty', this).val(),
                Total: $('.Total', this).val(),
                DisPer: $('.Disper', this).val(),
                DisValue: $('.DisValue', this).val(),
                NetPrice: $('.Net', this).val(),
                ItemBalance: $('#ItemBalance', this).val(),
                StoreId: $('.StoreList', this).val()
            }
            itemsList.push(item);
        });


        if (itemsList.length == 0) {

            toastr.warning('اختر الصنف ...!')
            isValid = false;

        }
        if (document.getElementById("CustomersList").selectedIndex == 0) {
            toastr.warning('اختر المورد ...!')
            isValid = false;
        }
        if (document.getElementById("StoreList").selectedIndex == 0) {
            toastr.warning('اختر المخزن ...!')
            isValid = false;
        } 
        if (document.getElementById("BranchList").selectedIndex == 0) {
            toastr.warning('اختر الفرع ...!')
            isValid = false;
        } 
        if (document.getElementById("EmployeeList").selectedIndex == 0) {
            toastr.warning('اختر الموظف ...!')
            isValid = false;
        }
        if ($("#PurchaseINVTypeList").val() == 0 || $("#PurchaseINVTypeList").val() == "" || $("#PurchaseINVTypeList").val() == null) {
            toastr.warning("ادخل نوع الفاتورة");
            isValid = false;
        }

        //if (!($(".VendorsList").val().trim() != '' || 0)) {
        //    toastr.warning('اختر المورد ...!')
        //    isValid = false;
        //}
        //if (!($(".EmployeeList").val().trim() != '' || 0)) {
        //    toastr.warning('اختر الموظف ...!')
        //    isValid = false;
        //}
        //if (!($("#a3").val().trim() != '' || 0)) {
        //    toastr.warning(' ادخل رقم الفاتورة ...!')
        //    isValid = false;
        //}
      
        //if (!($("#StoreList").val().trim() != '' || 0)) {
        //    toastr.warning(' اختر المخزن ...!')
        //    isValid = false;
        //} 
        //if (!($("#BranchList").val().trim() != '' || 0)) {
        //    toastr.warning(' اختر الفرع ...!')
        //    isValid = false;
        //} 
        //if (!($("#a8").val().trim() != '' || 0)) {
        //    toastr.warning(' ادخل الملاحظات بالعربي  ...!')
        //    isValid = false;
        //}

        if (isValid) {
            var data = {
                SalesINVNo: $("#SalesINVNo").val(),
                SalesINVDate: $("#SalesINVDate").val(),
                CustomersId: $("#CustomersList").val(),
                StoreId: $("#StoreList").val(),
                SalesOrderNo: $("#SalesOrderNo").val(),
                SalesOrderDate: $("#SalesOrderDate").val(),
                SalesPaperNo: $("#SalesPaperNo").val(),
                SalesPaperDate: $("#SalesPaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
                DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
                SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
                Itemtax: $("#Itemtax").val(),
                RowsCount: $("#RowsCount").val(), 
                TotaleItemDis: $("#TotaleItemDis").val(), 
                SalesINVTotal: $("#TotalNet").val(), 
                InvoiceDisPer: $("#TotalDisper").val(),
                InvoiceDisValue: $("#TotalDis").val(),
                NetValue: $("#TotalNet").val(),
                PaidValue: $("#Payed").val(),
                RemainingValue: $("#Residual").val(),
                Notes: $("#Notes").val(), 
                Items: itemsList
            }


            $("#submit").attr("disabled", true);
            $(".remove ").hide();

            //AddOrderAndSetails
            $.ajax({
                type: 'POST',
                url: '/SalesINV_R/AddSalesINV',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        //$('#Ordermessages').text(data.message);
                        toastr.success("تم الحفظ بنجاح")

                    }
                    else {
                        //$('#Ordermessages').text(data.message);
                        toastr.danger("فشل في الحفظ")

                    }
                   

                }

            });

        }




    });
});
$("#update").click(function () {

    var isValid = true;
    var itemsList = [];
    $("#OrdersItems tbody tr").each(function () {

        var item = {
            ItemCategoriesId: $('#ItemCategoriesList', this).val(),
            ItemId: $('.ItemListPopUp', this).val(),
            Price: $('.Price', this).val(),
            UnitId: $('.UnitList', this).val(),
            Amount: $('.Qty', this).val(),
            Total: $('.Total', this).val(),
            DisPer: $('.Disper', this).val(),
            DisValue: $('.DisValue', this).val(),
            NetPrice: $('.Net', this).val(),
            ItemBalance: $('#ItemBalance', this).val(),
            StoreId: $('.StoreList', this).val()
        }
        itemsList.push(item);
    });


    if (itemsList.length == 0) {

        toastr.warning('اختر الصنف ...!')
        isValid = false;

    }
    if (document.getElementById("CustomersList").selectedIndex == 0) {
        toastr.warning('اختر المورد ...!')
        isValid = false;
    }
    if (document.getElementById("StoreList").selectedIndex == 0) {
        toastr.warning('اختر المخزن ...!')
        isValid = false;
    }
    if (document.getElementById("BranchList").selectedIndex == 0) {
        toastr.warning('اختر الفرع ...!')
        isValid = false;
    }
    if (document.getElementById("EmployeeList").selectedIndex == 0) {
        toastr.warning('اختر الموظف ...!')
        isValid = false;
    }
    if ($("#PurchaseINVTypeList").val() == 0 || $("#PurchaseINVTypeList").val() == "" || $("#PurchaseINVTypeList").val() == null) {
        toastr.warning("ادخل نوع الفاتورة");
        isValid = false;
    }

    //if (!($(".VendorsList").val().trim() != '' || 0)) {
    //    toastr.warning('اختر المورد ...!')
    //    isValid = false;
    //}
    //if (!($(".EmployeeList").val().trim() != '' || 0)) {
    //    toastr.warning('اختر الموظف ...!')
    //    isValid = false;
    //}
    //if (!($("#a3").val().trim() != '' || 0)) {
    //    toastr.warning(' ادخل رقم الفاتورة ...!')
    //    isValid = false;
    //}

    //if (!($("#StoreList").val().trim() != '' || 0)) {
    //    toastr.warning(' اختر المخزن ...!')
    //    isValid = false;
    //} 
    //if (!($("#BranchList").val().trim() != '' || 0)) {
    //    toastr.warning(' اختر الفرع ...!')
    //    isValid = false;
    //} 
    //if (!($("#a8").val().trim() != '' || 0)) {
    //    toastr.warning(' ادخل الملاحظات بالعربي  ...!')
    //    isValid = false;
    //}

    if (isValid) {
        var data = {
            SalesINVNo: $("#SalesINVNo").val(),
            SalesINVDate: $("#SalesINVDate").val(),
            CustomersId: $("#CustomersList").val(),
            StoreId: $("#StoreList").val(),
            SalesOrderNo: $("#SalesOrderNo").val(),
            SalesOrderDate: $("#SalesOrderDate").val(),
            SalesPaperNo: $("#SalesPaperNo").val(),
            SalesPaperDate: $("#SalesPaperDate").val(),
            EmployeeId: $("#EmployeeList").val(),
            PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
            DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
            SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
            Itemtax: $("#Itemtax").val(),
            RowsCount: $("#RowsCount").val(),
            TotaleItemDis: $("#TotaleItemDis").val(),
            SalesINVTotal: $("#TotalNet").val(),
            InvoiceDisPer: $("#TotalDisper").val(),
            InvoiceDisValue: $("#TotalDis").val(),
            NetValue: $("#TotalNet").val(),
            PaidValue: $("#Payed").val(),
            RemainingValue: $("#Residual").val(),
            Notes: $("#Notes").val(),
            Items: itemsList
        }


        $("#update").attr("disabled", true);
        $(".remove ").hide();

        //AddOrderAndSetails
        $.ajax({
            type: 'POST',
            url: '/SalesINV_R/UpdateSalesINV',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                if (data.status) {
                    //$('#Ordermessages').text(data.message);
                    toastr.success("تم التعديل بنجاح")

                }
                else {
                    //$('#Ordermessages').text(data.message);
                    toastr.danger("فشل في التعديل")

                }


            }

        });

    }




});







