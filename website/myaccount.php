// <?php
// require_once 'psl-config.php';

// if(empty ($_SESSION['LoggedIn']))
    // header("Location: index.php");

// include_once("header.php");
// ?>




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
   //$query = "SELECT * from paid_visitor where email='$dbemail'";
//$result = mysql_query($query);
//if(mysql_num_rows($result) == null)
	

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
		  
		  

include_once("header.php");
?>
<html>
<body>

<div class="general">
   <style type="text/css">  
        td {
            font-family: Arial;
            color: #FFF5EE;
        }
    </style>
	

   <div class="account"><center>
	<table>
        <tr><td>Hello <?php echo $fname ?> <?php echo $lname ?>!</td></tr>
		<tr><td> Email:</td><td><?php echo $dbemail; ?></td></tr>
	  <tr><td> Phone Number:</td><td><?php echo $phone; ?></td></tr>
	  <tr><td> Gender:</td><td><?php echo $gender; ?></td></tr>
	  <tr><td> Country:</td><td><?php echo $country; ?></td></tr>
	  <tr><td> City:</td><td><?php echo $city; ?></td></tr>
	  
	  </table>
	</div>
	
	
	
<div class="account">
<div class="buyticket" id=1>
<form name="buyticket" action="" onsubmit="return validateForm()" method="post" >
<table width="60%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>Buy your ticket here! </h3>	<br>
                    <h3>Ticket price: 60 eur for whole event.</h3>
                    <h4>More information available at <a href="info.php">Info</a></h4>  
				
	    </div>
    </td>
  </tr>
  
  <tr>
    <td><div align="right">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="buyticket" type="submit" value="Buy ticket" /></td>
  </tr>
</table>
</form></div>



<div class="account">
<div class="ticketdone" id=2>
<form name="ticketdone" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>You have booked your ticket! </h3>	<br>
              	
	    </div>
		</tr>
    
</table>
</form>
</div></div>
  
  
<div class="account">
<form name="updatebalance" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>Your current balance is: </h3>	<br>
                    <h3>UPDATE YOUR EVENT-BALANCE HERE</h3>
                    <h4>Available options are PayPal and IDeal.</h4>  
				
	    </div>
    </td>
  </tr>

  <tr>
    <td><div align="right">Update balance with (eur):</div></td>
    <td><input type="text" name="balance" /></td>
  </tr>
  
  <tr>
    <td><div align="right">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="update" type="submit" value="Update Balance" /></td>
  </tr>
</table>
</form></div>



<div class="account">
<div class="selectcamping" id=3>
<form name="selectcamping" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>Choose your campingspot! </h3>	<br>
                    <h3>Maximum amount of people for one campingspot is 6.</h3>
                    <h4>Price is 30 eur for campingspot and 20 eur per every person. <br>
					All users must be previously registered. Tents etc are not provided by us.</h4>  
				
	    </div>
    </td>
  </tr>

   <tr>
    <td><div align="right">Select campinspot:</div></td>
    <td><input type="number" name="noofpeople" min="1" /></td>
  </tr>
  
  <tr>
    <td><div align="right">Select number of people:</div></td>
    <td><input type="number" name="noofpeople" min="1"  max="6"/></td>
  </tr>
  
  <tr>
    <td><div align="right">Add other members who belong to the campinspot:</div></td>
    <td>
	<input type="text" name="member1" />
	<input type="text" name="member2" />
	<input type="text" name="member3" />
	<input type="text" name="member4" />
	<input type="text" name="member5" />
  </td>
  </tr>
  
  <tr>
    <td><div align="right">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="payforspot" type="submit" value="Book your campingspot" /></td>
  </tr>
</table>
</form>
</div></div>



<div class="account">
<div class="campingdone" id=4>
<form name="campingdone" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>You have booked your campingspot! </h3>	<br>
                    <h3>Number of people you wanted to share your campingspot</h3>
              	
	    </div>
<tr><ul>
<td><li></li></td>
</ul>		</tr>
    
</table>
</form>
</div></div>



</div>
	
	
		
</body>
</html>
<?php
  } else header("Location: Index.php");  
  
		  
  ?>
<!-- 


<div class="general">
<style type="text/css">  
        td {
            font-family: Arial;
            color: #FFF5EE;
        }
    </style>
	
	
	
	
	
<div class="tickets">
<form name="buyticket" action="" onsubmit="return validateForm()" method="post" >
<table width="60%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>Buy your ticket here! </h3>	<br>
                    <h3>Ticket price: 60 eur for whole event.</h3>
                    <h4>More information available at <a href="info.php">Info</a></h4>  
				
	    </div>
    </td>
  </tr>
  
  <tr>
    <td><div align="right">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="buyticket" type="submit" value="Buy ticket" /></td>
  </tr>
</table>
</form></div>



 
 
 <div class="tickets">
<form name="ticketdone" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>You have booked your ticket! </h3>	<br>
              	
	    </div>
		</tr>
    
</table>
</form>
</div>
 
  
  
  
<div class="tickets">
<form name="updatebalance" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>Your current balance is: </h3>	<br>
                    <h3>UPDATE YOUR EVENT-BALANCE HERE</h3>
                    <h4>Available options are PayPal and IDeal.</h4>  
				
	    </div>
    </td>
  </tr>

  <tr>
    <td><div align="right">Update balance with (eur):</div></td>
    <td><input type="text" name="balance" /></td>
  </tr>
  
  <tr>
    <td><div align="right">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="update" type="submit" value="Update Balance" /></td>
  </tr>
</table>
</form></div>






<div class="tickets">
<form name="selectcamping" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>Choose your campingspot! </h3>	<br>
                    <h3>Maximum amount of people for one campingspot is 6.</h3>
                    <h4>Price is 30 eur for campingspot and 20 eur per every person. <br>
					All users must be previously registered. Tents etc are not provided by us.</h4>  
				
	    </div>
    </td>
  </tr>

   <tr>
    <td><div align="right">Select campinspot:</div></td>
    <td><input type="number" name="noofpeople" min="1" /></td>
  </tr>
  
  <tr>
    <td><div align="right">Select number of people:</div></td>
    <td><input type="number" name="noofpeople" min="1"  max="6"/></td>
  </tr>
  
  <tr>
    <td><div align="right">Add other members who belong to the campinspot:</div></td>
    <td>
	<input type="text" name="member1" />
	<input type="text" name="member2" />
	<input type="text" name="member3" />
	<input type="text" name="member4" />
	<input type="text" name="member5" />
  </td>
  </tr>
  
  <tr>
    <td><div align="right">Choose payment method:</div></td>
    <td>
	<input type="radio" name="payment" value="paypal" checked> PayPal<br>
  <input type="radio" name="payment" value="ideal"> IDeal<br>
  </td>
  </tr>
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="payforspot" type="submit" value="Book your campingspot" /></td>
  </tr>
</table>
</form>
</div>





<div class="tickets">
<form name="campingdone" action="" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
		<h3>You have booked your campingspot! </h3>	<br>
                    <h3>Number of people you wanted to share your campingspot</h3>
              	
	    </div>
<tr><ul>
<td><li></li></td>
</ul>		</tr>
    
</table>
</form>
</div>



</div>-->