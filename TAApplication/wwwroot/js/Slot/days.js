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
 *   This file adds all business days for a week to the top of the Pixi canvas
 */

class Days extends PIXI.Graphics {
    //Constructs object and draws days
    constructor() {
        super();

        this.draw_self();
    }

    //Draws all days at top of canvas
    draw_self() {
        const monday = this.addChild(
            new PIXI.Text("Monday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        monday.x = 25;
        monday.y = 25

        const tuesday = this.addChild(
            new PIXI.Text("Tuesday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        tuesday.x = 200;
        tuesday.y = 25


        const wednesday = this.addChild(
            new PIXI.Text("Wednesday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        wednesday.x = 375;
        wednesday.y = 25

        const thursday = this.addChild(
            new PIXI.Text("Thursday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        thursday.x = 550;
        thursday.y = 25

        const friday = this.addChild(
            new PIXI.Text("Friday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        friday.x = 725;
        friday.y = 25

        const time = this.addChild(
            new PIXI.Text("Time", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xA2A4A4,
                align: "center"
            })
        );
        time.x = 900;
        time.y = 25
    }
}