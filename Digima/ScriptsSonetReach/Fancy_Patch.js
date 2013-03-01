

 			if (currentOpts.type == 'iframe') {
				$('<iframe id="fancybox-frame" name="fancybox-frame' + new Date().getTime() + '" frameborder="0" hspace="0" ' + ($.browser.msie ? 'allowtransparency="true""' : '') + ' scrolling="' + selectedOpts.scrolling + '" src="' + currentOpts.href + '"></iframe>').appendTo(content);
				if (selectedOpts && selectedOpts.showIframeLoading) {
					$.fancybox.showActivity();
				}
				$('<iframe id="fancybox-frame" name="fancybox-frame' + new Date().getTime() + '" frameborder="0" hspace="0" ' + ($.browser.msie ? 'allowtransparency="true""' : '') + ' scrolling="' + selectedOpts.scrolling + '" src="' + currentOpts.href + '"></iframe>').appendTo(content).load(function() {
					if (selectedOpts && selectedOpts.showIframeLoading) {
						$.fancybox.hideActivity();
					}
					if (selectedOpts && $.isFunction(selectedOpts.onIframeLoad)) {
						selectedOpts.onIframeLoad(selectedArray, selectedIndex, selectedOpts);
					}
				});
 			}

 			wrap.show();


 		showCloseButton	 : true,
 		showNavArrows: true,
		showIframeLoading : true,
 		enableEscapeButton : true,
 		enableKeyboardNav : true,

 		onStart : function(){},
 		onCancel : function(){},
 		onComplete : function(){},
		onIframeLoad : function(){},
 		onCleanup : function(){},
 		onClosed : function(){},
 		onError : function(){}

}
