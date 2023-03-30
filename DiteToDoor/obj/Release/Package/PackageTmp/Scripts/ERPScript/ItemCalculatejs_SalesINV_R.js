
/// this  script to clculate total befor dis  and totla amount after dis for ever added item 
// بحساب القيمه واجمالي القيمه بعد الخصم لكل عنصر بختاره عنصر عنصر 



$(document).on("change keyup blur", "#TbItem #MainRow #Price", function () {
    var price = $('#TbItem #MainRow #Price').val();
    var quantity = $('#TbItem #MainRow #Qty').val();
    
 
    var mult = price * quantity; 
 
    $('#TbItem #MainRow #Total').val(mult);
    $("#TbItem #MainRow #Net").val(mult);
    

});

$(document).on("change keyup blur", "#TbItem #MainRow #Qty", function () {
    var price = $('#TbItem #MainRow #Price').val();
    var quantity = $('#TbItem #MainRow #Qty').val();
   

    var mult = price * quantity;

    $('#TbItem #MainRow #Total').val(mult);
    $("#TbItem #MainRow #Net").val(mult);


});
//  بطريقه نسبه الخصم حساب قيه الخصم لكل صنف
$(document).on("keyup", "#TbItem #MainRow #Disper", function () {
     
    var Amount = $("#TbItem #MainRow #Qty").val() * $("#TbItem #MainRow #Price").val() - ($("#TbItem #MainRow #Qty").val() * $("#TbItem #MainRow #Price").val() * ($("#TbItem #MainRow #Disper").val() / 100));
    var Net = $("#TbItem #MainRow #Net").val() 
    var DisValue = Net - Amount;

    $("#TbItem #MainRow #DisValue").val(DisValue.toFixed(2));//قيمه الخصم نفسه
    $("#TbItem #MainRow #Net").val(Amount);//القيمه بعد الخصم 

});

//حساب نسبه الخصم عن طريق قيمه الخصم
$(document).on("keyup", "#TbItem #MainRow #DisValue", function () {

    var Amount = $("#TbItem #MainRow #Qty").val() * $("#TbItem #MainRow #Price").val();
    var DisValue = $("#TbItem #MainRow #DisValue").val();

    var DisPer = DisValue / Amount*100;
    
    var DisValue = Amount - DisValue;

    $("#TbItem #MainRow #Disper").val(DisPer);//قيمه الخصم نفسه
    $("#TbItem #MainRow #Net").val(DisValue);//القيمه بعد الخصم 

});


//  حساب نسبه الخصم للاجمالي الكلي للفاتورة
$(document).on("keyup", "#OrdersItems #DefualtRow #TotalDisper", function () {

    var Amount = $("#OrdersItems #DefualtRow #TotalBeforeDis").text() - ($("#OrdersItems #DefualtRow #TotalBeforeDis").text() * ($("#OrdersItems #DefualtRow #TotalDisper").val() / 100));
    var Net = $("#OrdersItems #DefualtRow #TotalBeforeDis").text()
    var DisValue = Net - Amount;

    $("#OrdersItems #DefualtRow #TotalDis").val(DisValue.toFixed(2));//قيمه الخصم نفسه
    $("#OrdersItems #DefualtRow #TotalNet").text(Amount);//القيمه بعد الخصم 

});
//  حساب نسبه الخصم عن طريق قيمه الخصم للاجمالي الكلي للفاتورة
$(document).on("keyup", "#OrdersItems #DefualtRow #TotalDis", function () {

    var Amount = $("#OrdersItems #DefualtRow #TotalBeforeDis").text();
    var Net = $("#OrdersItems #DefualtRow #TotalDis").val();
    var DisValuetotalper = Net/Amount*100;
    var total = Amount - Net;
    $("#OrdersItems #DefualtRow #TotalDisper").val(DisValuetotalper);//قيمه الخصم نفسه
    $("#OrdersItems #DefualtRow #TotalNet").text(total.toFixed(2));//القيمه بعد الخصم 

});
// حساب اجمالي عدد الاصناف اجمالي الكميه قبل الخصم اجمالي قيمه الخصم اجمالي القيمه بعد الخصم

$("#add").click(function () {



    var Quat = $("#OrdersItems #DefualtRow #Qty").val();
    var Total = $("#OrdersItems #DefualtRow #Total").val();
    var Disper = $("#OrdersItems #DefualtRow #Disper").val();
    var DisValue = $("#OrdersItems #DefualtRow #DisValue").val();

 







//////////////////////////////////////////////////////////////////////////



///////////////////////////////////////////////////////////////////

    //get all toatal of total before Dis Osama Sadek
   //حساب كل القيمه قبل الخصم لكل اصناف الفاتوره

    var $numoItem = $("#TbItem tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(Total)) {
            var TotalQuat = 0;

            $("OrdersItems #DefualtRow #Total").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalBeforeDis").text(TotalQuat);
        }


    });




    ///////////////////////////////////////////////////////////////////

   //حساب نسبه الخصم في اجمالي الفاتوره كلها

    var $numoItem = $("#TbItem tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(Disper)) {
            var TotalQuat = 0;

            $(".Disper").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalDisper").text(TotalQuat);
        }


    });

///////////////////////////////////////////////


    ///////////////////////////////////////////////////////////////////

    //حساب قيمه الخصم علي مستوي الفاتوره

    var $numoItem = $("#TbItem tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(DisValue)) {
            var TotalQuat = 0;

            $(".DisValue").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalDis").text(TotalQuat);
            $("#TotaleItemDis").val(TotalQuat);
            
        }


    });

///////////////////////////////////////////////


///////////////////////////////////////////////
    //حساب عدد الاصناف في الفاتوره 
    var rowCount = $("#OrdersItems tr").length;

    $("#RowsCount").val(rowCount);
    
//////////////////////////////////////////////////////////////////////////////
    
    //حساب اجمالي الصافي للفاتوره

    var Net = parseFloat($(".TotalBeforeDis").text()) - parseFloat($("#TotalDis").text());
    $("#TotalNet").text(Net.toFixed(2));
////////////////////////////////////////////////////////////////////////////
     // Delete Tr from table
    //لحذف صنف من الفاتوره قبل الحفظ
$("#OrdersItems").on("click", ".remove", function () {
    debugger;
    $(this).parents("tr").remove();



    //حساب كل القيمه قبل الخصم لكل اصناف الفاتوره

    var $numoItem = $("#TbItem tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(Total)) {
            var TotalQuat = 0;

            $(".Total").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalBeforeDis").text(TotalQuat);
        }


    });




    ///////////////////////////////////////////////////////////////////

    //حساب نسبه الخصم في اجمالي الفاتوره كلها

    var $numoItem = $("#TbItem tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(Disper)) {
            var TotalQuat = 0;

            $(".Disper").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalDisper").text(TotalQuat);
        }


    });

    ///////////////////////////////////////////////


    ///////////////////////////////////////////////////////////////////

    //حساب قيمه الخصم علي مستوي الفاتوره

    var $numoItem = $("#TbItem tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(DisValue)) {
            var TotalQuat = 0;

            $(".DisValue").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalDis").text(TotalQuat);
            $("#TotaleItemDis").val(TotalQuat);

        }


    });

    ///////////////////////////////////////////////


    ///////////////////////////////////////////////
    //حساب عدد الاصناف في الفاتوره 
    var rowCount = $("#OrdersItems tr").length;

    $("#RowsCount").val(rowCount);

    //////////////////////////////////////////////////////////////////////////////

    //حساب اجمالي الصافي للفاتوره

    var Net = parseFloat($(".TotalBeforeDis").text()) - parseFloat($("#TotalDis").text());
    $("#TotalNet").text(Net.toFixed(2));



});

    //حساب المتبقي بعد الدفع

    $(document).on("change keyup blur", "#Payed", function () {
        var TotalNet = $('#TotalNet').text();
        var Payed = $('#Payed').val();

        var mult = Payed -TotalNet;

        $('#Residual').text(mult);
       


    });




});



//حساب الكميه في السعر في حاله المرتد مشتريات

$(document).on("change keyup blur", "#OrdersItems #DefualtRow #Price", function () {
    $("#OrdersItems tr").each(function () {


        $(this).find('.Total').val($(this).find('.Qty').val() * $(this).find('.Price').val());
        var amount = $(this).find('.Qty').val() * $(this).find('.Price').val();
        var DisValue = $("#OrdersItems #DefualtRow #DisValue").val();
        var Net = amount - DisValue;
        //$("#OrdersItems #DefualtRow #Net").val(Net)
        $(this).find("#Net").val(Net);
        var Amount = amount - amount * ($("#OrdersItems #DefualtRow #Disper").val() / 100);
        $(this).find("#Net").val(Amount);

    });

});

$(document).on("change keyup blur", "#OrdersItems #DefualtRow #Qty", function () {
    var Net = $("#OrdersItems #DefualtRow #Net").val();
    var $numoItem = $("#OrdersItems tr:gt(0)");
    $numoItem.each(function (index) {
        var $tblrow = $(this);
        if (!isNaN(Net)) {
            var TotalQuat = 0;

            $("#OrdersItems #DefualtRow #Total").each(function () {
                var sval = parseInt($(this).val());
                TotalQuat += isNaN(sval) ? 0 : sval;
            });

            $(".TotalBeforeDis").text(TotalQuat);
        }


    });

});

//حساب المتبقي بعد الدفع

$(document).on("change keyup blur", "#Payed", function () {
    var TotalNet = $('#TotalNet').text();
    var Payed = $('#Payed').val();

    var mult = Payed - TotalNet;

    var doubleVal = (mult).toFixed(2);

    $('#Residual').text(doubleVal);



});




$("#OrdersItems #DefualtRow #DeleteTR").click(function () {

    $(this).parents("tr").remove();
});