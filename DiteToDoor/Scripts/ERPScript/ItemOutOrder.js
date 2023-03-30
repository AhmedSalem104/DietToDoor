
$(function () {
    var i = 1;
    var j = 1;
    $("#addItemOrderOut").click(function () {

        var isValid = true;
        if ($("#StoreList").val() == null || $("#StoreList").val() == 0) {
            toastr.warning('اختر المستودع ...!');
            isValid = false;

            return;
        }
       
   
        if (isValid) {
            var productID = document.getElementById("ItemList").value;
           
            var $newRow = $("#MainRow").clone().attr('id', "Row" + j);
            j++;
            $('.ItemListCLS', $newRow).val(productID);
         
            $('#addd', $newRow).removeAttr('hidden').addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').removeAttr('hidden').addClass('btn-outline-danger');
            $('#UnitList,#ItemList,#ItemType,#QtyIn,Qty,#Price,#Total, #NotesD', $newRow).attr('disabled', false);
            $('#UnitList,#ItemList,#ItemType,#QtyIn,#Qty,#Price,#Total, #NotesD', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
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

            $lastTr.find('.ItemListCLS').select2(); // Re-instrument original row
            $lastTr.find('.UnitList').select2();
            $lastTr.find('.ItemType').select2();
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();
            $lastTr.find('.selection').eq(2).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");
            $lastTr.find('.select2').eq(4).css("display", "none");
            


            //document.getElementById("ItemCategoriesList").selectedIndex = 0;
            //document.getElementById("UnitList").selectedIndex = 0;
         
            //document.getElementById("ItemList").selectedIndex = 0;
            $.get("/ItemOutOrder/GetItemList", { ID: 0 }, function (data) {
                $("#ItemList").empty();
                $("#ItemList").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemList").append("<option value='" + row.Id + "'>" + row.ItemNameAr + "</option>")
                });
            });

            $.get("/ItemOutOrder/GetItemGroupList", function (data) {
                $("#ItemCategoriesList").empty();
                $("#ItemCategoriesList").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
                });
            });

            $.get("/ItemOutOrder/GetUintList", { ID: 0 }, function (data) {
                $("#UnitList").empty();
                $("#UnitList").append("<option> اختر الوحدة  </option>")
                $.each(data, function (index, row) {

                    $("#UnitList").append("<option value='" + row.Id + "'>" + row.UnitName + "</option>")
                });
            });


           
            $("#TbItem #MainRow #Price").val(0);
            $("#TbItem #MainRow #Qty").val(1);
            $("#TbItem #MainRow #Total").text('');
            $("#TbItem #MainRow #Disper").val(0);
            $("#TbItem #MainRow #DisValue").val(0);
            $("#TbItem #MainRow #Net").text('');
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

        var isValid = true;
        if ($("#StoreList").val() == null || $("#StoreList").val() == 0) {
            toastr.warning('اختر المستودع ...!');
            isValid = false;

            return;
        }
        //$('#OrdersItems .ItemListCLS').each(function () {

        //    var OldItem = $(this).val();
        //    var NewItem = $("#ItemList").val();
        //    if (NewItem == OldItem) {
        //        toastr.warning('الصنف موجود بالفعل في الفاتورة')
        //        isValid = false;
        //    }
        //});

        //if ($("#ItemList").val() == ""||0) {
        //    toastr.warning('اختر الصنف ...!')
        //     isValid = false;
        //}
        //if ($("#Price").val().trim() == '' || $("#Price").val() == 0 || document.getElementById("ItemList").selectedIndex == 0) {
        //    toastr.warning('ادخل الصنف والسعر ...!')
        //    isValid = false;
        //}
        //if ($(".Qty").val().trim() == '' || 0) {
        //    toastr.warning('ادخل الكمية ...!')
        //    isValid = false;
        //}

        if (isValid) {
            var productID = document.getElementById("ItemList").value;

            var $newRow = $("#MainRow").clone().attr('id', "Row" + i);
            i++;
            $('.ItemListCLS', $newRow).val(productID);

            $('#add', $newRow).addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').removeAttr('hidden').addClass('btn-outline-danger');
            $('#UnitList,#ItemList,#ItemType,#Qty,#QtyIn,#Price,#Total, #NotesD', $newRow).attr('disabled', false);
            $('#UnitList,#ItemList,#ItemType,#QtyIn,#Qty,#Price,#Total,#NotesD', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
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

            $lastTr.find('.ItemListCLS').select2(); // Re-instrument original row
            $lastTr.find('.UnitList').select2();
            $lastTr.find('.ItemType').select2();
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();
            $lastTr.find('.selection').eq(2).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");
            $lastTr.find('.select2').eq(4).css("display", "none");


            //document.getElementById("ItemCategoriesList").selectedIndex = 0;
            //document.getElementById("UnitList").selectedIndex = 0;

            //document.getElementById("ItemList").selectedIndex = 0;
            $.get("/ItemOutOrder/GetItemList", { ID: 0 }, function (data) {
                $("#ItemList").empty();
                $("#ItemList").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemList").append("<option value='" + row.Id + "'>" + row.ItemNameAr + "</option>")
                });
            });

            $.get("/ItemOutOrder/GetItemGroupList", function (data) {
                $("#ItemCategoriesList").empty();
                $("#ItemCategoriesList").append("<option> اختر الصنف  </option>")
                $.each(data, function (index, row) {

                    $("#ItemCategoriesList").append("<option value='" + row.Id + "'>" + row.ItemgroupsName + "</option>")
                });
            });

            $.get("/ItemOutOrder/GetUintList", { ID: 0 }, function (data) {
                $("#UnitList").empty();
                $("#UnitList").append("<option> اختر الوحدة  </option>")
                $.each(data, function (index, row) {

                    $("#UnitList").append("<option value='" + row.Id + "'>" + row.UnitName + "</option>")
                });
            });
            //$.get("/ItemOutOrder/GetItemType", { ID: 0 }, function (data) {
            //    $("#ItemType").empty();
            //    $("#ItemType").append("<option> اختر نوع النصف  </option>")
            //    $.each(data, function (index, row) {

            //        $("#ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            //    });
            //});
            $("#ItemType").val($("#ItemType option:first").val());
            

            $("#TbItem #MainRow #Price").val(0);
            $("#TbItem #MainRow #Qty").val(1);
            $("#TbItem #MainRow #Total").text('');
            $("#TbItem #MainRow #Disper").val(0);
            $("#TbItem #MainRow #DisValue").val(0);
            $("#TbItem #MainRow #Net").text('');
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
    $("#submit").click(function () {

        //var Expences1 = $("#DirectExpenses1").val();
        //var Expences2 = $("#DirectExpenses2").val();
        //var totalExpences = parseFloat(Expences1) + parseFloat(Expences2);
        //var net = $("#TotalNet").html()
        //var NetExpences = parseFloat(totalExpences) / parseFloat(net);
        
        $("#OrdersItems tbody tr").each(function () {
            
            var itemPrice = $(".Price").val();
            //itemCost = parseFloat(NetExpences) * parseFloat(itemPrice);
            //var a = $(".ItemCost").val();
            //if (a !=.0111) {
            //    $(".ItemCostt").val(parseFloat(NetExpences) * parseFloat(itemPrice));
            //}
           
        });
        var isValid = true;
        var itemsList = [];
        $("#OrdersItems tbody tr").each(function () {
          
            var item = {
                ItemCategoriesId: $('.ItemType', this).val(),
                ItemId: $('.ItemListCLS', this).val(), 
                Price: $('.Price', this).val(),
                UnitId: $('.UnitList', this).val(),
                AmountIn: $('.QtyIn', this).val(),
                AmountOut: $('.Qty', this).val(),

                Total: $('.Total', this).text(),
               /* ItemBalance: $('#ItemBalance', this).val(),*/
               /* StoreId: $('#StoreList').val(),*/
                Notes: $(".NotesD",this).val()
            }
            itemsList.push(item);
        });

        var Vendor = $('#VendorsList').val();
      
        var Store = $('.StoreList').val();
      
        var Employee = $('#EmployeeList').val();
        var PurchaseType = $('#ItemOutOrderTypeList').val();
        
        if (itemsList.length == 0 ) {

            toastr.warning('اختر الصنف ...!' )
            isValid = false;

        }

        //if (document.getElementById("VendorsList").selectedIndex == 0) {
        //    $("#cusMsg").show();
        //    isValid = false;
        //}
        if (document.getElementById("StoreList").selectedIndex == 0) {

            $("#stMsg").show();

            isValid = false;
        }
        if (document.getElementById("InternalDepartmentsId").selectedIndex == 0) {
            isValid = false;
        }
        if (document.getElementById("StoreManagerId").selectedIndex == 0) {
            $("#empMsg").show();
            isValid = false;
        }
        
        if (document.getElementById("DeliveryPersonId").selectedIndex == 0) {
            $("#empMsg").show();
            isValid = false;
        }
        //if (document.getElementById("ItemOutOrderTypeList").selectedIndex == 0) {

        //    $("#typeMsg").show();

        //    isValid = false;
        //}
       
        if (isValid == false) {
            toastr.error('لم يتم الحفظ ...!')
        }
        if (isValid) {
            var data = {
                TrxSerial: $("#TrxSerial").val(),
                Date: $("#PurchaseINVDate").val(),
                DemandInternalDepartmentsId: $("#DemandInternalDepartmentsId").val(),
                RecordNo: $("#RecordNo").val(),
                DeliveryPersonId: $("#DeliveryPersonId").val(),
                StoreId: $("#StoreList").val(),
                PagesCount: $("#PagesCount").val(),
                Attachments: $("#Attachments").val(),
                OwnerId: $("#OwnerId").val(),
                InternalDepartmentsId: $("#InternalDepartmentsId").val(),
                StoresKeepersId: $("#StoresKeepersId").val(),
                StoreManagerId: $("#StoreManagerId").val(),
                ItemOutOrderTotal: $("#TotalBeforeDis").text(),
                InvoiceDisPer: $("#TotalDisper").val(),
                ItemOutOrderDisValue: $("#TotalDis").val(),

                
                NetValue: $("#TotalNet").text(),
                Notes: $("#Notes").val(),
                //RecieveRecordDisValue: $("#TotalDis").val(),
                //NetValue: $("#TotalNet").text(), 
                //Tax: $("#Tax").val(),
                //RemainingValue: $("#Residual").text(), 
                Notes: $("#Notes").val(), 
                Items: itemsList
            }


            $("#submit").attr("disabled", true);
            $(".remove ").hide();

            //AddOrderAndDetails
            $.ajax({
                type: 'POST',
                url: '/ItemOutOrder/AddItemOutOrder',
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

    $("#TotalNet").click(function () {
        var net = $("#TotalNet").text();
        
        var TaxSett = $("#TaxSetting").val();
     
        if (TaxSett > 0) {
            var tax = net * TaxSett / 100;
            
            $("#Tax").val(tax);
            var tot = net + tax;
            alert (tot)
            $("#TotalNet").val(tot);
        }
    });


    //جلب نوع الصنف
    $(document).ready(function () {
        $("#ItemList").change(function () {
            $.get("/ItemOutOrder/GetItemType", { ID: $("#ItemList").val() }, function (data) {
                $("#ItemType").empty();
                //$("#UnitList").append("<option> ----------------  </option>")
                $.each(data, function (index, row) {

                    $("#ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
                });
            });
        })
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row1 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row1 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row1 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row2 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row2 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row2 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });

    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row3 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row3 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row3 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row4 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row4 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row4 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row5 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row5 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row5 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row6 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row6 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row6 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row7 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row7 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row7 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row8 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row8 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row8 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row9 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row9 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row9 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row10 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row10 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row10 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row11 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row11 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row11 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row12 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row12 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row12 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row13 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row13 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row13 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row14 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row14 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row14 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });
    /////////////////////////////////////
    $("#OrdersItems").on("change", "#Row15 .ItemListCLS", function () {
        //var currentRow = $(this).closest("tr");
        //var col = currentRow.find("td:eq(2)").find(".UnitList").val(); // get current row 1st TD value
        //alert(col)
        $.get("/ItemOutOrder/GetItemType", { ID: $(this).val() }, function (data) {
            $("#Row15 .UnitList").empty();

            //$("#UnitList").append("<option> ----------------  </option>")
            $.each(data, function (index, row) {

                $("#Row15 .ItemType").append("<option value='" + row.Id + "'>" + row.ItemCatName + "</option>")
            });
        });
    });



});








