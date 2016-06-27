// <?php
// require_once 'psl-config.php'; 

// include_once("header.php");
	
	// include_once("footer.php");
	
 // // Required field names
// $required = array('fname', 'lname', 'dob', 'formgender', 'password', 'email','country', 'phone', 'city', 'cpassword');

// // Loop over field names, make sure each one exists and is not empty
// $error = false;
// foreach($required as $field) 
// {
  // if (empty($_POST[$field])) 
  // {
    // $error = true;
  // }
// }
// if ($error) 
  // {
  // echo "<script>
// alert('You must fill in all fields!');
// window.location.href='tickets.php';
// </script>";
  // }  
  // else{

    
	    
    // $fname = $_POST['fname'];
    // $lname = $_POST['lname'];
    // $dob =$_POST['dob'];
    // $gender = $_POST['formgender'];
	// $password =password_hash(mysqli_real_escape_string($con,$_POST['password']), PASSWORD_BCRYPT);
	// $cpassword =password_hash(mysqli_real_escape_string($con,$_POST['cpassword']), PASSWORD_BCRYPT);
	// $email =  $_POST['email'];
	// $country =  $_POST['country'];
    // $phone = $_POST['phone'];    
    // $city =$_POST['city'];
    
   
	
    // $checkemail =mysqli_query($con, "Select * from registered_user where email = '$email'");

// if($checkemail->num_rows !=0)
// {
// echo "<script>
// alert('E-mail already exists!');
// window.location.href='tickets.php';
// </script>";
// }
// else if (password_verify($password, $cpassword)){
	
	// echo "<script type='text/javascript'>alert('Passwords do not match');
	// window.location.href='tickets.php';
	// </script>";
    
                                  // }
								  
// else {
	// // prepare sql and bind parameters
    // $registerquery = mysqli_query($con,"INSERT INTO registered_user (fname, lname, dob,gender,password,email,country,phone,city) VALUES	 ('$fname','$lname','$dob','$gender','$password','$email','$country','$phone','$city')");
    
	// echo "<div class=general><p>Congrats man, you are registered</p></div>";
	
// }
	
	
	

	
    
	  // }

// ?>
<?php
require_once 'psl-config.php'; 

include_once("header.php");
	
	include_once("footer.php");
	
 // Required field names
$required = array('fname', 'lname', 'dob', 'formgender', 'password', 'email','country', 'phone', 'city', 'cpassword');

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
  echo "<script>
alert('You must fill in all fields!');
window.location.href='tickets.php';
</script>";
  }  
  else{

    
	    
    $fname = $_POST['fname'];
    $lname = $_POST['lname'];
    $dob =$_POST['dob'];
    $gender = $_POST['formgender'];
	$password =password_hash(mysqli_real_escape_string($con,$_POST['password']), PASSWORD_BCRYPT);
	$passwordd = $_POST['password'];
	$cpassword =password_hash(mysqli_real_escape_string($con,$_POST['cpassword']), PASSWORD_BCRYPT);
	$email =  $_POST['email'];
	$country =  $_POST['country'];
    $phone = $_POST['phone'];    
    $city =$_POST['city'];
    
   
	
    $checkemail =mysqli_query($con, "Select * from registered_user where email = '$email'");

if($checkemail->num_rows !=0)
{
echo "<script>
alert('E-mail already exists!');
window.location.href='tickets.php';
</script>";
}
else if (password_verify($passwordd, $cpassword)){
	
	$registerquery = mysqli_query($con,"INSERT INTO registered_user (fname, lname, dob,gender,password,email,country,phone,city) VALUES	 ('$fname','$lname','$dob','$gender','$password','$email','$country','$phone','$city')");
    
	echo "<script>
window.location.href='login.php';
</script>";
	
    
                                  }
								  
else {
	// prepare sql and bind parameters
	
	echo "<script type='text/javascript'>alert('Passwords do not match');
	window.location.href='tickets.php';
	</script>";	
     }
	
	

	
    
	  }

?>