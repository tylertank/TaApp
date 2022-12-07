Highcharts.chart('EnrollmentChart', {

    title: {
        text: 'Enrollments for Courses Over Time',
        align: 'left'
    },

    yAxis: {
        title: {
            text: 'Enrollments'
        }
    },

    xAxis: {
        accessibility: {
            rangeDescription: 'Jan to Dec'
        }
    },

    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    plotOptions: {
        series: {
            label: {
                connectorAllowed: false
            },
            pointStart: 0
        }
    },

    series: [{
        name: '',
        data: []
    }],

    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom'
                }
            }
        }]
    }

});
$(function () {
    $("#startDate").datepicker();
});

$(function () {
    $("#endDate").datepicker();
});

function getData() {
    var startDate = $("#startDate").val();
    var endDate = $("#endDate").val();
    var course = $("#course").val();
    var courseInfo = course.split(" ");

    $.get(
        {
            url: "/Admin/GetEnrollmentData/",
            data: { start: startDate, end: endDate, dept: courseInfo[0], courseNum: courseInfo[1] }
        })
        .done(function (response) {
            $("#save").hide();
            console.log("Done");

            
        }).catch(error => {

            window.location.reload();
            console.log("Error");
        }).always(function () {
            $("#spinner").hide();
        });
    /*$.get("/Admin/GetEnrollmentData/", function (myList) {

        const userAvaliability = myList;
        var numOfUser = userAvaliability.length;

        for (var j = 0; j < userAvaliability.length; j++) {
            if (slots[i].ID == userAvaliability[j].time && userAvaliability[j].open) {
                slots[i].paintColor(userAvaliability[j].open);
            }
        }

    });*/
}
