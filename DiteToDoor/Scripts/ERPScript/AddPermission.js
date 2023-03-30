//const { Console } = require("node:console");

$(function () {
    $("#add").click(function () {
        var isValid = true;
        $('#OrdersItems .ItemListPopUp').each(function () {

            var OldItem = $(this).val();
            var NewItem = $("#ItemListPopUp").val();
            if (NewItem == OldItem) {
                toastr.warning('الصنف موجود بالفعل في الفاتورة')
                isValid = false;
            }

            if (document.getElementById("ItemListPopUp").selectedIndex == 0) {
                toastr.warning('اختر الصنف ...!')
                isValid = false;
            }
        });

        if ($("#Price").val().trim() == '' || $("#Price").val() == 0 || document.getElementById("ItemListPopUp").selectedIndex == 0) {
            toastr.warning('ادخل الصنف والسعر ...!')
            isValid = false;
        }
        if ($("#Qty").val().trim() == '' || 0) {
            toastr.warning('ادخل الكمية ...!')
            isValid = false;
        }

        if (isValid) {
            var productID = document.getElementById("ItemListPopUp").value;

            var $newRow = $("#MainRow").clone().removeAttr('id');

            $('.ItemListPopUp', $newRow).val(productID);

            $('#add', $newRow).addClass('remove').html('<i class="fa fa-minus"></i>').removeClass('newbtn waves-effect btn-add').addClass('btn-danger');
            $('#ItemCode,#UnitList,StoreList,#ItemListPopUp,#Qty,#Price,#Total,#Disper,#DisValue,#Net', $newRow).attr('disabled', true);
            $('#ItemCode,#UnitList,StoreList,#ItemListPopUp,#Qty,#Price,#Total,#Disper,#DisValue,#Net', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $("#OrdersItems").append($newRow[0]).remove("#ItemCategoriesList");
            $("#OrdersItems #GroupHide").hide();
            $("#OrdersItems #ItemCode").show();


            //document.getElementById("ItemCategoriesList").selectedIndex = 0;
            //document.getElementById("UnitList").selectedIndex = 0;
            //document.getElementById("StoreList").selectedIndex = 0;
            //document.getElementById("ItemListPopUp").selectedIndex = 0;
            //$.get("/StoreAddPermission/GetItemGroupList", function (data) {
            //    $("#ItemCategoriesList").empty();
            //    $("#ItemCategoriesList").append("<option> اختر مجموعة الصنف  </option>")
            //    $.each(data, function (index, row) {

            //        $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
            //    });
            //});

            $.get("/StoreAddPermission/GetItemList", { ID: 0 }, function (data) {
                $("#ItemListPopUp").empty();
                $("#ItemListPopUp").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemListPopUp").append("<option value='" + row.Id + "'>" + row.ItemNameAr + "</option>")
                });
            });

            $.get("/StoreAddPermission/GetItemGroupList", function (data) {
                $("#ItemCategoriesList").empty();
                $("#ItemCategoriesList").append("<option> اختر مجموعة الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
                });
            });

            $.get("/StoreAddPermission/GetUintList", { ID: 0 }, function (data) {
                $("#UnitList").empty();
                $("#UnitList").append("<option> اختر الوحدة  </option>")
                $.each(data, function (index, row) {

                    $("#UnitList").append("<option value='" + row.Id + "'>" + row.UnitName + "</option>")
                });
            });

            $("#Price").val(0);
            $("#Qty").val(1);
            //$("#Total").text('');
            //$("#Disper").val(0);
            //$("#DisValue").val(0);
            //$("#Net").text('');


        }

    });


    $("#submit").click(function () {

        var isValid = true;
        var itemsList = [];
        $("#OrdersItems tbody tr").each(function () {

            var item = {
                ItemCategoriesId: $('.ItemCategoriesList', this).val(),
                ItemId: $('.ItemListPopUp', this).val(),
                Price: $('.Price', this).val(),
                UnitId: $('.UnitList', this).val(),
                Amount: $('.Qty', this).val(),
                Total: $('.Total', this).text(),
                DisPer: $('.Disper', this).val(),
                DisValue: $('.DisValue', this).val(),
                NetPrice: $('.Net', this).text(),
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
        if (document.getElementById("StoreTRXTypesList").selectedIndex == 0) {
            toastr.warning('اختر نوع الإذن ...!')
            isValid = false;
        }
        //if (document.getElementById("PurchaseINVTypeList").selectedIndex == 0) {
        //    toastr.warning("ادخل نوع الفاتورة");
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
                AddPermissionNo: $("#SalesINVNo").val(),
                AddPermissionDate: $("#SalesINVDate").val(),
                VendorId: $("#CustomersList").val(),
                StoreId: $("#StoreList").val(),
                //SalesOrderNo: $("#SalesOrderNo").val(),
                //SalesOrderDate: $("#SalesOrderDate").val(),
                //SalesPaperNo: $("#SalesPaperNo").val(),
                //SalesPaperDate: $("#SalesPaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                //PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
                //DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
                //SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
                //Itemtax: $("#Itemtax").val(),
                RowsCount: $("#RowsCount").val(),
                TotaleItemDis: $("#TotaleItemDis").val(),
                SalesINVTotal: $("#TotalBeforeDis").text(),
                InvoiceDisPer: $("#TotalDisper").val(),
                InvoiceDisValue: $("#TotalDis").val(),
                NetValue: $("#TotalNet").text(),
                PaidValue: $("#Payed").val(),
                RemainingValue: $("#Residual").text(),
                Notes: $("#Notes").val(),
                StoreTRXTypesId: $("#StoreTRXTypesList").val(),
                Items: itemsList
            }


            $("#submit").attr("disabled", true);
            $(".remove ").hide();

            //AddOrderAndSetails
            $.ajax({
                type: 'POST',
                url: '/StoreAddPermission/AddPermission',
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
            ItemCategoriesId: $('.ItemCategoriesList', this).val(),
            ItemId: $('.ItemListPopUp', this).val(),
            Price: $('.Price', this).val(),
            UnitId: $('.UnitList', this).val(),
            Amount: $('.Qty', this).val(),
            Total: $('.Total', this).text(),
            DisPer: $('.Disper', this).val(),
            DisValue: $('.DisValue', this).val(),
            NetPrice: $('.Net', this).text(),
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
    if (document.getElementById("StoreTRXTypesList").selectedIndex == 0) {
        toastr.warning('اختر نوع الإذن ...!')
        isValid = false;
    }
    //if (document.getElementById("PurchaseINVTypeList").selectedIndex == 0) {
    //    toastr.warning("ادخل نوع الفاتورة");
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
            AddPermissionNo: $("#SalesINVNo").val(),
            AddPermissionDate: $("#SalesINVDate").val(),
            VendorId: $("#CustomersList").val(),
            StoreId: $("#StoreList").val(),
            //SalesOrderNo: $("#SalesOrderNo").val(),
            //SalesOrderDate: $("#SalesOrderDate").val(),
            //SalesPaperNo: $("#SalesPaperNo").val(),
            //SalesPaperDate: $("#SalesPaperDate").val(),
            EmployeeId: $("#EmployeeList").val(),
            //PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
            //DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
            //SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
            //Itemtax: $("#Itemtax").val(),
            RowsCount: $("#RowsCount").val(),
            TotaleItemDis: $("#TotaleItemDis").val(),
            SalesINVTotal: $("#TotalBeforeDis").text(),
            InvoiceDisPer: $("#TotalDisper").val(),
            InvoiceDisValue: $("#TotalDis").val(),
            NetValue: $("#TotalNet").text(),
            PaidValue: $("#Payed").val(),
            RemainingValue: $("#Residual").text(),
            Notes: $("#Notes").val(),
            StoreTRXTypesId: $("#StoreTRXTypesList").val(),
            Items: itemsList
        }


        $("#update").attr("disabled", true);
        $(".remove ").hide();

        //AddOrderAndSetails
        $.ajax({
            type: 'POST',
            url: '/StoreAddPermission/updatePermission',
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



