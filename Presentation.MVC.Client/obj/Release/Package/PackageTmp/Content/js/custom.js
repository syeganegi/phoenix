jQuery(document).ready(function () {
    
	/* ---------------------------------------------------------------------- */
	/*	Custom Functions
	/* ---------------------------------------------------------------------- */
	
	// Needed variables
    var $ProfileHeader = $('#profile-header');
	
    $ProfileHeader.hide();

	// Show Profile Header 
    $('#tabContact, #tabAchive, #tabStats, #tabResume, #tabPortfolio, #tabTwitWall, #tabFriendRequest').click(function () {
	    $ProfileHeader.fadeIn('slow');
	});

    // Hide Profile Header
	$('#tabProfile').click(function() {
	    $ProfileHeader.fadeOut('slow');
	});	
	
	
	/* ---------------------------------------------------------------------- */
	/*	Portfolio
	/* ---------------------------------------------------------------------- */ 
	
	// Needed variables
	var $container	 	= $('#portfolio-list');
	var $filter 		= $('#portfolio-filter');
		
	// Run Isotope  
	$container.isotope({
		filter				: '*',
		layoutMode   		: 'masonry',
		animationOptions	: {
		duration			: 750,
		easing				: 'linear'
	   }
	});	
	
	// Isotope Filter 
	$filter.find('a').click(function(){
	  var selector = $(this).attr('data-filter');
		$container.isotope({ 
		filter				: selector,
		animationOptions	: {
		duration			: 750,
		easing				: 'linear',
		queue				: false,
	   }
	  });
	  return false;
	});	
	
	// Portfolio image animation 
	$container.find('img').adipoli({
		'startEffect' 	: 'transparent',
		'hoverEffect' 	: 'boxRandom',
		'imageOpacity' 	: 0.6,
		'animSpeed' 	: 100,
	});
	
	// Copy categories to item classes
	$filter.find('a').click(function() {
		var currentOption = $(this).attr('data-filter');
		$filter.find('a').removeClass('current');
		$(this).addClass('current');
	});	
	
	/* ---------------------------------------------------------------------- */
	/*	Fancybox 
	/* ---------------------------------------------------------------------- */
	$container.find('.folio').fancybox({
		'transitionIn'		:	'elastic',
		'transitionOut'		:	'elastic',
		'speedIn'			:	200, 
		'speedOut'			:	200, 
		'overlayOpacity'	:   0.6
	});
	
	/* ---------------------------------------------------------------------- */
	/*	Contact Form
	/* ---------------------------------------------------------------------- */
	
	// Needed variables
	var $contactform 	= $('#contactform'),
		$success		= 'Your message has been sent. Thank you!';
		
	$contactform.submit(function(){
		$.ajax({
		   type: "POST",
		   url: "php/contact.php",
		   data: $(this).serialize(),
		   success: function(msg)
		   {
				if(msg == 'SEND'){
					response = '<div class="success">'+ $success +'</div>';
				}
				else{
					response = '<div class="error">'+ msg +'</div>';
				}
				// Hide any previous response text
				$(".error,.success").remove();
				// Show response message
				$contactform.prepend(response);
			}
		 });
		return false;
	});	
	
    /* ---------------------------------------------------------------------- */
    /*	Scroll Up
	/* ---------------------------------------------------------------------- */
	$(window).scroll(function () {
	    if ($(this).scrollTop() > 100) {
	        $('.scrollup').fadeIn();
	    } else {
	        $('.scrollup').fadeOut();
	    }
	});

	$('.scrollup').click(function () {
	    $("html, body").animate({ scrollTop: 0 }, 600);
	    return false;
	});
    
	$("#Righttabs").tabs();
    
    /* ---------------------------------------------------------------------- */
    /*	Sticky Adds Side Bar
	/* ---------------------------------------------------------------------- */
	
});

function resetForm($form) {
    $form.find('input:text, input:password, input:file, select, textarea').val('');
    $form.find('input:radio, input:checkbox')
         .removeAttr('checked').removeAttr('selected');
}

function onAjaxFormFaliure(ajaxContext) {
    if (xhr.status == 400) {
        alert(xhr.responseText);
    }
    else {
        alert("Server error has occured.");
    }
}
