<?php
require_once 'psl-config.php';

  if (isset($_SESSION['Email']))
  {
	  $email = $_SESSION['Email'];
  }
	  
	
	 
    $result = $con->query("SELECT COUNT(*) FROM paid_visitor");
    $row = $result->fetch_row();
	
	$barcode = rand(11111111,99999999);
  

    //$barcode = rand($row[0] + 1,1000000);
  
  
	 
	
	$paidquery = mysqli_query($con,"INSERT INTO paid_visitor (barcode, balance_left, REGISTERED_USER_email, EVENT_event_id) VALUES ('$barcode', '0.00', '$email', '1');");
    echo "<script>
alert('Ticket booked!');
window.location.href='myaccount.php';
</script>";
	
	
	
	

// the message
$msg = "Hello https://www.barcodesinc.com/generator_files/image.php?code=$barcode&style=197&type=C128B&width=200&height=50&xres=1&font=3";

$sub = "Hello";
// send email
 mail($email, $sub ,$msg);



	include_once("header.php");
	
	include_once("footer.php");
	
	 
	  

?>
