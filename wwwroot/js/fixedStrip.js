	$(function(){
		// высота "шапки", px
		let h_hght = $('.custom-navbar').outerHeight();
		// высота блока с меню, px
		let h_nav = $('.custom-post_strip').outerHeight();

		$(window).scroll(function(){
			// отступ сверху
			let top = $(this).scrollTop();
			if (top > 0) {
				$(".custom-post_strip").css("top", "0");
			}
			if (top <= 0) {
				$(".custom-post_strip").css("top", h_hght);
			}
		});
	});		