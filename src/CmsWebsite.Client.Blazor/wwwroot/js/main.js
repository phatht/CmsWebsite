function loadZaloDSK() {
    ZaloSocialSDK.reload();
}
//---------------------------------------------------------------------------------------
function loadVideo() {
    document.getElementById("videoArticle").load();
}
//---------------------------------------------------------------------------------------
function focusSearch() {
    document.getElementById("txtSearch").focus();
}
//---------------------------------------------------------------------------------------
let scrollButton = document.getElementById("btnScroll");
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        scrollButton.style.display = "block";
    } else {
        scrollButton.style.display = "none";
    }
}
function onScrollEvent() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}