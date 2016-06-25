<?php
require_once 'psl-config.php'; 
include_once("header.php");
include_once("footer.php");

if  (isset($_SESSION['Email']))
	{
	  $email = $_SESSION['Email'];
	}
	
$paidquery = mysqli_query($con, "SELECT * FROM paid_visitor WHERE REGISTERED_USER_email='$email'") or die ("Could not complete query");

while($row = mysqli_fetch_array($paidquery, MYSQLI_ASSOC)){
		  
	    $barcode= $row['barcode'];
		$balance= $row['balance_left'];
		$registeredemail = $row['REGISTERED_USER_email'];
		$eventid = $row['EVENt_event-id'];
	  
	  
	  }
  
	  
	  $newbalance = $_POST['balance'];
	  $summed = $balance+$newbalance;
	  
	   
	  
	  $updatequery = mysqli_query($con,"UPDATE paid_visitor SET  balance_left ='$summed' WHERE REGISTERED_USER_email = '$email' ");
       
     header("location: myaccount.php");
?>