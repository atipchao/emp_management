function ConfirmDelete(uniqueId, isDeleteClicked) {

    //console.log('Hit click');
    //console.log(uniqueId);
    //console.log(isDeleteClicked);
    var DeleteSpan = 'DeleteSpan_' + uniqueId;
    var ConfirmDeleteSpan = 'ConfirmDeleteSpan_' + uniqueId;
    if (isDeleteClicked) {
        console.log('Hide Delete');
        $('#' + DeleteSpan).hide();
        $('#' + ConfirmDeleteSpan).show();
    } else {
        console.log('Hide Confirm');
        $('#' + DeleteSpan).show();
        $('#' + ConfirmDeleteSpan).hide();
    }
}