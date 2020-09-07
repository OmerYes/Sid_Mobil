var apiurl = "https://localhost:44325";
//var weburl = "http://localhost:59425";
//var Productweburl ="http://localhost:59425/Content/Products/"
//var InfluencerUserID = localStorage.getItem("user");

//var apiurl = "http://teklifalver.polynomtech.net";
var weburl = "http://localhost:59425";
var Productweburl = "http://localhost:59425/Content/Products/"
var InfluencerUserID = localStorage.getItem("user");

//function SIDAjax(url, data, type) {
//    var result = {};
//    var baseurl = apiurl + url;
//    $.ajax({
//        async: false,
//        url:baseurl,
//        data: data,
//        type: type,

//        success: function (response) {
//            result=response;
//        },

//        error: function (response) {
//            result = response;
//            if (m.status == "400") {
//                var msg = "";
//                var response = JSON.parse(result.responseText);
//                if (response != null) {
//                    var modelState = response.ModelState;

//                    for (var key in modelState) {
//                        if (modelState.hasOwnProperty(key)) {
//                            msg += modelState[key] + "\n"
//                        }
//                    }
//                    result = msg;
//                    alert(result);
//                }
//            }

//            else {
//                result = m.status + m.responseText;
//            }

            
//        }


//    })
//    return result;
//}