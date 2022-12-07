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
