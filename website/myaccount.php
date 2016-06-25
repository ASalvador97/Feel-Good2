<?php
require_once 'psl-config.php';

  if (isset($_SESSION['Email'])){
	  $email = $_SESSION['Email'];
	  $zero = 0;
	  $userquery = mysqli_query($con, "SELECT * FROM registered_user WHERE email='$email'") or die ("Could not complete query");
	  $paidquery = mysqli_query($con, "SELECT * FROM paid_visitor WHERE REGISTERED_USER_email='$email'") or die ("Could not complete query");
	  
	  
	  
	  
	  while($row = mysqli_fetch_array($paidquery, MYSQLI_ASSOC)){
		  
	    $barcode= $row['barcode'];
		$balance= $row['balance_left'];
		$registeredemail = $row['REGISTERED_USER_email'];
		$eventid = $row['EVENt_event-id'];
	  
	  
	  }
	  
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
  
	

//check if person is in paid_visitor, if he is, hide the div to buy tickets. if he is not, hide the div saying "you already have tickets"
$sql = "Select * from paid_visitor where REGISTERED_USER_email = '$dbemail'";
  
  $result = $con->query($sql);
  if($result->num_rows > 0)
{
?>
<style>.buyticket{
display:none;
}</style>
<?php
}
else {
?>
<style>.ticketdone{
display:none;
}</style>
<?php
}

$sql = "Select * from campingspot_member where PAID_VISITOR_REGISTERED_USER_email = '$dbemail'";
  
  $result = $con->query($sql);
  if($result->num_rows > 0)
{
?>
<style>.selectcamping{
display:none;
}</style>
<?php
}
else {
?>
<style>.campingdone{
display:none;
}</style>
<?php
}
		  
		  

include_once("header.php");
?>
<script type="text/javascript">
function openTab(evt, tabName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the link that opened the tab
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active";
}
</script>

<html>
<body>
 <div class="foot" align="right">
  <?php include_once("footer.php");?></div>

<div class="general">
<ul class="tab">
    <body onload="openTab(event, 'userinfo')">
  <li><a href="#" class="tablinks" onclick="openTab(event, 'userinfo')">User Info</a></li>
  <li><a href="#" class="tablinks" onclick="openTab(event, 'tickets')">Tickets</a></li>
  <li><a href="#" class="tablinks" onclick="openTab(event, 'camping')">Camping</a></li>
</ul>
   <style type="text/css">  
        td {
            font-family: Arial;
            color: #FFF5EE;
        }
    </style>
	

   <div class="tabcontent" id="userinfo">
   <div class="userinfo" >
	<form name="user" action="" onsubmit="return validateForm()" method="post" >
	  <h3>  Hello <?php echo $fname ?> <?php echo $lname ?>!</h3>
    <table width="45%" border="0" align="left" cellpadding="10" cellspacing="0"  >
        
	  <tr><td> Email:</td><td><?php echo $dbemail; ?></td></tr>
	  <tr><td> Phone Number:</td><td><?php echo $phone; ?></td></tr>
	  <tr><td> Gender:</td><td><?php echo $gender; ?></td></tr>
	  <tr><td> Country:</td><td><?php echo $country; ?></td></tr>
	  <tr><td> City:</td><td><?php echo $city; ?></td></tr><br><br>	  
	  <tr><td> Ticket #:</td><td><IMG src= https://www.barcodesinc.com/generator_files/image.php?code=<?php echo $barcode; ?>&style=197&type=C128B&width=200&height=50&xres=1&font=3'></td></tr>
	  
	  </table></form>
	  
	 
	
	
	<div class="update">
	<form  action="update_balance.php" method="POST" >
<table width="45%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="left">
		
                    <h3>UPDATE YOUR EVENT-BALANCE HERE</h3>
					<h4>Note that you can NOT update your balance before buying the ticket. Updating your balance is necessary to book your camping 
(one person books for everyone on same campingspot) and it will save time getting started on the event (buying food, lending items etc).</h4>
					<h3>Your current balance is: </h3><?php echo $balance?>  Euros	
                    <h4>Available options are PayPal and IDeal.</h4> 
					
				
	    </div>
    </td>
  </tr>

  <tr>
    <td><div align="left">Update balance with (Euro):</div></td>
    <td><input type="text" name="balance" /></td>
  </tr>
  
  <tr>
    <td><div align="left">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  
  
  <tr>
    <td><div align="left"></div></td>
    <td><input name="update" type="submit" value="Update Balance" /></td>
  </tr>
</table>
</form></div>
	
	</div></div>
	
	
	
<div class="tabcontent" id="tickets">
<div class="buyticket" id="buyticket">
<form name="buyticket" action="buyticket.php" onsubmit="return validateForm()" method="post" >
<table width="40%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="left">
		<h3>Buy your ticket here! </h3>	<br>
        <h3>Ticket price: 60 euro for the whole event.</h3>
        <h4>More information available at <a href="info.php">Info</a></h4>  
				
	    </div>
    </td>
  </tr>
  
  <tr>
    <td><div align="left">Choose payment method: <br></div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="left"></div></td>
    <td><input name="buyticket" type="submit" value="Continue buying ticket" /></td>
  </tr>
</table>
</form></div>



<div class="ticketdone" id="ticketdone">
<form name="ticketdone" action="" onsubmit="return validateForm()" method="post" >
<table width="80%" border="0" align="center" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h2>You have booked your ticket! </h2>	<br>
		<p>When you come to the event, you have to bring the confirmation with you. It means you must show your 
		"User info" page with barcode and other information at the gates (printed page, screenshot on device, or straight from the page). You will receive a bracelet which will be used throughout the event. </h4>
		<br>
		<h4>It is your own responsibility to keep your barcode and confirmation page safe from being used/duplicated by other people! </p><br><br>
		              	
			<IMG src= https://www.barcodesinc.com/generator_files/image.php?code=<?php echo $barcode; ?>&style=197&type=C128B&width=200&height=50&xres=1&font=3'>
				
	    </div>
		</tr>
    
</table>
</form>
</div></div>  




<div class="tabcontent" id="camping">
<div class="selectcamping" id="selectcamping">
<form name="selectcamping" action="selectcamping.php" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="left">
		<h3>Choose your campingspot! </h3>	<br>
                    <h3>Maximum amount of people for one campingspot is 6.</h3>
                    <h4>Price is 30 euro for camping spot and 20 euro for every additional person. <br>
					All users must be previously registered and have bought a ticket. Tents etc. are not provided by us.</h4>  
				
	    </div>
    </td>
  </tr>

   <tr>
    <td><div>Select campingspot:</div></td>
    <td><select name="formSpot">
		<?php 
		$sql = mysqli_query($con,"SELECT campingspot_nr FROM campingspot WHERE nr_of_members=0");
		while ($row = mysqli_fetch_array($sql, MYSQLI_ASSOC)){
		echo "<option value=" . $row['campingspot_nr'] . ">" . $row['campingspot_nr'] . "</option>";
		}
		?>
	</select></td>
	</tr>
	
	
  
  
  <tr>
    <td><div align="left">Add other members <br> who belong to <br> the camping spot:</div></td>
    <td>
	<input type="text" name="member1" value="<?php echo $dbemail; ?>" readonly /><br><br>
	<input type="text" name="member2" placeholder="member 2"/><br><br>
	<input type="text" name="member3" placeholder="member 3"/><br><br>
	<input type="text" name="member4" placeholder="member 4"/><br><br>
	<input type="text" name="member5" placeholder="member 5"/><br><br>
	<input type="text" name="member6" placeholder="member 6"/><br><br>
  </td>
  </tr>
  
  <tr>
    <td><div align="left">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="left"></div></td>
    <td><input name="payforspot" type="submit" value="Book your campingspot" /></td>
  </tr>
</table>
</form>
</div>


<div class="campingdone" id="campingdone">
<form name="campingdone" action="" onsubmit="return validateForm()" method="post" >
<table width="80%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		
		<?php 
		$sql = mysqli_query($con,"SELECT CAMPINGSPOT_campingspot_nr FROM campingspot_member WHERE PAID_VISITOR_REGISTERED_USER_email='$dbemail'");
		while ($row = mysqli_fetch_array($sql, MYSQLI_ASSOC)){
			$campnumber = $row['CAMPINGSPOT_campingspot_nr'];
			
		$sql = mysqli_query($con,"SELECT nr_of_members FROM campingspot WHERE campingspot_nr ='$campnumber'");
		while ($row = mysqli_fetch_array($sql, MYSQLI_ASSOC)){
			$membernumber = $row['nr_of_members'];
		
		$sql = mysqli_query($con,"SELECT PAID_VISITOR_REGISTERED_USER_email FROM campingspot_member WHERE CAMPINGSPOT_campingspot_nr ='$campnumber'");
		while ($row = mysqli_fetch_array($sql, MYSQLI_ASSOC)){
			$members = $row['PAID_VISITOR_REGISTERED_USER_email'];
			
		
		
			
			
		
		}
		}
		}
		
		?>
		
		<table width="80%" border="0" align="center" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
                    <h3>CAMPINGSPOT INFORMATION</h3>   
<p>At the entrance you will receive a bracelet which will allow you to enter campingarea.</p>					
        </div>
		
    </td>
  </tr>

  <tr>
    <td><div align="left">Number of people in campingspot (incl You):</div></td>
    <td><?php echo $membernumber?></td>
  </tr>

  <tr>
    <td><div align="left">Campingspot number:</div></td>
    <td><?php echo $campnumber ?></td>
  </tr>
  <tr>
  <td>Your camping members are:</td>
  <td><?php foreach ($sql as $row) 
        { 
            foreach ($row as $members)
            {
                echo $members."<br>";
            }
        } ?></td>
  </tr>
		
	 
              	
	    </div>

    
</table>
</form>
</div></div>



</div>
	
	
		
</body>

</html>

<?php
  } else header("Location: Index.php");  
  
		  
?>
