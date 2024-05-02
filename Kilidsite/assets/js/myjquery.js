function searching() {
    alert("سلام"); 
    var place = $("#place1").val();
    var AdType = 0;

    var size = $("#size1").val().split("_");


    var age = $("#age1").val().split("_");

    var price = $("#price1").val().split("_");

    var roomnum = $("#roomnum1").val();

    if ($("#size1").attr("selectedIndex") == 0) {
        size = null;
    }
    if ($("#age1").attr("selectedIndex") == 0) {
        age = null;
    }
    if ($("#price1").attr("selectedIndex") == 0) {
        price = null;
    }
    if ($("#price1").attr("selectedIndex") == 0) {
        roomnum = null;
    }
    var elevator = 0;

    var paking = 0;

    var balcony = 0;

    var stor = 0;

    if ($('#elevator1').is(":checked")) {
        elevator = 1;
    }
    if ($('#parking1').is(":checked")) {
        parking = 1;
    }
    if ($('#balcony1').is(":checked")) {
        balcony = 1;
    }
    if ($('#stor1').is(":checked")) {
        stor = 1;
    }
    
    $.post("/Home/filterBuy", { AdType: AdType, place: place, minsize: size[0], maxsize: size[1], minage: age[0], maxage: age[1], minprice: price[0], maxprice: price[1], roomnum: roomnum, elevator: elevator, paking: paking, balcony: balcony, stor: stor })

    $("#resaults").empty();

  .done(function (res) {
        for (var item in res) {
            var par = "پارکینگ ندارد";
            var ele = "آسانسور ندارد";
            var bal = "بالکن ندارد";
            var sto = "انباری ندارد";


            if (res[item].ParkingLot == 1) {
                par = "پارکینگ دارد"
            }
            if (res[item].Balcony == 1) {
                bal = "بالکن دارد"
            }
            if (res[item].Elevator == 1) {
                ele = "آسانسور دارد"
            }
            if (res[item].Store == 1) {
                sto = "انباری دارد"
            }

            $("#resaults").append(

                "<div class='col - lg - 4' data-aos='fade - up' data-aos-delay='100'>" +
                "<div class='pricing - item'>" +
                "<h3>" + res[item].Title + "</h3>" +
                "<h4>" + res[item].City + "/" + res[item].Neighborhood + "</h4>" +
                +"<ul>" +
                "<li><i class='bi bi - check'></i>" + " قیمت " + res[item].Price + "</li>" +
                "<li><i class='bi bi - check'></i>" + "متراژ" + res[item].Size + "</li>" +
                "<li><i class='bi bi - check'></i>" + "سن" + res[item].Age + "</li>" +
                "<li class='na'><i class='bi bi - x'></i> <span>" + "تعداد اتاق" + res[item].RoomNum + "</span></li>" +
                "<li class='na'><i class='bi bi - x'></i> <span>" + "کاربری" + res[item].Usage + "</span></li>" +
                "<li class='na'><i class='bi bi - x'></i> " + par + "/" + ele + "/" + bal + "/" + sto + "</li>" +
                "</ul>" +
                "<a href='' class='buy - btn'>" + خرید + "</a>" +
                "</div>" +
                "</div>"
            )
        }

        $("#addsession").modal('show');
    })

        .fail(function () {


        })
        .always(function () {

        });


}

function searching2() {
    var place = $("#place2").val();
    alert(place);
    $.post("/Home/filter2", { place: place })

        .done(function (res) {
            for (var item in res) {

                $("#resaults").append(

                    "<div class='col - lg - 4' data-aos='fade - up' data-aos-delay='100'>" +
                    "<div class='pricing - item'>" +
                    "<h3>" + res[item].Title + "</h3>" +
                    "<h4>" + res[item].City + "/" + res[item].Neighborhood + "</h4>" +
                    +"<ul>" +
                    "<li><i class='bi bi - check'></i>" + " قیمت " + res[item].Price + "</li>" +
                    "<li><i class='bi bi - check'></i>" + "متراژ" + res[item].Size + "</li>" +
                    "<li><i class='bi bi - check'></i>" + "سن" + res[item].Age + "</li>" +
                    "<li class='na'><i class='bi bi - x'></i> <span>" + "تعداد اتاق" + res[item].RoomNum + "</span></li>" +
                    "<li class='na'><i class='bi bi - x'></i> <span>" + "کاربری" + res[item].Usage + "</span></li>" +
                    "<li class='na'><i class='bi bi - x'></i> " + par + "/" + ele + "/" + bal + "/" + sto + "</li>" +
                    "</ul>" +
                    "<a href='' class='buy - btn'>" + خرید + "</a>" +
                    "</div>" +
                    "</div>"
                )
            }


        })
        .fail(function () {
            alert("خطا در برقراری ارتباط با سرور");
        })
        .always(function () {

        });

}


$(document).ready(function () {
    alert("ss")
    $.post("/Home/getAgencies")

        .done(function (res) {

            $("#Agancies").empty();

            for (var item in res) {

                $("#Agancies").append(

                    "<div class='swiper-slide'>" +
                    '<div class="testimonial-item">' +
                    '<img src="" class="testimonial-img" alt="">' +
                    '<h3>' + res[item].AgancyName + '</h3>' +
                    '<h4>' + res[item].AcancyPhone + '</h4>' +
                    '<h5>' + res[item].ManagerName + '</h5>' +
                    '<div class="stars">' +

                    '</div>' +
                    "<a href='' class='buy - btn'  id='Ag_" + res[item].ID + "'>" + آگهی + "</a>" +
                    '</div>' +
                    '</div>' +




                    );
            }


        })

        .fail(function () {



        })

        .always(function () {


        });

});