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

        type: "datetime",
        labels: {
            formatter: function () {
                return Highcharts.dateFormat('%m-%d-%Y', this.value);
            }
        },
        
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
            const dataarr = Array(response.length);
            for (let i = 0; i < response.length; i++){
                var datevar = new Date(response[i].enrolledTime)
                const subarr = [datevar, response[i].enrollment];
                dataarr[i] = subarr;
            }
            $("#EnrollmentChart").highcharts().addSeries({
                name: course,
                data: dataarr
            });
            
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
