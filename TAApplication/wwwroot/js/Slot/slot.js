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
 *   This file defines a Slot for use in a Pixi canvas, a slot stores if it is selected or not by the applicant. Includes listener to
 *   set if it is selected, and change it's color. 
 */

class Slot extends PIXI.Graphics {

    //Creates a new slot, and stores all storing information onto the object
    constructor(x, y, width, height, color, ID) {
        super();
        this.saved_x = x;
        this.saved_y = y;
        this.ID = ID;
        this.saved_width = width;
        this.saved_height = height;
        this.saved_color = color;
        this.avaliable = false;
        this.draw_self(x, y, width, height, color);
        this.interactive = true;
        this.on('mousedown', this.mouse_handler);
        this.buttonMode = true;
    }

    //Updates the color and open of this slot
    mouse_handler() {
        $("#save").show();
        this.changeColor();
    }

    //Paints the proper color based on if it is open or not
    paintColor(open) {
        if (open) {
            this.saved_color = 0x01BB2F
            this.avaliable = true;
            this.lineStyle(1, this.saved_color);
            this.beginFill(this.saved_color);
            this.drawRect(this.saved_x, this.saved_y, this.saved_height, this.saved_width);
            this.endFill();
        }
    }

    //Changes the color, and modifies the availability member variable
    changeColor() {
        //Now unavailable, make red
        if (this.avaliable) {
     
            this.saved_color = 0xCB0000;
            this.avaliable = false;
        }
        else {
  
            this.saved_color = 0x01BB2F
            this.avaliable = true;
        }
        this.lineStyle(1, this.saved_color);
        this.beginFill(this.saved_color);
        this.drawRect(this.saved_x, this.saved_y, this.saved_height, this.saved_width);
        this.endFill();
    }

    //Draws this slot onto a canvas
    draw_self(x, y, width, height, color) {
        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawRect(x, y, height, width);
        this.endFill();
    }
}
