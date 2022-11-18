class slot extends PIXI.Graphics {
    constructor(width, height, color) {
        super();

        var graphics = new PIXI.Graphics();
        this.draw_self(width, height, color, graphics);

    }

    draw_self(width, height, color, graphics) {
   
        graphics.drawRect(0, 0, width, height);
        graphics.beginFill(0xFFFF00);

    }
}