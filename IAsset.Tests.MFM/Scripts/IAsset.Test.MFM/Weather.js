/*!
 * /////////// Weather.js ///////////
 *
 * Author: Mohamed Farouk
 * Summary: Handling Client Side processing of Weather app. Depends on JQuery, Bootstrap.
 * License: Open
 * Version: 1.0B
*/

window.IAsset = window.IAsset || {};
IAsset.MFM = function (MFM, $) {
    MFM.ShowHideCity = function () {
        $('#City option').remove();
        $('#City').hide();
        $('#WeatherCard').hide();
        $('#CitiesLoading').show(200);
        $.ajax({
            url: "/api/GetCities?country=" + encodeURIComponent($("#Country").val()),
            success: function (result) {
                result = JSON.parse(result).NewDataSet;
                if (result) {
                    $('<option/>').val("").html("Select City...").appendTo('#City');
                    if (result.Table.length) {
                        for (var i = 0; i < result.Table.length; i++) {
                            $('<option/>').val(result.Table[i].City).html(result.Table[i].City).appendTo('#City');
                        }
                    }
                    else
                        $('<option/>').val(result.Table.City).html(result.Table.City).appendTo('#City');
                }
                else
                    $('<option/>').val("").html("[No Cities defined for this country]").appendTo('#City');
                        
                $('#CitiesLoading').hide();
                $('#City').show(200);
            },
            error: function (result) {
                alert("error");
            }
        });
        if ($("#Country").val() != "")
            $("#CityRow").show(300);
        else
            $("#CityRow").hide(300);
    };

    MFM.ShowWeatherDetails = function () {
        $('#WeatherCard').hide();
        $.ajax({
            url: "/api/GetWeather?country=" + encodeURIComponent($("#Country").val()) + "&city=" + $("#City").val(),
            success: function (result) {
                var mode = result.mode;
                var weatherResult = JSON.parse(result.json);                
                var weather = null;
                if (mode == "openweathermap")
                {
                    weather = MFM.OpenweathermapToWeather(weatherResult);
                    weather.Country = $("#Country").val();
                    weather.City = $("#City").val();
                }                    
                else
                    //TODO: Handle GlobalWeather (Currently always returns Data Not Found)
                    alert("Not Implemented.");
                MFM.RenderWeather(weather);
            },
            error: function (result) {
                //TODO: Proper Error handling
                //alert("error");
            }
        });
    };

    MFM.Weather = function () {
        this.Country;
        this.City;
        this.Location;
        this.Time;
        this.Wind;
        this.Visibility;
        this.SkyConditions;
        this.Temperature;
        this.MinTemperature;
        this.MaxTemperature;
        this.DewPoint;
        this.RelativeHumidity;
        this.Pressure;
        this.Icon;
    };

    MFM.OpenweathermapToWeather = function(rawJson){
        var weather = new MFM.Weather();
        weather.Location = rawJson.coord.lon + "," + rawJson.coord.lat;
        weather.Time = MFM.formatDate(new Date(parseInt(rawJson.dt) * 1000));
        weather.Wind = rawJson.wind.speed;
        weather.Visibility = rawJson.visibility;
        weather.SkyConditions = rawJson.weather[0].main;
        weather.Icon = rawJson.weather[0].icon;
        weather.Temperature = rawJson.main.temp;
        weather.MinTemperature = rawJson.main.temp_min;
        weather.MaxTemperature = rawJson.main.temp_max;
        weather.DewPoint = MFM.formatDate(new Date(parseInt(rawJson.sys.sunset) * 1000), true);
        weather.RelativeHumidity = rawJson.main.humidity;
        weather.Pressure = rawJson.main.pressure;
        return weather;
    };

    MFM.RenderWeather = function (weather) {
        $(".location").text(weather.City + ", " + weather.Country);
        $(".heading-value").text(weather.SkyConditions);
        $(".temp-value").text(weather.Temperature);
        $(".mintemp-value").text(weather.MinTemperature);
        $(".maxtemp-value").text(weather.MaxTemperature);
        $(".datetime-value").text(weather.Time);
        $(".visibility-value").text(weather.Visibility);
        $(".wind").text(weather.Wind);
        $(".dewpoint").text(weather.DewPoint);
        $(".relativehumidity").text(weather.RelativeHumidity);
        $(".pressure").text(weather.Pressure);
        $(".heading-icon").html("<img src='http://openweathermap.org/img/w/" + weather.Icon + ".png'/>"); 
        
        $('#WeatherCard').show("slow");
    };

    MFM.formatDate =  function (date, timeOnly) {
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0' + minutes : minutes;
        var strTime = hours + ':' + minutes + ' ' + ampm;
        if (timeOnly)
            return strTime;
        return date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear() + "  " + strTime;
    }

    return MFM;
}(IAsset.MFM = IAsset.MFM || {}, jQuery);