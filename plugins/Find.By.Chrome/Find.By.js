chrome.runtime.onMessage.addListener(
  function(request) {
    if(request.isRunning){
        showLocator(request.locator);
    }else {
        removeHighlighting();
    }
  }
);

$(document).ready(function() {
	addLocatorClass();
});

function addLocatorClass() {
	$("<style type='text/css'>.locator{ outline:2px dashed blue;}</style>").appendTo("head");
}

function showLocator(data) {
    var responce = $.parseJSON(data);
    if(responce.Status=="Ok"){
        removeHighlighting();
        addHighlighting(responce);
    }	
}

function addHighlighting(locator) {
	switch(locator.By) {
		case "ClassName":
			var className = "."+locator.Value;
    		HighlightJQuery(className);
        	break;
        case "CssSelector":
        	HighlightJQuery(locator.Value);
        	break;
        case "Id":
    		var id = "#"+locator.Value;
    		HighlightJQuery(id);
        	break;
        case "LinkText":
        	var linkText = "//a[text()='".concat(locator.Value, "']");
        	HighlightXPath(linkText);
        	break;
        case "Name":
        	var name = "[name='".concat(locator.Value, "']");
        	HighlightJQuery(name);
        	break;
        case "PartialLinkText":
        	var link = "a:contains('" + locator.Value + "')";
        	HighlightJQuery(link);
          	break;
        case "TagName":
        	HighlightJQuery(locator.Value);
        	break;
    	case "XPath":
    		HighlightXPath(locator.Value);
        	break;
	}
}

function HighlightJQuery(jquery) {
	$(jquery).each(function() {
		$(this).addClass('locator'); 
	});
}

function HighlightXPath(xpath) {
	$(document).xpath(xpath).each(function() {
		$(this).addClass('locator'); 
	});
}

function removeHighlighting() {
	$(".locator").each(function() {
		$(this).removeClass('locator'); 
	});
}
// Google Analytics
 (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-70310002-2', 'auto');
  ga('send', 'pageview');
