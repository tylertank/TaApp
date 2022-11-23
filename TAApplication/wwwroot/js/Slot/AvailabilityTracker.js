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
 *   This file sets up a Pixi.js canvas and places it within the view, calls all other constructors to build the GUI, and required mouse events.
 */

/**
 * Global access to the PIXI Application 
 */
var app = null;

/**
 *  Create PIXI stage
 */
function setup_pixi_stage(width, height, uid) {
    app = new PIXI.Application({ backgroundColor: 0x000000 });

    app.renderer.resize(width, height);
    $("#canvas_div").append(app.view);

    var line = new Line(25, 75, 950, 0xFFFFFF);
    var days = new Days();
    var times = new Times();
    let x = 25;
     width = 850;
    let y = 112.5;
    for (let i = 0; i < 13; i++) {
        var timeline = new Line(x, y, width, 0xA2A4A4)
        y += 100;
        app.stage.addChild(timeline)
    }

    x = 25;
    width = 100;
    y = 112.5;
    var count = 0;
    for (let i = 0; i < 5; i++) {
        for (let i = 0; i < 48; i++) {
            var timeslot = new Slot(x, y, 25, width, 0xCB0000, count++);
            y += 25;
            app.stage.addChildAt(timeslot, count);
        }
        x += 175;
        y = 112.5;
    }

    app.stage.addChild(line);
    app.stage.addChild(days);
    app.stage.addChild(times);
    getAvaliability(uid);

    $($("#spinner").hide());
    $($("#save").hide());
}
