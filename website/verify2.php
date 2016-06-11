<?php
 require_once 'psl-config.php'; 


  $user_email = mysqli_real_escape_string($con, $_POST['Email']);
  $user_password = mysqli_real_escape_string($con, $_POST['Password']);

  $sql = "Select password from registered_user where email = '$user_email'";
  
  $result = $con->query($sql);
  if($result->num_rows > 0) {
	  while($row = $result->fetch_assoc()) {
		  $hashed_pass = $row["password"];
		  
	  }
  }
  if(password_verify($user_password, $hashed_pass)) {
	  $_SESSION["LoggedIn"] = 1;
	  $_SESSION["Username"] = $user_email;
	   header("Location: myaccount.php"); 
  }

  else echo "Couldnt log in"; 
 

?>