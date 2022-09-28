/*< !--
    Author:    Cole Hanlon
Partner:   Tyler Harkness
Date: 9 / 27 / 2022
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.

    I, Cole Hanlon & Tyler Harkness, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.Any references used in the completion of the assignment are cited in my README file.

  File Contents

     This roles.js file contains all contents to change the roles for a given user, and render the role_table with better styling.
-->*/
$(document).ready(function () {
    $('#roles_table').dataTable();
});


function Change_Role(user_id, role) {
    $.post(
        {
            url: "/Admin/Change_Role",
            data: { user_id: user_id, role: role }
        })
        .done(function (response) {
            console.log("Done");
        }).catch(error => {
            window.location.reload();
            console.log("Error");
        });
}