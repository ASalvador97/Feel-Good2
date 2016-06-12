<?php
require_once 'psl-config.php'; 

 // Required field names
$required = array('fname', 'lname', 'dob', 'gender', 'password', 'email','country', 'phone', 'city');

// Loop over field names, make sure each one exists and is not empty
$error = false;
foreach($required as $field) 
{
  if (empty($_POST[$field])) 
  {
    $error = true;
  }
}
if ($error) 
  {
  header("location: register_error.php");
  }  
  else{

    
	    
    $fname = $_POST['fname'];
    $lname = $_POST['lname'];
    $dob =$_POST['dob'];
    $gender = $_POST['gender'];
    $phone = $_POST['phone'];
    $country =  $_POST['country'];
    $city =$_POST['city'];
    $email =  $_POST['email'];
    $passwordd =password_hash(mysqli_real_escape_string($con,$_POST['password']), PASSWORD_BCRYPT);
	
    $checkemail =mysqli_query($con, "Select * from registered_user where email = '$email'");

if($checkemail->num_rows !=0)
{
header("location: index.php");
}
else {
	
    // prepare sql and bind parameters
    $registerquery = mysqli_query($con,"INSERT INTO registered_user (fname, lname, dob,gender,phone,country,city,email,password) VALUES	 ('$fname','$lname','$dob','$gender','$phone','$country','$city','$email','$passwordd')");
    
	
	header("location: login.php");
	
	
	

	include_once("header.php");
	
	include_once("footer.php");
    }
	  }

?>