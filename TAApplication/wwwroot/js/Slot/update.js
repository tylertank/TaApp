
function getAvaliability(data) {
    $.get("../GetSchedule/"+data, function (myList) {
        const slots = app.stage.children;
        const userAvaliability = myList;
        var numOfUser = userAvaliability.length;
        for (var i = 0; i < slots.length; i++) {
            for (var j = 0; j < userAvaliability.length; j++) {
                if (slots[i].ID == userAvaliability[j].time && userAvaliability[j].open) {
                    slots[i].paintColor(userAvaliability[j].open);
                }
            }
        }
    });
}


function setAvaliability(data) {
    const slots = app.stage.children;
    const test = data;
    const slotInfo = [];
    for (var i = 1; i < 241; i++) {
        slotInfo.push(slots[i].avaliable);
    }

   

    $.post(
        {
            url: "/Slots/SetSchedule",
            data: { id: test, schedule: JSON.stringify(slotInfo) }
        })
        .done(function (response) {
            window.location.reload();
            console.log("Done");
        }).catch(error => {
            window.location.reload();
            console.log("Error");
        });
}