function AckAttendance() {
    var options = document.getElementsByName("IsAttending");
    var userChoice = GetSelection(options);
    document.getElementById("AttendanceMessage").innerText = (userChoice.value === "True") ? "" : "We're sorry you can't make it this year.";

    partyDatesElement = document.getElementById("available-party-dates");
    if (userChoice.value === "True") {
        partyDatesElement.classList.remove("available-party-dates-hidden");
        partyDatesElement.classList.add("available-party-dates-shown");
    }
    else {
        partyDatesElement.classList.remove("available-party-dates-shown");
        partyDatesElement.classList.add("available-party-dates-hidden");
    }

}

function GetSelection(optionElements) {
    for (var i = 0; i < optionElements.length; i++) {
        if (optionElements[i].checked) { return optionElements[i]; }
    }
}