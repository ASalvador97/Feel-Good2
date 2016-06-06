<?php
$servername = "athena01.fhict.local";
$username = "dbi338468";
$password = "Xm6y5xuH99";
$dbname = "dbi338468";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	
	    // insert a row
    $fname = $_POST['fname'];
    $lname = $_POST['lname'];
    $dob =$_POST['dob'];
    $gender = $_POST['gender'];
    $phone = $_POST['phone'];
    $country =  $_POST['country'];
    $city =$_POST['city'];
    $email =  $_POST['email'];
    $passwordd =$_POST['password'];
	$cpasswordd =$_POST['cpassword'];
    
	if($passwordd==$cpasswordd){
    // prepare sql and bind parameters
    $stmt = $conn->prepare("insert into `registered_user` (`fname`, `lname`, `dob`,`gender`,`phone`,`country`,`city`,`email`,`password`) values ('$fname','$lname','$dob','$gender','$phone','$country','$city','$email','$passwordd')");
    $stmt->execute();
	echo "<div class=general><p>Congrats man, you are registered</p></div>";}
	
	else {
		
		$message = "passwords do not match";
echo "<script type='text/javascript'>alert('$message');</script>";

	}
	

	include_once("header.php");
	
	include_once("footer.php");
    }
catch(PDOException $e)
    {
    echo "Error: " . $e->getMessage();
    }
$conn = null;
?>