/*
* SimpleModal OSX Style Modal Dialog
*
* Licensed under the MIT license:
*   http://www.opensource.org/licenses/mit-license.php
*
* Revision: $Id: osx.js 238 2010-03-11 05:56:57Z emartin24 $
*/

jQuery(function ($) {
    var OSX = {
        container: null,
        init: function () {
            $("input.osx, a.osx").click(function (e) {
                e.preventDefault();

                $("#osx-modal-content").modal({
                    overlayId: 'osx-overlay',
                    containerId: 'osx-container',
                    closeHTML: null,
                    minHeight: 80,
                    opacity: 65,
                    position: ['0', ],
                    overlayClose: true,
                    onOpen: OSX.open,
                    onClose: OSX.close
                });

            });
        },

        open: function (d) {
            self.container = d.container[0];
            d.overlay.fadeIn('slow', function () {
                $("#osx-modal-content", self.container).show();

                var title = $("#osx-modal-title", self.container);
                title.show();
                d.container.slideDown('slow', function () {
                    setTimeout(function () {
                        var h = $("#osx-modal-data", self.container).height();

                        // padding
                        d.container.animate(
							{ height: h },
							200,
							function () {
							    $("div.close", self.container).show();
							    $("#osx-modal-data", self.container).show();

							}
						);
                    }, 300);

                });
            })

        },
        close: function (d) {
            var self = this; // this = SimpleModal object
            try {
                LoadFileListArray(true);
            }
            catch (e)
            { }
            d.container.animate(
				{ top: "-" + (d.container.height() + 20) },
				500,
				function () {
				    self.close(); // or $.modal.close();
				}
			);

        }
    };

    OSX.init();

});