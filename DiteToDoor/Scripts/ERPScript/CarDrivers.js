
$(function () {
    var i = 1;
    var j = 1;
    $("#addRowCarDrivers").click(function () {

        var isValid = true;
      
   
        if (isValid) {
            var productID = document.getElementById("DriverIdd").value;
           
            var $newRow = $("#MainRow").clone().attr('id', "Row" + j);
          
            j++;
            $('.DriverIdd', $newRow).val(productID);
         
            $('#addd', $newRow).removeAttr('hidden').addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').removeAttr('hidden').addClass('btn-outline-danger');
            $('#ItemNumber,#DriverIdd', $newRow).attr('disabled', false);
            $('#ItemNumber,#DriverIdd', $newRow).removeAttr('id');
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

            $lastTr.find('.DriverIdd').select2(); // Re-instrument original row
            //$lastTr.find('.UnitList').select2(); // Re-instrument original row
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");
            

           
            //$("#TbItem #MainRow #Price").val(0);
            //$("#TbItem #MainRow #Qty").val(1);
            //$("#TbItem #MainRow #Total").text('');
            //$("#TbItem #MainRow #Disper").val(0);
            //$("#TbItem #MainRow #DisValue").val(0);
            //$("#TbItem #MainRow #Net").text('');
            //$("#Price").val(0);
            //$("#Qty").val(1);
            //$("#Total").text('');
            //$("#Disper").val(0);
            //$("#DisValue").val(0);
            //$("#Net").text('');
            $("#ItemNumber").val(0);
           /* $("#ItemBalance").val(0);*/

        }


    });

    $("#addRowCarDriverss").click(function () {

        var isValid = true;
        
      

        if (isValid) {
            var productID = document.getElementById("DriverIdd").value;

            var $newRow = $("#MainRow").clone().attr('id', "Row" + j);

            j++;
            $('.DriverIdd', $newRow).val(productID);

            $('#addd', $newRow).removeAttr('hidden').addClass('remove').html('<i class="fa fa-trash"></i>').removeClass('newbtn waves-effect btn-add').removeAttr('hidden').addClass('btn-outline-danger');
            $('#ItemNumber,#DriverIdd', $newRow).attr('disabled', false);
            $('#ItemNumber,#DriverIdd', $newRow).removeAttr('id');
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

            $lastTr.find('.DriverIdd').select2(); // Re-instrument original row
            //$lastTr.find('.UnitList').select2(); // Re-instrument original row
            $lastTr.find('.selection').last().hide();
            $lastTr.find('.selection').eq(1).hide();

            $lastTr.find('.select2').last().css("display", "none");
            $lastTr.find('.select2').eq(2).css("display", "none");



            //$("#TbItem #MainRow #Price").val(0);
            //$("#TbItem #MainRow #Qty").val(1);
            //$("#TbItem #MainRow #Total").text('');
            //$("#TbItem #MainRow #Disper").val(0);
            //$("#TbItem #MainRow #DisValue").val(0);
            //$("#TbItem #MainRow #Net").text('');
            //$("#Price").val(0);
            //$("#Qty").val(1);
            //$("#Total").text('');
            //$("#Disper").val(0);
            //$("#DisValue").val(0);
            //$("#Net").text('');
            $("#ItemNumber").val(0);
            /* $("#ItemBalance").val(0);*/

        }

    });
    $("#submit").click(function () {

        $.get("/CarDrivers/GetLastTRX", { ID: $("#CarId").val() }, function (result) {
            //alert(result)
            /*alert(result)*/
            if (result == 1) {
                //alert("aaaa")
                toastr.warning("هذه السيارة لها محضر تسليم")

            }
            else if (result != 1) {
                $("#OrdersItems tbody tr").each(function () {

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

                        CompanionID: $('.DriverIdd', this).val(),

                    }
                    itemsList.push(item);
                });

                if (isValid == false) {
                    toastr.error('لم يتم الحفظ ...!')
                }
                if (isValid) {
                    var data = {
                        Year: $("#Year").val(),
                        Serial: $("#Serial").val(),
                        Date: $("#Date").val(),
                        Type: $("#Type").val(),
                        CarId: $("#CarId").val(),
                        DriverID: $("#DriverID").val(),
                        Time: $("#TimeId").val(),
                        SideName: $("#SideName").val(),
                        DeliverTime: $("#DeliverTime").val(),
                        Notes: $("#Notes").val(),
                        DaysCount: $("#DaysCount").val(),
                        ToDate: $("#ToDate").val(),

                        Items: itemsList
                    }


                    $("#submit").attr("disabled", true);
                    $(".remove ").hide();
                    $.ajax({
                        type: 'POST',
                        url: '/CarDrivers/AddCarReceipt',
                        data: JSON.stringify(data),
                        contentType: 'application/json',
                        success: function (data) {
                            if (data.status) {
                                //$('#Ordermessages').text(data.message);
                                location.href = "/CarDrivers/Index";
                                toastr.success("تم الحفظ بنجاح")
                            }
                            else {
                                //$('#Ordermessages').text(data.message);
                                toastr.danger("فشل في الحفظ")
                            }


                        }

                    });

                    //AddOrderAndDetails
                    //$.ajax({
                    //    type: 'POST',
                    //    url: '/CarDrivers/AddCarReceipt',
                    //    data: JSON.stringify(data),
                    //    contentType: 'application/json',
                    //    success: function (data) {
                    //        if (data.status) {
                    //            //$('#Ordermessages').text(data.message);
                    //            location.href = "/CarDrivers/Index";
                    //            toastr.success("تم الحفظ بنجاح")


                    //        }
                    //        else {
                    //            //$('#Ordermessages').text(data.message);
                    //            toastr.danger("فشل في الحفظ")

                    //        }


                    //    }

                    //});

                }
              
            }

        });

    });

    


    $("#edit").click(function () {



        $("#OrdersItems tbody tr").each(function () {

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

                CompanionID: $('.DriverIdd', this).val(),

            }
            itemsList.push(item);
        });





        if (isValid == false) {
            toastr.error('لم يتم التعديل ...!')
        }
        if (isValid) {
            var data = {
                Year: $("#Year").val(),
                Serial: $("#Serial").val(),
                Date: $("#Date").val(),
                Type: $("#Type").val(),
                CarId: $("#CarId").val(),
                DriverID: $("#DriverID").val(),
                SideName: $("#SideName").val(),
                Time: $("#TimeId").val(),
                DeliverTime: $("#DeliverTime").val(),
                Notes: $("#Notes").val(),
                DaysCount: $("#DaysCount").val(),
                ToDate: $("#ToDate").val(),

                Items: itemsList
            }


            $("#submit").attr("disabled", true);
            $(".remove ").hide();

            //AddOrderAndDetails
            $.ajax({
                type: 'POST',
                url: '/CarDrivers/UpdateCarReceipt',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        //$('#Ordermessages').text(data.message);
                        location.href = "/CarDrivers/Index";
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








