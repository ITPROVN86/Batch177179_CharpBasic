$(function () {
    $('#alertBox').removeClass('hide');
    $('#alertBox').delay(5000).slideUp(500);
})
function DisplayProgressMessage(ctl, msg) {
    //if use the submit button, you can use event.preventDefault to prevent the default submit form behavior.
    event.preventDefault();
    // Turn off the "Save" button and change text
    $(ctl).prop("disabled", true).val(msg);
    // Gray out background on page
    $("body").addClass("submit-progress-bg");
    // Wrap in setTimeout so the UI can update the spinners
    $(".processing-preview").removeClass("hidden");
    //submit the form.
    setTimeout(function () {
        $("#form-search").submit();
    }, 1000);
    return true;
}
function callIndexAction(select) {
    var selectedValue = select.value;
    // Gray out background on page
    $("body").addClass("submit-progress-bg");
    // Wrap in setTimeout so the UI can update the spinners
    $(".processing-preview").removeClass("hidden");
    setTimeout(function () {
        $("#form-search").submit();
    }, 1000);
}