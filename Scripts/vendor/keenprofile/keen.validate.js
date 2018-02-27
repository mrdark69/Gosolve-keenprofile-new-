   function KeenValidate() {

              var checkret = true;

              var ret = true;

              var reqEle = $('.keen-required').not('div');
              $.each(reqEle, function () {
                  ret = true;

                  var _this = $(this);

                  var validtype = _this.data('validtype');

                  var eleVal = _this.val();

                  if (eleVal == "") {
                      ret = false;
                      checkret = false;

                  }

                  if (validtype) {

                     

                   
                      var arrtype = validtype.split(',');
                      if (arrtype.length > 0) {

                          for (var i = 0; i < arrtype.length;i++){

                              switch (arrtype[i]) {
                                  case "number":
                                      
                                      var re = new RegExp('^[0-9]*$');
                                      if (!eleVal.match(re)) {
                                          ret = false;
                                          checkret = false;
                                      }


                                      break;
                                  case "date":
                                      var re = new RegExp('^[0-9]{2}$');
                                      if (!eleVal.match(re)) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;
                                  case "year":
                                      var re = new RegExp('^[0-9]{4}$');
                                      if (!eleVal.match(re)) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;

                                  case "select":

                                      if (eleVal == "" || eleVal == null) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;
                                  case "email":

                                      var re = new RegExp('^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$');
                                      if (!eleVal.match(re)) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;
                                  case "password":

                                      var re = new RegExp("^(?=.*[A-Z]).{8,15}$");
                                      if (!eleVal.match(re)) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;
                                  case "equal-password":
                                      //equal

                                      var q = _this.data('equal');
                                      var equal = $('#' + q);
                                      var password = equal.val();
                                      if (eleVal != password) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      
                                      break;
                                  case "checkbox":

                                 
                                      if (!_this.prop('checked')) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;

                                  case "hidden":

                                     
                                      if (eleVal == "" || eleVal == null || eleVal == "undified") {
                                          ret = false;
                                          checkret = false;
                                      }
                                      break;

                                  case "phone":

                                      var re = new RegExp('^[\\+]*[0-9]{8,12}$');
                                      if (!eleVal.match(re)) {
                                          ret = false;
                                          checkret = false;
                                      }
                                      

                                      break;
                              }


                          }

                      }



                  }

                  if (!ret) {
                      _this.addClass("keen-invalid");
                      _this.closest('.keen-form-block').find("p.text-validate").show();
                  } else {
                      _this.removeClass("keen-invalid");

                      _this.closest('.keen-form-block').find('.keen-invalid').removeClass('keen-invalid');
                      _this.closest('.keen-form-block').find("p.text-validate").hide();
                  }


              });
              //keen-required
              return checkret;
          }