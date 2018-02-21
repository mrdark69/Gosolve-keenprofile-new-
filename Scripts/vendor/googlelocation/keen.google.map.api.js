


var AUTO_LOCATION = document.getElementById("google.map.api").getAttribute("auto-location");


var autocomplete;
var componentForm = {
  street_number: 'short_name',
  route: 'long_name',
  locality: 'long_name',
  administrative_area_level_1: 'short_name',
  country: 'long_name',
  postal_code: 'short_name'
};

function initAutocomplete() {
  if(AUTO_LOCATION) {
    autofillRegisterLocation();
  }

  var location = document.getElementById("userlocation");

  if (location) {
      var country_code = getElementHiddenNext(location);
      var geographic = getElementHiddenNext(country_code);
      var country_name = getElementHiddenNext(geographic);
      var area_location = getElementHiddenNext(country_code);
      var area_location2 = getElementHiddenNext(area_location);
      initialGooglePlace(location, country_code, country_name, geographic, area_location, area_location2);
  }
}

function getElementHiddenNext(e) {
  if(e && e.nextElementSibling && e.nextElementSibling.getAttribute("type") == "hidden") {
    return e.nextElementSibling;
  } else {
    return null;
  }
}

function getLocationJson() { // static element
  var txt_country_code = document.getElementById("txt-location");
  var place = autocomplete.getPlace();
  if(place) {
    if(place.address_components && place.address_components.length > 0) {

        getCountryFromPlace(place.address_components, function (data, location) {

        var country_code = document.getElementById("country-code");
        var country_name = document.getElementById("country-name");
        var geographic = document.getElementById("geographic");
        var locationarea = document.getElementById("area-location");

        if(data && place.geometry) {
          data.geolocation = [place.geometry.location.lat(), place.geometry.location.lng()];
        }

        setGooglePlaceToElement(data, country_code, country_name, geographic, location, locationarea);

        if(data && data.short_name && txt_country_code) {
          txt_country_code.style.display = 'none';
        }

      });

    }
  }
}

function initialGooglePlace(location, country_code, country_name, geographic, area_location, area_location2) { // dynamic element
  var autoplace = new google.maps.places.Autocomplete(location, {
    types: ['geocode']
  });
  if(country_code) {
    location.addEventListener("keydown", function(e) {
      var keycode;

      if(window.event) { // IE
        keycode = e.keyCode;
      } else if(e.which) { // Netscape/Firefox/Opera
        keycode = e.which;
      }

      if(keycode !== 9) {
        country_code.value = "";
      }
    });

    autoplace.addListener("place_changed", function() {
      var place = autoplace.getPlace();
      if(place) {
        if(place.address_components && place.address_components.length > 0) {

          getCountryFromPlace(place.address_components, function(data,location) {

            if(data && place.geometry) {
              data.geolocation = [place.geometry.location.lat(), place.geometry.location.lng()];
            }

            setGooglePlaceToElement(data, country_code, country_name, geographic, location, area_location, area_location2);

          });

        }
      }
    });
  }
}

function setGooglePlaceToElement(place, country_code, country_name, geographic, location, location_area, area_location2) {

  if(place) {
    if(country_code) {
      console.log(place.short_name.toLowerCase());
      place.short_name = handleReplaceCountryCode(place.short_name.toLowerCase());
      console.log(place.short_name);
      setValueFromElement(country_code, place.short_name.toLowerCase());
    }
    if(country_name) {
      setValueFromElement(country_name, place.long_name);
    }
    if(geographic && place.geolocation) {
      setValueFromElement(geographic, place.geolocation);
    }
    }

  if (location) {
      console.log(location.short_name.toLowerCase());

      if (location_area) {
          setValueFromElement(location_area, location.short_name.toLowerCase());
      }

      if (area_location2) {
          setValueFromElement(area_location2, location.long_name.toLowerCase());
      }
     
      
  }

}

function handleReplaceCountryCode(country_code) {
  if(country_code == "thailand") {
    country_code = "th";
  } else if(country_code == "vietnam") {
    country_code = "vn";
  } else if(country_code == "singapore") {
    country_code = "sg";
  } else if(country_code == "south korea") {
    country_code = "kr";
  } else if(country_code == "india") {
    country_code = "in";
  } else if(country_code == "united states") {
    country_code = "us";
  } else if(country_code == "france") {
    country_code = "fr";
  } else if(country_code == "afghanistan") {
    country_code = "af";
  } else if(country_code == "albania") {
    country_code = "al";
  } else if(country_code == "algeria") {
    country_code = "dz";
  } else if(country_code == "american samoa") {
    country_code = "as";
  } else if(country_code == "andorra") {
    country_code = "ad";
  } else if(country_code == "angola") {
    country_code = "ao";
  } else if(country_code == "anguilla") {
    country_code = "ai";
  } else if(country_code == "antarctica") {
    country_code = "aq";
  } else if(country_code == "antigua and barbuda") {
    country_code = "ag";
  } else if(country_code == "argentina") {
    country_code = "ar";
  } else if(country_code == "armenia") {
    country_code = "am";
  } else if(country_code == "aruba") {
    country_code = "aw";
  } else if(country_code == "australia") {
    country_code = "au";
  } else if(country_code == "austria") {
    country_code = "at";
  } else if(country_code == "azerbaijan") {
    country_code = "az";
  } else if(country_code == "bahamas") {
    country_code = "bs";
  } else if(country_code == "bahrain") {
    country_code = "bh";
  } else if(country_code == "bangladesh") {
    country_code = "bd";
  } else if(country_code == "barbados") {
    country_code = "bb";
  } else if(country_code == "belarus") {
    country_code = "by";
  } else if(country_code == "belgium") {
    country_code = "be";
  } else if(country_code == "belize") {
    country_code = "bz";
  } else if(country_code == "benin") {
    country_code = "bj";
  } else if(country_code == "bermuda") {
    country_code = "bm";
  } else if(country_code == "bhutan") {
    country_code = "bt";
  } else if(country_code == "bolivia") {
    country_code = "bo";
  } else if(country_code == "bosnia and herzegovina") {
    country_code = "ba";
  } else if(country_code == "botswana") {
    country_code = "bw";
  } else if(country_code == "brazil") {
    country_code = "br";
  } else if(country_code == "british indian ocean territory") {
    country_code = "io";
  } else if(country_code == "british virgin islands") {
    country_code = "vg";
  } else if(country_code == "brunei") {
    country_code = "bn";
  } else if(country_code == "bulgaria") {
    country_code = "bg";
  } else if(country_code == "burkina faso") {
    country_code = "bf";
  } else if(country_code == "burundi") {
    country_code = "bi";
  } else if(country_code == "cambodia") {
    country_code = "kh";
  } else if(country_code == "cameroon") {
    country_code = "cm";
  } else if(country_code == "canada") {
    country_code = "ca";
  } else if(country_code == "cape verde") {
    country_code = "cv";
  } else if(country_code == "cayman islands") {
    country_code = "ky";
  } else if(country_code == "central african republic") {
    country_code = "cf";
  } else if(country_code == "chad") {
    country_code = "td";
  } else if(country_code == "chile") {
    country_code = "cl";
  } else if(country_code == "china") {
    country_code = "cn";
  } else if(country_code == "christmas island") {
    country_code = "cx";
  } else if(country_code == "cocos islands") {
    country_code = "cc";
  } else if(country_code == "colombia") {
    country_code = "co";
  } else if(country_code == "comoros") {
    country_code = "km";
  } else if(country_code == "cook islands") {
    country_code = "ck";
  } else if(country_code == "costa rica") {
    country_code = "cr";
  } else if(country_code == "croatia") {
    country_code = "hr";
  } else if(country_code == "cuba") {
    country_code = "cu";
  } else if(country_code == "curacao") {
    country_code = "cw";
  } else if(country_code == "cyprus") {
    country_code = "cy";
  } else if(country_code == "czech republic") {
    country_code = "cz";
  } else if(country_code == "democratic republic of the congo") {
    country_code = "cd";
  } else if(country_code == "denmark") {
    country_code = "dk";
  } else if(country_code == "djibouti") {
    country_code = "dj";
  } else if(country_code == "dominica") {
    country_code = "dm";
  } else if(country_code == "dominican republic") {
    country_code = "do";
  } else if(country_code == "east timor") {
    country_code = "tl";
  } else if(country_code == "ecuador") {
    country_code = "ec";
  } else if(country_code == "egypt") {
    country_code = "eg";
  } else if(country_code == "el salvador") {
    country_code = "sv";
  } else if(country_code == "equatorial guinea") {
    country_code = "gq";
  } else if(country_code == "eritrea") {
    country_code = "er";
  } else if(country_code == "estonia") {
    country_code = "ee";
  } else if(country_code == "ethiopia") {
    country_code = "et";
  } else if(country_code == "falkland islands") {
    country_code = "fk";
  } else if(country_code == "faroe islands") {
    country_code = "fo";
  } else if(country_code == "fiji") {
    country_code = "fj";
  } else if(country_code == "finland") {
    country_code = "fi";
  }

  return country_code;
}

function getCountryFromPlace(address_components, callback) {
  var value = null;
  for (var i = 0; i < address_components.length; i++) {
    var addressType = address_components[i].types[0];
    if (addressType == "country") {
      value = address_components[i]
    }
  }


  var valuelocation = null;

  if (address_components.length > 0) {
      valuelocation = address_components[0]
  }

  callback(value, valuelocation);
}



function blurLocation() {
  var countryCode = document.getElementById('country-code');
  var txt_country_code = document.getElementById('txt-location');
  if(countryCode.value) {
    if(txt_country_code) {
      txt_country_code.style.display = 'none';
    }
  } else {
    if(txt_country_code) {
      txt_country_code.style.display = 'inline';
    }
  }
}

function resetLocation() {
  var countryCode = document.getElementById('country-code');
  countryCode.value = null
}

$('form').on('keyup keypress', function(e) {
  var keyCode = e.keyCode || e.which;
  if (keyCode === 13) {
    e.preventDefault();
    return false;
  }
});


function autofillRegisterLocation() {
    var city = "", country = "", country_code = "", arealocation="";

  var onSuccess = function(location){
    // console.log(
    //     "Lookup successful:\n\n"
    //     + JSON.stringify(location, undefined, 4)
    // );

    city = location.city.names.en;
    country = location.country.names.en;
    country_code = location.country.iso_code.toLowerCase();
    var text = (city ? city + ", " : '') + (country ? country : "");

    arealocation = "";


    $('.cadidate-txt-location').text(text);
    $('.company-txt-location').text(text);
    $('#candidateLocation').val(text);
    $(".cadidate-div-location").css("display", "block");
    $("#candidateLocation").css("display", "none");

    $('#companyLocation').val(text);
    $('#country-code').val(country_code);
    $('#companyCountry-code').val(country_code);
    $(".company-div-location").css("display", "block");
    $("#companyLocation").css("display", "none");


    $('#area-location').val(arealocation);
  

  };

  var onError = function(error){
    console.log(
        "Error:\n\n"
        + JSON.stringify(error, undefined, 4)
    );
  };

  geoip2.city(onSuccess, onError);
}


function setValueFromElement(e, v) {
  if(e) {
    e.value = v ? v : null;
  }
}
