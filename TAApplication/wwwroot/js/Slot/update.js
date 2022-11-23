/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      11/22/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *   This file defines methods to retrieve and update an applicants availability. Retrieves from the web server endpoint set up in
 *   the corresponding controller.
 */

//Retrieves the availability of the input student
function getAvaliability(data) {
    $.get("/Avaliability/GetSchedule/"+data, function (myList) {
        const slots = app.stage.children;
        const userAvaliability = myList;
        var numOfUser = userAvaliability.length;
        for (var i = 0; i < slots.length; i++) {
            for (var j = 0; j < userAvaliability.length; j++) {
                if (slots[i].ID == userAvaliability[j].time && userAvaliability[j].open) {
                    slots[i].paintColor(userAvaliability[j].open);
                }
            }
        }
    });
}

//Connects to server endpoint, and passes updated list of availability
function setAvaliability(data) {
    $("#spinner").show();

    const slots = app.stage.children;
    const test = data;
    const slotInfo = [];
    for (var i = 1; i < 241; i++) {
        slotInfo.push(slots[i].avaliable);
    }

    $.post(
        {
            url: "/Avaliability/SetSchedule",
            data: { id: test, schedule: JSON.stringify(slotInfo) }
        })
        .done(function (response) {
            $("#save").hide();
            console.log("Done");
        }).catch(error => {

            window.location.reload();
            console.log("Error");
        }).always(function () {
            $("#spinner").hide();
        });;
}