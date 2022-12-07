function getEnrollment() {
    $.get("/Admin/GetEnrollmentData/" + data, function (myList) {
  
        const userAvaliability = myList;
        var numOfUser = userAvaliability.length;
      
            for (var j = 0; j < userAvaliability.length; j++) {
                if (slots[i].ID == userAvaliability[j].time && userAvaliability[j].open) {
                    slots[i].paintColor(userAvaliability[j].open);
                }
            }
        
    });
}