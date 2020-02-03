var ReadMeModalShow = false;
window.ReadMeModal = () => {
    if (ReadMeModalShow) {
        ReadMeModalShow = false;
        return true;
    }
    return false;
}
$(document).on('hide.bs.modal', '#readMe', () => {
    ReadMeModalShow = true;
})

window.CreateProfile = () => {
    var profile = $('#profile').clone();
    profile.removeAttr('hidden');
    return profile.prop('outerHTML');
}