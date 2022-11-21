
function getAvaliability1(data) {
    $.get("../GetAvailabilities/"+data, function (myList) {
        const slots = app.stage.children;
        const userAvaliability = myList;
        var numOfUser = userAvaliability.length;
        for (var i = 0; i < slots.length; i++) {
            for (var j = 0; j < userAvaliability.length; j++) {
                if (slots[i].ID == userAvaliability[j].time && !userAvaliability[j].open) {
                    slots[i].changeColor();
                }
            }
        }
    });
}