//const { Console } = require("node:console");

$(function () {
    $("#add").click(function () {
        var isValid = true;
        if ($("#StoreId").val() == null || $("#StoreId").val() == 0) {
            toastr.warning('اختر المخزن ...!');
            return;
        }
       
       
        $('#OrdersItems .ItemsList').each(function () {

            //var OldItem = $(this).val();
            //var NewItem = $("#ItemListPopUp").val();
            //if (NewItem == OldItem) {
            //    toastr.warning('الصنف موجود بالفعل في الفاتورة')
            //    isValid = false;
            //}

            if (document.getElementById("ItemsList").selectedIndex == 0) {
                toastr.warning('اختر الصنف ...!')
                isValid = false;
            }
           
        });

        //if ($("#Price").val().trim() == '' || $("#Price").val() == 0 || document.getElementById("ItemListPopUp").selectedIndex == 0) {
        //    toastr.warning('ادخل الصنف والسعر ...!')
        //    isValid = false;
        //}
        //if ($("#Qty").val().trim() == '' || 0) {
        //    toastr.warning('ادخل الكمية ...!')
        //    isValid = false;
        //}

        if (isValid) {
            var productID = document.getElementById("ItemsList").value;

            var $newRow = $("#MainRow").clone().removeAttr('id');

            $('.ItemsList', $newRow).val(productID);

            $('#add', $newRow).addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').addClass('btn-danger');
            $('#itemGroupId,#ItemsList,#ItemNo,#UnitList,#Amount', $newRow).attr('disabled', true).css("background-color", "#dfdce0");
            $(".select2-selection ,.select2-selection--single", $newRow).css("background-color", "#dfdce0");
            
            $('#itemGroupId,#ItemsList,#ItemNo,#UnitList,#Amount', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $("#OrdersItems").append($newRow[0]).remove("#ItemsList");
            $("#OrdersItems #GroupHide").show();
           /* $("#OrdersItems #ItemCode").show();*/

            //$(function () {
            //    $('[id*=btnEditForAddorg]').on("click", function () {
            //        var grid = document.getElementById("tblcoursesubject");
            //        var rows = grid.getElementsByTagName("TR");
            //        var amount = 0;
            //        for (var i = 1; i < rows.length; i++) {
            //            var cells = rows[i].getElementsByTagName("TD");
            //            amount += parseFloat(cells[2].innerHTML);
            //        }
            //        $('[id*=txtSum]').val(amount);
            //    });
            //});

           
            //var grid = document.getElementById("OrdersItems");
            //var rows = grid.getElementsByTagName("TR");
            //        var amount = 0;
            //        for (var i = 1; i < rows.length; i++) {
            //            var cells = rows[i].getElementsByTagName("TD");
                        
            //            amount += parseFloat(cells[2].innerHTML);
            //        }
            //$('#Deipt').val(amount);

            //var grid = document.getElementById("OrdersItems");
            //var rows = grid.getElementsByTagName("TR");
            //var amount = 0;
            //for (var i = 1; i < rows.length; i++) {
            //    var cells = rows[i].getElementsByTagName("TD");

            //    amount += parseFloat(cells[3].innerHTML);
            //}
            //$('#Credit').val(amount);


            //var rowCount = $('#OrdersItems tr').length;
            //$('#RowsCount').val(rowCount-1);
            
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

            //$.get("/StoreAddPermission/GetItemList", { ID: 0 }, function (data) {
            //    $("#ItemListPopUp").empty();
            //    $("#ItemListPopUp").append("<option> اختر الصنف  </option>")
            //    $.each(data, function (index, row) {

            //        $("#ItemListPopUp").append("<option value='" + row.Id + "'>" + row.ItemNameAr + "</option>")
            //    });
            //});

            //$.get("/StoreAddPermission/GetItemGroupList", function (data) {
            //    $("#ItemCategoriesList").empty();
            //    $("#ItemCategoriesList").append("<option> اختر مجموعة الصنف  </option>")
            //    $.each(data, function (index, row) {

            //        $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
            //    });
            //});

            //$.get("/StoreAddPermission/GetUintList", { ID: 0 }, function (data) {
            //    $("#UnitList").empty();
            //    $("#UnitList").append("<option> اختر الوحدة  </option>")
            //    $.each(data, function (index, row) {

            //        $("#UnitList").append("<option value='" + row.Id + "'>" + row.UnitName + "</option>")
            //    });
            //});

            //$("#Price").val(0);
            //$("#Qty").val(1);
            ////$("#Total").text('');
            //$("#Disper").val(0);
            //$("#DisValue").val(0);
            //$("#Net").text('');

            //var Total = $("#Debitt").val();
            //var $numoItem = $("#TbItem tr:gt(0)");
            //$numoItem.each(function (index) {
            //    var $tblrow = $(this);
            //    if (!isNaN(Total)) {
            //        var TotalQuat = 0;

            //        $(".Debitt").each(function () {
            //            var sval = parseInt($(this).val());
            //            if ($("#Deipt").val() == 0) {
            //                TotalQuat = isNaN(sval) ? 0 : sval;
            //            }
            //            else {
            //                TotalQuat += (isNaN(sval) ? 0 : sval);
            //            }
            //        });

            //       /* $(".TotalDis").text(TotalQuat);*/
            //        $("#Deipt").val(TotalQuat);

            //    }


            //});
            $("#Amount").val("0");
         
            $("#ItemNo").val("");
         
         //   $("#Notess").val("");
            var itemGroupId = $('select[name="itemGroupId"]');
            var ItemsList = $('select[name="ItemsList"]');
           // itemGroupId.find('option:eq(0)').prop('selected', true);
            //ItemsList.find('option:eq(0)').prop('selected', true);
            //$("#itemGroupId").selectmenu();
           // $("#itemGroupId").first();
           // $("#ItemsList").selectmenu();
            //$("#ItemsList").first();
           
            $('#itemGroupId').val(null).trigger('change.select2');
            $('#ItemsList').val(0).trigger('change.select2');
            $('#UnitList').val(0).trigger('change.select2');
           
        }

    });


    $("#submit").click(function () {

        var isValid = true;
        var itemsList = [];
        $("#OrdersItems tbody tr:not(:nth-child(1))").each(function () {

            var item = {
                
                ItemId: $('.ItemsList', this).val(),
                itemGroupId: $('.itemGroupId', this).val(),
                ItemNo: $('.ItemNo', this).val(),
                Amount: $('.Amount', this).val(),
                UnitId: $('.UnitList', this).val()
                //DisPer: $('.Disper', this).val(),
                //DisValue: $('.DisValue', this).val(),
                //NetPrice: $('.Net', this).text(),
                //ItemBalance: $('#ItemBalance', this).val(),
                //StoreId: $('.StoreList', this).val()
            }
            itemsList.push(item);
        });


        if (itemsList.length == 0) {

            toastr.warning('اختر الصنف ...!')
            isValid = false;

        }
        //if (document.getElementById("JournalType").selectedIndex == 0) {
        //    toastr.warning('اختر نوع القيد ...!')
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
        //if (document.getElementById("StoreTRXTypesList").selectedIndex == 0) {
        //    toastr.warning('اختر نوع الإذن ...!')
        //    isValid = false;
        //}
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
                StoreOpeningBalanceNo: $("#StoreOpeningBalanceNo").val(),
                StoreOpeningBalanceDate: $("#SalesINVDate").val(),
            
                //Credit: $("#Credit").val(),
                //Debit: $("#Deipt").val(),
                //SalesOrderDate: $("#SalesOrderDate").val(),
                //SalesPaperNo: $("#SalesPaperNo").val(),
                //SalesPaperDate: $("#SalesPaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                //PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
                //DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
                //SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
                //Itemtax: $("#Itemtax").val(),
                StoreId: $("#StoreId").val(),
                //JournalTypeId: $("#JournalType").val(),
                //JournalTabId: $("#JournalTab").val(),
                //InvoiceDisPer: $("#TotalDisper").val(),
                //InvoiceDisValue: $("#TotalDis").val(),
                //NetValue: $("#TotalNet").text(),
                //PaidValue: $("#Payed").val(),
                //RemainingValue: $("#Residual").text(),
                Notes: $("#Notes").val(),
               /* StoreTRXTypesId: $("#StoreTRXTypesList").val(),*/
                Items: itemsList
            }


            $("#submit").attr("disabled", true);
            $(".remove ").hide();

            //AddOrderAndSetails
            $.ajax({
                type: 'POST',
                url: '/StoreOpeningBalance/AddStoreOpeningBalance',
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


    $("#update").click(function () {


        var isValid = true;
        var itemsList = [];
        $("#OrdersItems tbody tr:not(:nth-child(1))").each(function () {

            var item = {

                ItemId: $('.ItemsList', this).val(),
                itemGroupId: $('.itemGroupId', this).val(),
                ItemNo: $('.ItemNo', this).val(),
                Amount: $('.Amount', this).val(),
                UnitId: $('.UnitList', this).val()
                //DisPer: $('.Disper', this).val(),
                //DisValue: $('.DisValue', this).val(),
                //NetPrice: $('.Net', this).text(),
                //ItemBalance: $('#ItemBalance', this).val(),
                //StoreId: $('.StoreList', this).val()
            }
            itemsList.push(item);
        });


        if (itemsList.length == 0) {

            toastr.warning('اختر الصنف ...!')
            isValid = false;

        }
        //if (document.getElementById("JournalType").selectedIndex == 0) {
        //    toastr.warning('اختر نوع القيد ...!')
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
        //if (document.getElementById("StoreTRXTypesList").selectedIndex == 0) {
        //    toastr.warning('اختر نوع الإذن ...!')
        //    isValid = false;
        //}
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
                StoreOpeningBalanceNo: $("#StoreOpeningBalanceNo").val(),
                StoreOpeningBalanceDate: $("#SalesINVDate").val(),

                //Credit: $("#Credit").val(),
                //Debit: $("#Deipt").val(),
                //SalesOrderDate: $("#SalesOrderDate").val(),
                //SalesPaperNo: $("#SalesPaperNo").val(),
                //SalesPaperDate: $("#SalesPaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                //PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
                //DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
                //SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
                //Itemtax: $("#Itemtax").val(),
                StoreId: $("#StoreId").val(),
                //JournalTypeId: $("#JournalType").val(),
                //JournalTabId: $("#JournalTab").val(),
                //InvoiceDisPer: $("#TotalDisper").val(),
                //InvoiceDisValue: $("#TotalDis").val(),
                //NetValue: $("#TotalNet").text(),
                //PaidValue: $("#Payed").val(),
                //RemainingValue: $("#Residual").text(),
                Notes: $("#Notes").val(),
                /* StoreTRXTypesId: $("#StoreTRXTypesList").val(),*/
                Items: itemsList
            }


            $("#update").attr("disabled", true);
            $(".remove ").hide();

            //AddOrderAndSetails
            $.ajax({
                type: 'POST',
                url: '/StoreOpeningBalance/updateStoreOpeningBalance',
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







