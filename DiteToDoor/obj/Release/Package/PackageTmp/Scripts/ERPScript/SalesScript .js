//const { Console } = require("node:console");

$(function () {
    var i = 1;
    var j = 1;
    $("#addRowSales").click(function () {

       
        //i++;
        //if (i == 1) {
        //    $("#ItemCheck").empty();
        //}
        var isValid = true;
        if ($("#StoreList").val() == null || $("#StoreList").val() == 0) {
            toastr.warning('اختر المخزن ...!');
            isValid = false;

            return;
        }
        //$('#OrdersItems tbody tr:not(:nth-child(1)) .ItemListPopUp').each(function () {

        //    var OldItem = $(this).val();
        //    var NewItem = $("#ItemListPopUp").val();
        //    if (NewItem == OldItem) {
        //        toastr.warning('الصنف موجود بالفعل في الفاتورة')
        //        isValid = false;
        //    }

        //    if (document.getElementById("ItemListPopUp").selectedIndex == 0) {
        //        toastr.warning('اختر الصنف ...!')
        //        isValid = false;
        //    }
        //});

        //if ($("#Price").val().trim() == '' || $("#Price").val() == 0 || document.getElementById("ItemListPopUp").selectedIndex == 0)  {
        //    toastr.warning('ادخل الصنف والسعر ...!')
        //    isValid = true;
        //}
        //if ($("#Qty").val().trim() == '' || 0) {
        //    toastr.warning('ادخل الكمية ...!')
        //    isValid = true;
        //}
        
        if (isValid) {
            var productID = document.getElementById("ItemListPopUp").value;
            
            var $newRow = $("#MainRow").clone().attr('id',"Row"+i);
            i++;
           
            $('.ItemListPopUp', $newRow).val(productID);

            $('#addd', $newRow).addClass('remove').removeClass('newbtn waves-effect btn-add disabled');
            $('#ItemCode,#UnitList,StoreList,#ItemListPopUp,#Qty,#Price,#Total,#Disper,#DisValue,#Net,#ItemBalance', $newRow).attr('disabled', false);

            $('#ItemCode,#UnitList,StoreList,#ItemListPopUp,#Qty,#Price,#Total,#Disper,#DisValue,#Net,#ItemBalance', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $(".select2-selection ,.select2-selection--single").attr('disabled', false);
           
            $("#OrdersItems").append($newRow[0])/*.remove("#ItemCategoriesList")*/;
            /*$("#OrdersItems #GroupHide").hide();*/
            $("#OrdersItems #ItemCode").show();
            
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

            $lastTr.find('.ItemListPopUp').select2(); // Re-instrument original row
            $lastTr.find('.UnitList').select2(); // Re-instrument original row
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");
            //$(".selection").last().hide();
            //$clone.find('.ItemListPopUp').select2(); // Instrument clone
            //document.getElementById("ItemCategoriesList").selectedIndex = 0;
            //document.getElementById("UnitList").selectedIndex = 0;
            //document.getElementById("StoreList").selectedIndex = 0;
            //document.getElementById("ItemListPopUp").selectedIndex = 0;
            //$.get("/SalesINV/GetItemGroupList", function (data) {
            //    $("#ItemCategoriesList").empty();
            //    $("#ItemCategoriesList").append("<option> اختر مجموعة الصنف  </option>")
            //    $.each(data, function (index, row) {

            //        $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
            //    });
            //});
          
            $.get("/SalesINV/GetItemList", { ID: 0 }, function (data) {
                $("#ItemListPopUp").empty();
                $("#ItemListPopUp").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemListPopUp").append("<option value='" + row.Id + "'>" + row.ItemNameAr + "</option>")
                });
            });

          

            $.get("/SalesINV/GetUintList", { ID: 0 }, function (data) {
                $("#UnitList").empty();
                $("#UnitList").append("<option> اختر الوحدة  </option>")
                $.each(data, function (index, row) {

                    $("#UnitList").append("<option value='" + row.Id + "'>" + row.UnitName + "</option>")
                });
            });

            $("#Price").val(0);
            $("#Qty").val(1);
            $("#Total").text('');
            $("#Disper").val(0);
            $("#DisValue").val(0);
            $("#Net").text('');
            $("#ItemNumber").val(0);
            $("#ItemBalance").val(0);

        }
       
    });
    $("#addEdit").click(function () {


        //i++;
        //if (i == 1) {
        //    $("#ItemCheck").empty();
        //}
        var isValid = true;
        if ($("#StoreList").val() == null || $("#StoreList").val() == 0) {
            toastr.warning('اختر المخزن ...!');
            return;
        }
        //$('#OrdersItems tbody tr:not(:nth-child(1)) .ItemListPopUp').each(function () {

        //    var OldItem = $(this).val();
        //    var NewItem = $("#ItemListPopUp").val();
        //    if (NewItem == OldItem) {
        //        toastr.warning('الصنف موجود بالفعل في الفاتورة')
        //        isValid = false;
        //    }

        //    if (document.getElementById("ItemListPopUp").selectedIndex == 0) {
        //        toastr.warning('اختر الصنف ...!')
        //        isValid = false;
        //    }
        //});

        //if ($("#Price").val().trim() == '' || $("#Price").val() == 0 || document.getElementById("ItemListPopUp").selectedIndex == 0) {
        //    toastr.warning('ادخل الصنف والسعر ...!')
        //    isValid = false;
        //}
        //if ($("#Qty").val().trim() == '' || 0) {
        //    toastr.warning('ادخل الكمية ...!')
        //    isValid = false;
        //}

        if (isValid) {
            var productID = document.getElementById("ItemListPopUp").value;

            var $newRow = $("#MainRow").clone().attr('id', "Row" + j);
            j++;

            $('.ItemListPopUp', $newRow).val(productID);

            $('#addEdit', $newRow).addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').addClass('btn-outline-danger');
            $('#ItemCode,#UnitList,StoreList,#ItemListPopUp,#Qty,#Price,#Total,#Disper,#DisValue,#Net,#ItemBalancee', $newRow).attr('disabled', false);
            $('#ItemCode,#UnitList,StoreList,#ItemListPopUp,#Qty,#Price,#Total,#Disper,#DisValue,#Net,#ItemBalancee', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            $(".select2-selection ,.select2-selection--single", $newRow).attr('disabled', false);;
            $("#OrdersItems").append($newRow[0]).remove("#ItemCategoriesList");
            $("#OrdersItems #GroupHide").hide();
            $("#OrdersItems #ItemCode").show();
            
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

            $lastTr.find('.ItemListPopUp').select2(); // Re-instrument original row
            $lastTr.find('.UnitList').select2(); // Re-instrument original row
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(2).hide();
            $lastTr.find('.selection').eq(2).css("display", "none");

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");
            //document.getElementById("ItemCategoriesList").selectedIndex = 0;
            //document.getElementById("UnitList").selectedIndex = 0;
            //document.getElementById("StoreList").selectedIndex = 0;
            //document.getElementById("ItemListPopUp").selectedIndex = 0;
            $.get("/SalesINV/GetItemGroupList", function (data) {
                $("#ItemCategoriesList").empty();
                $("#ItemCategoriesList").append("<option> اختر مجموعة الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
                });
            });

            $.get("/SalesINV/GetItemList", { ID: 0 }, function (data) {
                $("#ItemListPopUp").empty();
                $("#ItemListPopUp").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemListPopUp").append("<option value='" + row.Id + "'>" + row.ItemNameAr + "</option>")
                });
            });



            $.get("/SalesINV/GetUintList", { ID: 0 }, function (data) {
                $("#UnitList").empty();
                $("#UnitList").append("<option> اختر الوحدة  </option>")
                $.each(data, function (index, row) {

                    $("#UnitList").append("<option value='" + row.Id + "'>" + row.UnitName + "</option>")
                });
            });

            $("#Price").val(0);
            $("#Qty").val(1);
            $("#Total").text('');
            $("#Disper").val(0);
            $("#DisValue").val(0);
            $("#ItemBalancee").val(0);
            $("#Net").text('');

        }

    });

    function myFunction() {

        var file = document.getElementById('filePath').files[0];
        var reader = new FileReader();
        // it's onload event and you forgot (parameters)
        reader.onload = function (e) {
            var image = document.getElementById("filePathHidden");
            // the result image data
            image.src = e.target.result;

        }
       
        // you have to declare the file loading
        reader.readAsDataURL(file);
    }
    $("#filePath").change(function () {
        myFunction();
    });
    $("#submit").click(function () {
       
            //var conditions = document.getElementById("editorConditionSales").innerHTML;
            //var notes = document.getElementById("editorNotesSales").innerHTML;

            //$("#ConditionsSales").val(conditions);
            //$("#NotesSales").val(notes);


        //$(function () {
        //    $("#filePath").fileUpload({
        //        'uploader': '../Uploadify/uploader.swf',
        //        'cancelImg': '../Uploadify/cancel.png',
        //        'buttonText': 'Browse Files',
        //        'script': '/SalesINV/Upload/',
        //        'folder': 'Attachments',
        //        'fileDesc': 'Image Files',
        //        'fileExt': '*.jpg;*.jpeg;*.gif;*.png,*.pdf',
        //        'multi': true,
        //        'auto': true
        //    });
        //});
       
        var isValid = true;
        var itemsList = [];
        //var filee = document.getElementById("filePathHidden");
        //var srcc = filee.src;
        //$("#filePathVal").val(srcc);
        //alert(srcc);

        //var fileName = $("#fileName").val();
        //var filePath = $("#filePathVal").val();
        //var attach = {
        //    AttachmentName: fileName,
        //    AttachmentPath: filePath
        //}
        
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
            $("#cusMsg").show();
            isValid = false;
        }
        if (document.getElementById("StoreList").selectedIndex == 0) {
           
            $("#stMsg").show();

            isValid = false;
        } 
        if (document.getElementById("BranchList").selectedIndex == 0) {
            isValid = false;
        } 
        if (document.getElementById("EmployeeList").selectedIndex == 0) {
            $("#empMsg").show();
            isValid = false;
        } 
        if (document.getElementById("PurchaseINVTypeList").selectedIndex == 0) {
           
            $("#typeMsg").show();

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
        if (isValid == false) {
            toastr.error('لم يتم الحفظ ...!')
        }
        if (isValid) {
            //$.ajax({

            //    type: "POST",
            //    url: '/SalesINV/Upload',     //your action
            //    data:  { FileData: filePath },   //your form name.it takes all the values of model
            //    dataType: 'json',
            //    success: function (result) {
            //        loadData();
            //        $('#exampleModalCenter').modal('hide');

            //    },

            //    error: function (XMLHttpRequest, textStatus, errorThrown) {
            //        alert('oops, something bad happened')
            //        //toastr.warning('اختر  ...!')
            //    }

            //});
          

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
                SalesINVTotal: $("#TotalBeforeDis").text(),  
                InvoiceDisPer: $("#TotalDisper").val(), 
                InvoiceDisValue: $("#TotalDis").val(), 
                NetValue: $("#TotalNet").text(), 
                PaidValue: $("#Payed").val(), 
                RemainingValue: $("#Residual").text(), 
                Notes: $("#Notes").val(),
                NotesSetting: $("#myTextareaNotes").text(),
                Conditions: $("#myTextarea").text(),

                Items: itemsList,
                /*Attachmentss: attach*/

            }
          
            $("#submit").attr("disabled", true);
            $(".remove ").hide();
            //AddOrderAndSetails
            $.ajax({
                type: 'POST',
                url: '/SalesINV/AddSalesINV',
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
    if (document.getElementById("PurchaseINVTypeList").selectedIndex == 0) {
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
            SalesINVTotal: $("#TotalBeforeDis").text(),
            InvoiceDisPer: $("#TotalDisper").val(),
            InvoiceDisValue: $("#TotalDis").val(),
            NetValue: $("#TotalNet").text(),
            PaidValue: $("#Payed").val(),
            RemainingValue: $("#Residual").text(),
            Notes: $("#Notes").val(),
            Items: itemsList
        }


        $("#update").attr("disabled", true);
        $(".remove ").hide();

        //AddOrderAndSetails
        $.ajax({
            type: 'POST',
            url: '/SalesINV/UpdateSalesINV',
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









