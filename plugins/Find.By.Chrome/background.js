var isRunning = false;

function updateIcon() {
  isRunning = !isRunning;
  chrome.browserAction.setIcon({path: isRunning? "./img/iconOn.png" : "./img/iconOff.png"});
}

function startingListener() {
  setInterval(function(){
    if(!isRunning) return;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "http://localhost:32081/", false);
    xhr.send();
    var result = xhr.responseText;
    chrome.tabs.query({currentWindow: true}, function(tabs) {
      for (var i = 0; i < tabs.length; i++) {
        chrome.tabs.sendMessage(tabs[i].id, {locator: result, isRunning: isRunning});
      }      
    });
  }, 100);
}

chrome.browserAction.onClicked.addListener(updateIcon);
startingListener();