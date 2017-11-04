<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HospitalManagementSystem.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Main</title>
<!-- for-mobile-apps -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Medi Cure Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- //for-mobile-apps -->
<link href="Resources/css/bootstraps.css" rel="stylesheet" type="text/css" media="all" />
<link href="Resources/css/styles.css" rel="stylesheet" type="text/css" media="all" />
<!-- toggle menu links -->
<link href="Resources/css/component.css" rel="stylesheet" type="text/css"  />
<!-- //menu links -->
<link href="Resources/css/popuo-box.css" rel="stylesheet" type="text/css" media="all"/>
<!-- effect9 links -->
<link href="Resources/css/ihover.css" rel="stylesheet" media="all">
<link rel="stylesheet" href="css/swipebox.css">
<!-- js -->
<script src="js/jquery-1.11.1.min.js"></script>
<!-- //js -->
<link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css'>
	<!-- start-smoth-scrolling -->
		<script type="text/javascript" src="js/move-top.js"></script>
		<script type="text/javascript" src="js/easing.js"></script>
		<script type="text/javascript">
		    jQuery(document).ready(function ($) {
		        $(".scroll").click(function (event) {
		            event.preventDefault();
		            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
		        });
		    });
		</script>
	<!-- start-smoth-scrolling -->
</head>
<body class="cbp-spmenu-push">
       <!--top-header-->
		<!--bottom-->
		
<!-- banner -->
<div class="banner page-head">
	<div class="logo">
		<h1><a href="index.html">Hospital Management Systems</a></h1>
	</div>
	<script src="js/jquery.magnific-popup.js" type="text/javascript"></script>
		<div id="small-dialog" class="mfp-hide">
			<div class="search-top">
				<div class="login">
					<input type="submit" value="">
					<input type="text" value="Type something..." onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '';}">		
				</div>			
			</div>
			<script>
			    $(document).ready(function () {
			        $('.popup-with-zoom-anim').magnificPopup({
			            type: 'inline',
			            fixedContentPos: false,
			            fixedBgPos: true,
			            overflowY: 'auto',
			            closeBtnInside: true,
			            preloader: false,
			            midClick: true,
			            removalDelay: 300,
			            mainClass: 'my-mfp-zoom-in'
			        });

			    });
			</script>				
		</div>
	
</div>
<!-- //banner -->
<!--gallery-starts--> 
<div class="treatments">
	<div class="container">	
			<script src="js/jquery.swipebox.min.js"></script> 
			<script type="text/javascript">
			    jQuery(function ($) {
			        $(".swipebox").swipebox();
			    });
			</script>
				<div class="view view-sixth">
                    <a href="Employee/Emp_Reg.aspx" title="EMPLOYEE MANGEMENT"><img src="Resources/images/em.png" alt="" >
                        <a href="Employee.aspx"/>
                    <div class="mask">
                        <h4>EMPLOYEE MANGEMENT</h4>
                        <p>Payroll management,marking attendance, manage leaves, employee registration.</p>
                    </div></a>
                </div>
                <div class="view view-sixth">
                    <a href="images/b2.jpg" title="VEHICLE MANGEMENT"><img src="Resources/images/am.png" alt="" >
                        <a href="Vehicle.aspx"/>
                    <div class="mask">
                        <h4>VEHICLE MANGEMENT</h4>
                        <p>Managing and maintaining vehicle,ambulance services.</p>
                    </div></a>
                </div>
                <div class="view view-sixth">
                    <a href="images/b1.jpg" title="ACCOUNTS MANGEMENT"><img src="Resources/images/acc.png" alt="">
                        <a href="Account.aspx"/>
                    <div class="mask">
                        <h4>ACCOUNTS MANGEMENT</h4>
                        <p>Manage salary payments, calculate income(daily, monthly), cashier management, utility payments.</p>
                    </div></a>
                </div>
				<div class="view view-sixth">
                    <a href="images/pa.png" title="PATIENT MANGEMENT"><img src="Resources/images/pa.png" alt="">
                        <a href="frm_patient.aspx"/>
                    <div class="mask">
                        <h4>PATIENT MANGEMENT</h4>
                        <p>Handling patients, channelling, admit service.</p>
                    </div></a>
                </div>
                <div class="view view-sixth">
                    <a href="images/b4.jpg" title="PHARMACY MANGEMENT"><img src="Resources/images/pam.png" alt="">
                        <a href=""/>
                    <div class="mask">
                        <h4>PHARMACY MANGEMENT</h4>
                        <p>Issuing drugs and maintaining stock.</p>
                    </div></a>
                </div>
				<div class="view view-sixth">
                    <a href="images/4.jpg" title="WARD & THEATER MANGEMENT"><img src="Resources/images/444.png" alt="">
                        <a href="WardManagement.aspx"/>
                    <div class="mask">
                        <h4>WARD & THEATER MANGEMENT</h4>
                        <p>Record equipment details, managing wards and theatres.</p>
                    </div></a>
                </div>
				<div class="view view-sixth">
                    <a href="images/444.jpg" title="LABORATORY MANGEMENT"><img src="Resources/images/b4.png" alt="">
                        <a href="Lboratory.aspx"/>
                    <div class="mask">
                        <h4>LABORATORY MANGEMENT</h4>
                        <p>Record lab tests, search test details, managing equipment.</p>
                    </div></a>
                </div>
				<div class="view view-sixth">
                    <a href="images/in.png" title="INVENTORY MANGEMENT"><img src="Resources/images/in.png" alt="" >
                        <a href="inventory.aspx"/>
                    <div class="mask">
                        <h4>INVENTORY MANGEMENT</h4>
                        <p>Store drugs, issuing drugs, ordering drugs , handling hospital equipment.</p>
                    </div></a>
                </div>
				<div class="clearfix"></div>
	</div>
</div>
<!--gallery-ends--> 

<!-- Bootstrap core JavaScript-->
    <!-- Placed at the end of the document so the pages load faster -->
	<!-- js -->
		 <script src="js/bootstrap.js"></script>
	<!-- js -->
<!-- smooth scrolling -->
	<script type="text/javascript">
	    $(document).ready(function () {
	        $().UItoTop({ easingType: 'easeOutQuart' });
	    });
	</script>
	<a href="#" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
<!-- //smooth scrolling -->
</body>
</html>
