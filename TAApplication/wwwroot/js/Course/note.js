/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      10/24/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *   This note.js file contains all contents to update notes on course objects through AJAX.
 */

$(document).ready(function () {
    $('#course_table').dataTable();
});

function Change_Note(course_id) {

    var new_note = document.getElementById("note_" + course_id).value;

    $.post(
        {
            url: "/Courses/Change_Note",
            data: { course_id: course_id, new_note: new_note }
        })
        .done(function (response) {
            window.location.reload();
            console.log("Done");
        }).catch(error => {
            window.location.reload();
            console.log("Error");
        });
}