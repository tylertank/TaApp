class Days extends PIXI.Graphics {

    constructor() {
        super();

        this.draw_self();

    }

    draw_self() {
        const monday = this.addChild(
            new PIXI.Text("Monday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        monday.x = 25;
        monday.y = 25

        const tuesday = this.addChild(
            new PIXI.Text("Tuesday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        tuesday.x = 200;
        tuesday.y = 25


        const wednesday = this.addChild(
            new PIXI.Text("Wednesday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        wednesday.x = 375;
        wednesday.y = 25

        const thursday = this.addChild(
            new PIXI.Text("Thursday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        thursday.x = 550;
        thursday.y = 25

        const friday = this.addChild(
            new PIXI.Text("Friday", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xffffff,
                align: "center"
            })
        );
        friday.x = 725;
        friday.y = 25

        const time = this.addChild(
            new PIXI.Text("Time", {
                fontSize: 24,
                lineHeight: 28,
                letterSpacing: 0,
                fill: 0xA2A4A4,
                align: "center"
            })
        );
        time.x = 900;
        time.y = 25
    }
}