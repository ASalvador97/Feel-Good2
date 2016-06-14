<?php
require_once 'psl-config.php';

  if (isset($_SESSION['Email']))
  {
	  $email = $_SESSION['Email'];
  } 
  

  $userquery = mysqli_query($con, "SELECT campingspot_nr from campingspot where nr_of_members=0") or die ("Could not complete query");
	  while($row = mysqli_fetch_array($userquery, MYSQLI_ASSOC)){
		  $spots[]=$row;
	  }
		  
  
  
  
  
  ?>