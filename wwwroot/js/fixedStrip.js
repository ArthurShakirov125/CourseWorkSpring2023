	$(function(){
		// ������ "�����", px
		let h_hght = $('.custom-navbar').outerHeight();
		// ������ ����� � ����, px
		let h_nav = $('.custom-post_strip').outerHeight();

		$(window).scroll(function(){
			// ������ ������
			let top = $(this).scrollTop();
			if (top > 0) {
				$(".custom-post_strip").css("top", "0");
			}
			if (top <= 0) {
				$(".custom-post_strip").css("top", h_hght);
			}
		});
	});		