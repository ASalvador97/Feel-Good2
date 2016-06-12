<?php
require_once 'psl-config.php';

  if (isset($_SESSION['Email'])){
	  $email = $_SESSION['Email'];
	  $userquery = mysqli_query($con, "SELECT * FROM registered_user WHERE email='$email'") or die ("Could not complete query");
	  
	  
	  
	  while($row = mysqli_fetch_array($userquery, MYSQLI_ASSOC)){
		  $dbemail = $row['email'];
		  $fname= $row['fname'];
		  $lname = $row['lname'];
		  $dob = $row['dob'];
		  $gender = $row['gender'];
		  $phone = $row['phone'];
          $country = $row['country'];	
          $city = $row['city'];			  
	      }
		  
		  $email     = mysql_real_escape_string($email);
	
	 
  $getpaidvisitors = mysqli_query($con,"Select count(*) as numberrows from paid_visitor") or die ("Could not complete query");
  
   while($row = mysqli_fetch_array($getpaidvisitors, MYSQLI_ASSOC)){
   $result = $row['numberrows'];}
  $barcode = $result + 1;
	
	
	$paidquery = mysqli_query($con,"INSERT INTO `dbi338468`.`paid_visitor` (`barcode`, `balance_left`, `REGISTERED_USER_email`, `EVENT_event_id`) VALUES ('$barcode', '0', '$dbemail', '1');");
    
	
	include_once("header.php");
	
	include_once("footer.php");
    }
	  }

?>
