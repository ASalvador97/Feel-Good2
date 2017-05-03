<html>
<body>
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
  
	  
	  $spot = $_POST['formSpot'];
	  $member1 = $_POST['member1'];
	  $member2 = $_POST['member2'];
	  $member3 = $_POST['member3'];
	  $member4 = $_POST['member4'];
	  $member5 = $_POST['member5'];
	  $member6 = $_POST['member6'];
	  
	  $array = array($member1, $member2, $member3, $member4, $member5, $member6);
	  
	  
	  
	  $count = count(array_filter($array));
	  
	  $newbalance = $balance - 20*$count - 30; 
	  
	
	  $checkemail =mysqli_query($con, "Select * from paid_visitor where REGISTERED_USER_email = '$member1' OR REGISTERED_USER_email ='$member2' OR REGISTERED_USER_email ='$member3'OR REGISTERED_USER_email ='$member4'OR REGISTERED_USER_email ='$member5' OR REGISTERED_USER_email ='$member6'");

	  
	  
if($checkemail->num_rows < $count)
{
 echo "<script>
alert('One or more of the submitted e-mails were not found!');
window.location.href='myaccount.php';
</script>";
}

else if ($newbalance<0)
{
	echo "<script>
alert('Please update your balance to make this purchase!');
window.location.href='myaccount.php';
</script>";
}
else {	 
	  
	  $updatequery = mysqli_query($con,"UPDATE campingspot SET  nr_of_members ='$count' WHERE campingspot_nr = '$spot' ");
	  $updatebalance = mysqli_query($con,"UPDATE paid_visitor SET  balance_left ='$newbalance' WHERE REGISTERED_USER_email = '$email' ");
	  $setspots1 = mysqli_query($con,"INSERT INTO campingspot_member (CAMPINGSPOT_campingspot_nr, PAID_VISITOR_REGISTERED_USER_email, PAID_VISITOR_EVENT_event_id) VALUES ('$spot','$member1','1')");
	  $setspots2 = mysqli_query($con,"INSERT INTO campingspot_member (CAMPINGSPOT_campingspot_nr, PAID_VISITOR_REGISTERED_USER_email, PAID_VISITOR_EVENT_event_id) VALUES('$spot','$member2','1')");
	  $setspots3 = mysqli_query($con,"INSERT INTO campingspot_member (CAMPINGSPOT_campingspot_nr, PAID_VISITOR_REGISTERED_USER_email, PAID_VISITOR_EVENT_event_id) VALUES('$spot','$member3','1')");
	  $setspots4 = mysqli_query($con,"INSERT INTO campingspot_member (CAMPINGSPOT_campingspot_nr, PAID_VISITOR_REGISTERED_USER_email, PAID_VISITOR_EVENT_event_id) VALUES('$spot','$member4','1')");
	  $setspots5 = mysqli_query($con,"INSERT INTO campingspot_member (CAMPINGSPOT_campingspot_nr, PAID_VISITOR_REGISTERED_USER_email, PAID_VISITOR_EVENT_event_id) VALUES('$spot','$member5','1')");
	  $setspots6 = mysqli_query($con,"INSERT INTO campingspot_member (CAMPINGSPOT_campingspot_nr, PAID_VISITOR_REGISTERED_USER_email, PAID_VISITOR_EVENT_event_id) VALUES('$spot','$member6','1')");
       
     
	 header("Location: myaccount.php"); 
	}
	
	 
?>
</body>
</html>