/*class Slot extends PIXI.Graphics {
    constructor(width, height, color) {
        super();

        var graphics = new PIXI.Graphics();
        this.draw_self(width, height, color, graphics);
        this.interactive = true;
        this.on('mousedown', this.center);
        this.buttonMode = true;
    }

    draw_self(width, height, color, graphics) {
        console.log("draw_self");
        graphics.drawRect(0, 0, width, height);
        graphics.beginFill(0xFFFF00);

    }

    center() {
        
        this.x = 200;
        this.y = 200;
    }
}*/
/**
 *  Create a Checker Object
 */
class Slot extends PIXI.Graphics {

    constructor(width, height, color) {
        super();
        var graphics = new PIXI.Graphics();

        this.draw_self(width, height, color);
        this.interactive = true;
        this.on('mousedown', this.center);
        this.buttonMode = true;


    }

    center() {
        console.log("here");
        this.x = 200;
        this.y = 200;
    }

    draw_self(width, height, color) {
        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawRect(0, 0, height, width);
        this.endFill();
    }
}