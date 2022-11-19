class Slot extends PIXI.Graphics {

    constructor(x, y, width, height, color) {
        super();

        this.draw_self(x, y, width, height, color);
        //this.interactive = true;
        //this.on('mousedown', this.mouse_handler);
        //this.buttonMode = true;
    }

    mouse_handler() {
        console.log("here");
        //this.color = 0x01BB2F;
    }

    draw_self(x, y, width, height, color) {
        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawRect(x, y, height, width);
        this.endFill();
    }
}