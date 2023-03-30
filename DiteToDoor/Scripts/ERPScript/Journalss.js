//const { Console } = require("node:console");

$(function () {
    var i = 1;
    var j = 1;
    $("#addRowJournals").click(function () {
        var isValid = true;
        $('#OrdersItems .Accounts').each(function () {

            //var OldItem = $(this).val();
            //var NewItem = $("#ItemListPopUp").val();
            //if (NewItem == OldItem) {
            //    toastr.warning('الصنف موجود بالفعل في الفاتورة')
            //    isValid = false;
            //}

            //if (document.getElementById("Accounts").selectedIndex == 0) {
            //    toastr.warning('اختر الحساب ...!')
            //    isValid = false;
            //}
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
            var productID = document.getElementById("Accounts").value;
            var $newRow = $("#MainRow").clone().attr('id', "Row" + i);
            i++;

            $('.Accounts', $newRow).val(productID);

            $('#addd', $newRow).removeAttr('hidden').addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').removeAttr('hidden').addClass('btn-outline-danger');
            $('#Accounts,#AccountNo,#Debitt,#Creditt,#CostCenterId ,#Notess', $newRow).attr('disabled', false);
            $('#Accounts,#AccountNo,#Debitt,#Creditt,#CostCenterId ,#Notess', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $(".select2-selection ,.select2-selection--single").attr('disabled', false);

            $("#OrdersItems").append($newRow[0]).remove("#Accounts");
            $("#OrdersItems #GroupHide").show();


            $('#OrdersItems tr:last')
                .css("background-color", "white");
            //$(".select2-selection").attr('disabled', false);

            var $tr = $(this).closest('tr');
            var $lastTr = $('#OrdersItems tr:last');

            $lastTr.find('.select2-select').select2('destroy'); // Un-instrument original row

            //var $clone = $lastTr.clone(); // Clone row

            //$clone.find('td').each(function () { // Alter cloned ids
            //    // ...
            //});

            /*$tr.closest('tbody').append($clone); // Append clone*/

            $lastTr.find('.Accounts').select2(); // Re-instrument original row
            $lastTr.find('.CostCenterId').select2(); // Re-instrument original row
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");

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
            $("#Debitt").val("0.00");
            $("#Creditt").val("0.00");
            $("#AccountNo").val("");
         
            $("#Notess").val("");
         
           
           
            $('#Accounts').val(null).trigger('change.select2');
            $('#CostCenterId').val(null).trigger('change.select2');
           
        }

    });

    $("#addEdit").click(function () {
        var isValid = true;
        $('#OrdersItems .Accounts').each(function () {

            //var OldItem = $(this).val();
            //var NewItem = $("#ItemListPopUp").val();
            //if (NewItem == OldItem) {
            //    toastr.warning('الصنف موجود بالفعل في الفاتورة')
            //    isValid = false;
            //}

            //if (document.getElementById("Accounts").selectedIndex == 0) {
            //    toastr.warning('اختر الحساب ...!')
            //    isValid = false;
            //}
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
            var productID = document.getElementById("Accounts").value;
            var $newRow = $("#MainRow").clone().attr('id', "Row" + j);
            j++;

            $('.Accounts', $newRow).val(productID);

            $('#addd', $newRow).removeAttr('hidden').addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').removeAttr('hidden').addClass('btn-outline-danger');
            $('#Accounts,#AccountNo,#Debitt,#Creditt,#CostCenterId ,#Notess', $newRow).attr('disabled', false);
            $('#Accounts,#AccountNo,#Debitt,#Creditt,#CostCenterId ,#Notess', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $(".select2-selection ,.select2-selection--single").attr('disabled', false);

            $("#OrdersItems").append($newRow[0]).remove("#Accounts");
            $("#OrdersItems #GroupHide").show();


            $('#OrdersItems tr:last')
                .css("background-color", "white");
            //$(".select2-selection").attr('disabled', false);

            var $tr = $(this).closest('tr');
            var $lastTr = $('#OrdersItems tr:last');

            $lastTr.find('.select2-select').select2('destroy'); // Un-instrument original row

            //var $clone = $lastTr.clone(); // Clone row

            //$clone.find('td').each(function () { // Alter cloned ids
            //    // ...
            //});

            /*$tr.closest('tbody').append($clone); // Append clone*/

            $lastTr.find('.Accounts').select2(); // Re-instrument original row
            $lastTr.find('.CostCenterId').select2(); // Re-instrument original row
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");

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
            $("#Debitt").val("0.00");
            $("#Creditt").val("0.00");
            $("#AccountNo").val("");

            $("#Notess").val("");



            $('#Accounts').val(null).trigger('change.select2');
            $('#CostCenterId').val(null).trigger('change.select2');

        }

    });
    $("#submit").click(function () {
      
        var isValid = true;
        var itemsList = [];
        if ($("#diff").val() != 0) {
            toastr.warning('القيد  غير متوازن ...!')
            isValid = false;
        }
        $("#OrdersItems tbody tr").each(function () {

            var item = {
                
                AccountId: $('.Accounts', this).val(),
                /*JournalId: 1,*/
                DebitD: $('.Debitt', this).val(),
                CreditD: $('.Creditt', this).val(),
                AccountNo: $('.AccountNo', this).val(),
                CostCenterId: $('.CostCenterId', this).val(),
                Notess: $('.Notess', this).val(),
                //DisPer: $('.Disper', this).val(),
                //DisValue: $('.DisValue', this).val(),
                //NetPrice: $('.Net', this).text(),
                //ItemBalance: $('#ItemBalance', this).val(),
                //StoreId: $('.StoreList', this).val()
            }
            itemsList.push(item);
        });


        if (itemsList.length == 0) {

            toastr.warning('اختر الحساب ...!')
            isValid = false;

        }
        if (document.getElementById("JournalType").selectedIndex == 0) {
            toastr.warning('اختر نوع القيد ...!')
            isValid = false;
        }
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
                JournalNo: $("#JournalNo").val(),
                JournalDate: $("#SalesINVDate").val(),
                DocNo: $("#DocNo").val(),
                DocDate: $("#DocDate").val(),
                Credit: $("#Credit").val(),
                Debit: $("#Deipt").val(),
                //SalesOrderDate: $("#SalesOrderDate").val(),
                //SalesPaperNo: $("#SalesPaperNo").val(),
                //SalesPaperDate: $("#SalesPaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                //PurchaseINVTypeId: $("#PurchaseINVTypeList").val(),
                //DiscountCategoriesId: $("#DiscountCategoriesIdList").val(),
                //SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
                //Itemtax: $("#Itemtax").val(),
                RowsCount: $("#RowsCount").val(),
                JournalTypeId: $("#JournalType").val(),
                JournalTabId: $("#JournalTab").val(),
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
                url: '/Journals/AddPermission',
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
        if ($("#diff").val() != 0) {
            toastr.warning('القيد  غير متوازن ...!')
            isValid = false;
        }
        $("#OrdersItems tbody tr").each(function () {

            var item = {

                AccountId: $('.Accounts', this).val(),
                /*JournalId: 1,*/
                DebitD: $('.Debitt', this).val(),
                CreditD: $('.Creditt', this).val(),
                AccountNo: $('.AccountNo', this).val(),
                CostCenterId: $('.CostCenter', this).val(),
                Notess: $('.Notess', this).val(),
                //Total: $('.Total', this).text(),
                //DisPer: $('.Disper', this).val(),
                //DisValue: $('.DisValue', this).val(),
                //NetPrice: $('.Net', this).text(),
                //ItemBalance: $('#ItemBalance', this).val(),
                //StoreId: $('.StoreList', this).val()
            }
            itemsList.push(item);
        });


        //if (itemsList.length == 0) {

        //    toastr.warning('اختر الحساب ...!')
        //    isValid = false;

        //}
        if (document.getElementById("JournalType").selectedIndex == 0) {
            toastr.warning('اختر نوع القيد ...!')
            isValid = false;
        }
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
                JournalId: $("#JournalId").val(),
                JournalNo: $("#JournalNo").val(),
                JournalDate: $("#SalesINVDate").val(),
                DocNo: $("#DocNo").val(),
                DocDate: $("#DocDate").val(),
                Credit: $("#Credit").val(),
                Debit: $("#Deipt").val(),
                //SalesOrderDate: $("#SalesOrderDate").val(),
                //SalesPaperNo: $("#SalesPaperNo").val(),
                //SalesPaperDate: $("#SalesPaperDate").val(),
                EmployeeId: $("#EmployeeList").val(),
                //BranchesId: $("#BranchList").val(),
                //CompanyId: 0,
                //SalesRepresentativeId: $("#SalesRepresentativeIdList").val(),
                //Itemtax: $("#Itemtax").val(),
                RowsCount: $("#RowsCount").val(),
                JournalTypeId: $("#JournalType").val(),
                JournalTabId: $("#JournalTab").val(),
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
                url: '/Journals/updateJournals',
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
});








