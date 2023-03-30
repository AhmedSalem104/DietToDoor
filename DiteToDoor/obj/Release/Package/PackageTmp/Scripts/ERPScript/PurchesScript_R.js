$(function () {
    $("#addNew").click(function () {

        var isValid = true;

        if ($("#ItemListPop").val() == '' || 0) {
            toastr.warning('اختر الصنف ...!')
             isValid = false;
        }
        if ($("#MainRow #Price").val().trim() == '') {
            toastr.warning('ادخل السعر ...!')
            isValid = false;
        }
        if ($("#MainRow #Qty").val().trim() == '' || 0) {
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
            var productID = document.getElementById("ItemList").value;
           
            var $newRow = $("#MainRow").clone().removeAttr('id');

            $('.ItemListPop', $newRow).val(productID);
         
            $('#addNew', $newRow).addClass('remove').html(' <i class="fa fa-trash" aria-hidden="true"></i>').removeClass('newbtn waves-effect btn-add').addClass('deleteItem btn btn-icon btn-outline-danger');
            $('#UnitList,StoreListPop,#ItemListPop,#Qty,#Price,#Total,#Disper,#DisValue,#Net', $newRow).attr('disabled', true);
            $('#UnitList,StoreListPop,#ItemListPop,#Qty,#Price,#Total,#Disper,#DisValue,#Net', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $("#OrdersItems").append($newRow[0]).remove("#ItemCategoriesList");
            $("#OrdersItems #GroupHide").hide();
            $("#OrdersItems #ItemCode").show();
            

            document.getElementById("ItemCategoriesList").selectedIndex = 0;
            document.getElementById("UnitList").selectedIndex = 0;
            document.getElementById("StoreListPop").selectedIndex = 0;
            document.getElementById("ItemListPop").selectedIndex = 0;
           
            $("#TbItem #MainRow #Price").val(0);
            $("#TbItem #MainRow #Qty").val(1);
            $("#TbItem #MainRow #Total").val('');
            $("#TbItem #MainRow #Disper").val(0);
            $("#TbItem #MainRow #DisValue").val(0);
            $("#TbItem #MainRow #Net").val('');
          

        }


    });

  
    $("#submit").click(function () {

        var isValid = true;
        var itemsList = [];
        $("#OrdersItems tbody tr").each(function () {
          
            var item = {
                ItemCategoriesId: $('#ItemCategoriesList', this).val(),
                ItemId: $('.ItemList', this).val(), 
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

        var Vendor = $('#VendorsList').val();
      
        var Store = $('.StoreList').val();
      
        var Employee = $('#EmployeeList').val();
        
        if (itemsList.length == 0 || Vendor == "" || Store == "" || Employee== "") {

            toastr.warning('اختر الصنف ...!' + "<br/><br/>" + 'اختر المورد ...!' + "<br/><br/>" + 'اختر المخزن ...!' + "<br/><br/>" +'اختر الموظف ...!')
            isValid = false;

        }
        if ($("#PurchaseINVTypeList").val() == 0 || $("#PurchaseINVTypeList").val() == "" || $("#PurchaseINVTypeList").val() == null) {
            toastr.warning("ادخل نوع الفاتورة");
            isValid = false;
        }
        //if (document.getElementById("VendorsList").selectedIndex == 0) {
        //    toastr.warning('اختر المورد ...!'+"<br/>"+'osamaaaaa')
        //    isValid = false;
        //}
        //if (document.getElementById("StoreList").selectedIndex == 0) {
        //    toastr.warning('اختر المخزن ...!')
        //    isValid = false;
        //} 
        //if (document.getElementById("BranchList").selectedIndex == 0) {
        //    toastr.warning('اختر الفرع ...!')
        //    isValid = false;
        //} 
        //if (document.getElementById("EmployeeList").selectedIndex == 0) {
        //    toastr.warning('اختر الموظف ...!')
        //    isValid = false;
        //} 

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
                PurchaseINVNo: $("#PurchaseINVNo_R").val(),
                PurchaseINVNo_R: 0,
                PurchaseINVDate: $("#PurchaseINVDate").val(),
                VendorId: $("#VendorsList").val(),
                StoreId: $("#StoreList").val(),
                PurchaseOrderNo: $("#PurchaseOrderNo").val(),
                PurchaseOrderDate: $("#PurchaseINVDate").val(),
                PurchasePaperNo: $("#PurchasePaperNo").val(),
                PurchasePaperDate: $("#PurchasePaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
                PaymentTypeId: $("#PaymentTypeList").val(),
                DirectExpenses1: $("#DirectExpenses1").val(),
                DirectExpenses2: $("#DirectExpenses2").val(),
                RowsCount: $("#RowsCount").val(), 
                TotaleItemDis: $("#TotaleItemDis").val(),
                PurchaseINVTotal: $("#TotalBeforeDis").val(),
                InvoiceDisPer: $("#TotalDisper").val(),
                InvoiceDisValue: $("#TotalDis").val(),
                NetValue: $("#TotalNet").val(),
                PaidValue: $("#Payed").val(),
                RemainingValue: $("#Residual").val(),
                Notes: $("#Notes").val(), 
                Items: itemsList
            }


            $(".submit").attr("disabled", true);
            //$(".remove ").hide();

            //AddOrderAndSetails
            $.ajax({
                type: 'POST',
                url: '/PurchaseINV_R/AddPurchase',
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








