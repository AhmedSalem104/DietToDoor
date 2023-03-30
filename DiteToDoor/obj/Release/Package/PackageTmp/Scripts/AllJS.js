function loadStores() {

    jQuery.get("/Store/StoresList", function (data) {
            if (data != '') {
                jQuery("form").unbind("submit");
                jQuery("#save-stage").append(data);
            }
            else {
                page = -2;
            }
            //_inCallback = false;
            //jQuery('div#loading').empty();
        });
    }
