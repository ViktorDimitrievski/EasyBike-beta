
function GetLocations(el) {

    if ($("#gmap").html() != "")
        $("#gmap").html("");

    $.ajax({
        url: "/Home/GetBikeLocation",
        data: JSON.stringify({ cityID: $("#select_city").val() }),
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var location = data["item"];
            var LocsA = [];
            var lat;
            var lon;

            if($("#select_city").val() == "1")
            {
                lat = 42.00162;
                lon = 21.432864;
            }
            else if($("#select_city").val() == "2")
            {
                lat = 41.030161;
                lon = 21.335039;
            }
            else if($("#select_city").val() == "3")
            {
                lat = 41.113240;
                lon = 20.799732;
            }
            for(var i = 0 ; i < data["item"].Bikes.length; i++) {
                var obj = {};

                obj.lat = data["item"].Bikes[i].Latitude;
                obj.lon = data["item"].Bikes[i].Longtitude;
                obj.icon = '/Data/pinBlue.png';
                obj.title = '';
                obj.html = '<h4><i class="fa fa-bicycle Pin" aria-hidden="true"></i>Bike ID: ' + data["item"].Bikes[i].BikeCode + '</h4><a href="/Home/Rent" class="btn btn-info btn-rent">Rent</a>';
                obj.animation = google.maps.Animation.DROP;
                obj.zoom = 14;
                LocsA.push(obj);

            }

            new Maplace({
                show_markers: true,
                draggable: true,
                map_options: {
                    set_center: [lat, lon],
                    zoom: 14
                },
                locations: LocsA,
                map_div: '#gmap',
                generate_controls: false,
                beforeOpenInfowindow: function () {
                    $("div[style='cursor: default; position: absolute; width: 200px; height: 91px; left: 860px; top: 55px; z-index: 55;']").css("opacity", "0.8");
                }
                
            }).Load();
           
        }
    });
    
}


//}
//$(function () {
//    new Maplace({
//    show_markers: false,
//    draggable:false,
//    locations: [{
//        lat:41.9973,
//        lon: 21.4280,
//        zoom: 14
//    }]
//}).Load();

//});
  