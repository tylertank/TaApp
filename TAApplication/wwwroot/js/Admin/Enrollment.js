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
 *   This file creates a line chart using highcharts, and defines a method to add data to it based on user inputs within
 *   the view that calls this js file.
 */


$($("#spinner").hide());

//Sets up the line chart
const chart = Highcharts.chart('EnrollmentChart', {

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
})

//jQuery data picker
$(function () {
    $("#startDate").datepicker();
});

//jQuery data picker

$(function () {
    $("#endDate").datepicker();
});

//Pulls defined user input data from database, and adds to start, controls spinner
function getData() {
    $("#spinner").show();
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
            const dataarrEnrollmentsOnly = Array(response.length);
            for (let i = 0; i < response.length; i++){
                var datevar = new Date(response[i].enrolledTime)
                const subarr = [datevar, response[i].enrollment];
                dataarr[i] = subarr;
                dataarrEnrollmentsOnly[i] = response[i].enrollment;
            }
            
            $("#EnrollmentChart").highcharts().addSeries({
                name: course,
                data: dataarrEnrollmentsOnly,
                pointInterval: 24 * 3600 * 1000,
                pointStart: Date.UTC(dataarr[0][0].getFullYear(), dataarr[0][0].getMonth(), dataarr[0][0].getDate())
            });

        }).catch(error => {
            window.location.reload();
            console.log("Error");
        }).always(function () {
            $("#spinner").hide();
        });
}
