function AddFollowUp() {
    alert("aaa")
    var weight = $("#weight").val();
    var circumference = $("#circumference").val();


    var Isvalid = true;
    if (weight == "" || weight == null) {
        Isvalid = false;
        toastr.warning('ادخل الوزن الحالى')
    }
    if (circumference == "" || circumference == null) {
        Isvalid = false;
        toastr.warning('ادخل محيط الوسط')
    }


    if (Isvalid) {
        var data = {
            CurrentWeight: $("#weight").val(),
            CurrentCenterOfCircumference: $("#circumference").val(),
            Notes: $("#comments").val(),
            Attachment: document.getElementByTagName("Upload2").src,


        }
        /*$("#Save").hide();*/
        //$("#SaveBTN").attr("disabled", true);
        $.ajax({

            type: "POST",
            url: '/Home/AddOrEdit',     //your action
            data: JSON.stringify(data),  //your form name.it takes all the values of model
            contentType: 'application/json',
            success: function (data) {
                toastr.success("تم الحفظ بنجاح")



            },



        });
    }
}