var isRunning = false;

function updateIcon() {
  isRunning = !isRunning;
  chrome.browserAction.setIcon({ path: isRunning ? "./img/iconOn.png" : "./img/iconOff.png" });
  if (!isRunning) turnOffAllTabs();
}

function turnOffAllTabs() {
  chrome.tabs.query({ currentWindow: true }, function (tabs) {
    for (var i = 0; i < tabs.length; i++) {
      chrome.tabs.sendMessage(tabs[i].id, { locator: null, isRunning: isRunning });
    }
  });
}

function showNumberOfLocators(message) {
  chrome.browserAction.setBadgeText({ text: message.number });
}

function startingListener() {
  setInterval(function () {
    if (!isRunning) return;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "http://localhost:32081/", false);
    xhr.send();
    var result = xhr.responseText;
    if (!isRunning) turnOffAllTabs();
    chrome.tabs.query({ currentWindow: true, active: true }, function (tabs) {
      chrome.tabs.sendMessage(tabs[0].id, { locator: result, isRunning: isRunning }, showNumberOfLocators);
    });
  }, 100);
}
chrome.browserAction.setBadgeBackgroundColor({ color: [0, 200, 0, 120] });
chrome.browserAction.onClicked.addListener(updateIcon);
startingListener();
