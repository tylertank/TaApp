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
 *   This file defines a Line for use in a Pixi canvas, allows for setting start postion, length and the color.
 */

class Line extends PIXI.Graphics {
    //Creates an draws this line
    constructor(x, y, length, color) {
        super();
        this.draw_self(x, y, length, color);
    }

    //Draws a line from start position, of the length and color
    draw_self(x, y, length, color) {
        this.moveTo(x, y);
        this.lineStyle(1, color);
        this.lineTo(x + length, y);
    }
}