class Slot extends PIXI.Graphics {

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

    mouse_handler() {
        $("#save").show();
        this.changeColor();
    }

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
    changeColor() {
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

    draw_self(x, y, width, height, color) {
        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawRect(x, y, height, width);
        this.endFill();
    }
}
