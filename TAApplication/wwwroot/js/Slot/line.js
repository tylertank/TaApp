class Line extends PIXI.Graphics {

    constructor(x, y, length, color) {
        super();
        var graphics = new PIXI.Graphics();

        this.draw_self(x, y, length, color);
    }


    draw_self(x, y, length, color) {
        this.moveTo(x, y);
        this.lineStyle(1, color);
        this.lineTo(x + length, y);
    }
}