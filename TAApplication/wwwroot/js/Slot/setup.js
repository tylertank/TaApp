﻿
/**
 * Global access to the PIXI Application 
 */
var app = null;

/**
 *  Create PIXI stage
 */
function setup_pixi_stage(width, height) {
    app = new PIXI.Application({ backgroundColor: 0x000000 });
    app.renderer.resize(width, height);
    $("#canvas_div").append(app.view);
    
}
