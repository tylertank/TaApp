/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      12/8/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *   This file creates a pie chart using highcharts, and defines a method to add data to it based on user inputs within
 *   the view that calls this js file.
 */

$($("#spinner").hide());

//Constructs the pie chart
const chart = Highcharts.chart('EnrollmentPie', {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: 'Total Enrollment of Courses As of Today'
    },
    tooltip: {
          pointFormat: '<b>{point.name}</b>: {point.y}'

    },
    accessibility: {
        point: {
            valueSuffix: '%'
        }
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: true,
                format: '<b>{point.name}</b>: {point.y}'
            }
        }
    },
    series: [{
        name: 'Courses',
        colorByPoint: true,
        data: []
    }]
});

//Adds data to the pie chart, and controls the spinner
function getData() {
    $("#spinner").show();
    var endDate = $("#endDate").val();
    var course = $("#course").val();
    var courseInfo = course.split(" ");

    $.get(
        {
            url: "/Admin/GetEnrollmentDataPie/",
            data: { today: endDate, dept: courseInfo[0], courseNum: courseInfo[1] }
        })
        .done(function (response) {
            chart.series[0].addPoint({
                name: course,
                y: response[0].enrollment
            });
        }).catch(error => {
            window.location.reload();
            console.log("Error");
        }).always(function () {
            $("#spinner").hide();
        });
}
