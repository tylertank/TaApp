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
 *   This file creates a Times object, which draws all times vertically down right side of the canvas
 */

class Times extends PIXI.Graphics {
    //Constructs object and draws
    constructor() {
        super();

        this.draw_self();
    }

    //Draws all times along right side of canvas
    draw_self() {
        const eightam = this.addChild(
            new PIXI.Text("8:00 am", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        eightam.x = 900;
        eightam.y = 100

        const nineam = this.addChild(
            new PIXI.Text("9:00 am", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        nineam.x = 900;
        nineam.y = 200

        const tenam = this.addChild(
            new PIXI.Text("10:00 am", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        tenam.x = 900;
        tenam.y = 300

        const elevenam = this.addChild(
            new PIXI.Text("11:00 am", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        elevenam.x = 900;
        elevenam.y = 400

        const noon = this.addChild(
            new PIXI.Text("12:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        noon.x = 900;
        noon.y = 500

        const onepm = this.addChild(
            new PIXI.Text("1:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        onepm.x = 900;
        onepm.y = 600

        const twopm = this.addChild(
            new PIXI.Text("2:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        twopm.x = 900;
        twopm.y = 700

        const threepm = this.addChild(
            new PIXI.Text("3:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        threepm.x = 900;
        threepm.y = 800

        const fourpm = this.addChild(
            new PIXI.Text("4:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        fourpm.x = 900;
        fourpm.y = 900

        const fivepm = this.addChild(
            new PIXI.Text("5:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        fivepm.x = 900;
        fivepm.y = 1000

        const sixpm = this.addChild(
            new PIXI.Text("6:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        sixpm.x = 900;
        sixpm.y = 1100

        const sevenpm = this.addChild(
            new PIXI.Text("7:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        sevenpm.x = 900;
        sevenpm.y = 1200

        const eightpm = this.addChild(
            new PIXI.Text("8:00 pm", {
                fontSize: 18,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        eightpm.x = 900;
        eightpm.y = 1300
    }
}