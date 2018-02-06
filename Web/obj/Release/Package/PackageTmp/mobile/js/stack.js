var stackurl = new Array();
var stacktitle = new Array();
var stackurlcur = "";
var stacktitlecur = "";

function StackPush(url, title) {
    if (stackurlcur != "") {
        stackurl.push(stackurlcur);
        stacktitle.push(stacktitlecur);
    }
    stackurlcur = url;
    stacktitlecur = title;
}
function StackPop() {
    if (stackurl && stackurl.length > 0) {
        stackurlcur = stackurl.pop();
        stacktitlecur = stacktitle.pop();
        pcallhtml(stackurlcur, stacktitlecur, true);
    } else {
        window.location.reload();
    }
}