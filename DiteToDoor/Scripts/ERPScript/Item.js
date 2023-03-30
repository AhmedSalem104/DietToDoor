$(function () {
   
    $("#Submit").click(function () {
        //debugger;
        var isValid = true;
      
           
        var item = $('#FormData').serialize()
          
            //itemsList.push(item);
 
        if (isValid) {
            var data = item

            //$("#submit").attr("disabled", true);

            $.ajax({
                type: 'POST',
                url: '/Item/AddOrEdit',
                data:$('#FormData').serialize(),
                contentType:'json',
                success: function (data) {
                    if (data.status) {
                        $('#Ordermessages').text(data.message);
                        alert("تم الحفظ بنجاح")
                    }
                    else {
                        $('#Ordermessages').text(data.message);
                        alert("فشل الحفظ")
                    }

                }

            });

        }




    });
});



$(function () {

  
});








