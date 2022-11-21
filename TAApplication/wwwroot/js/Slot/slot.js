class Slot extends PIXI.Graphics {

    constructor(x, y, width, height, color, ID) {
        super();
        this.saved_x = x;
        this.saved_y = y;
        this.ID = ID;
        this.saved_width = width;
        this.saved_height = height;
        this.saved_color = color;

        this.draw_self(x, y, width, height, color);
        this.interactive = true;
        this.on('mousedown', this.mouse_handler);
        this.buttonMode = true;
    }

    mouse_handler() {
        this.changeColor();
    }
    changeColor() {
        console.log(this.ID);
        if (this.saved_color == 0x01BB2F) {
            this.saved_color = 0xCB0000;
        }
        else {
            this.saved_color = 0x01BB2F
        }
        this.lineStyle(1, this.saved_color);
        this.beginFill(this.saved_color);
        this.drawRect(this.saved_x, this.saved_y, this.saved_height, this.saved_width);
        this.endFill();
    }

    draw_self(x, y, width, height, color) {
        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawRect(x, y, height, width);
        this.endFill();
    }
}
   function changeColorArr(item, index, arr) {
        console.log(item.ID);
        if (item.saved_color == 0x01BB2F) {
            item.saved_color = 0xCB0000;
        }
        else {
            item.saved_color = 0x01BB2F
        }
        item.lineStyle(1, item.saved_color);
        item.beginFill(item.saved_color);
        item.drawRect(item.saved_x, item.saved_y, item.saved_height, item.saved_width);
        item.endFill();
    }