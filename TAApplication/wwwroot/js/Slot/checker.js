

/**
 *  Create a Checker Object
 */
class Checker extends PIXI.Graphics {

    constructor(radius, color) {
        super();

        this.draw_self(radius, color);
        this.interactive = true;
        this.on('mousedown', this.center);
        this.buttonMode = true;
    }

    center() {
        console.log("here");
        this.x = 200;
        this.y = 200;
    }

    draw_self(radius, color) {
        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawCircle(0, 0, radius);
        this.endFill();
    }
}





