<?php
require_once 'psl-config.php';

  if (isset($_SESSION['Email']))
  {
	  $email = $_SESSION['Email'];
  }

	$barcode = rand(11111111,99999999);    
  
	 
	
	$paidquery = mysqli_query($con,"INSERT INTO paid_visitor (barcode, balance_left, REGISTERED_USER_email, EVENT_event_id) VALUES ('$barcode', '0.00', '$email', '1');");
  
	echo "<script>
alert('Congratulations, you have booked your ticket!');
window.location.href='myaccount.php';
</script>";

	include_once("header.php");
	
	include_once("footer.php");
	
//	header("location: myaccount.php");
	
	  

?>
