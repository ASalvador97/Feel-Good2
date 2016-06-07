<!DOCTYPE html>
<?php include_once("header.php");?>
<div class="general">
    <div class="tickets">
    <style type="text/css">  
        td {
            font-family: Arial;
            color: #FFF5EE;
        }
    </style>
   
         
        <form name="reg" action="registrationcode.php" onsubmit="return validateForm()" method="post" >
<table width="50%" border="0" align="left" cellpadding="10" cellspacing="0"  >
  <tr>
    <td colspan="2">
		<div align="center">
                    <h3>REGISTER HERE AND BE A PART OF OUR EVENT!</h3>
                    <h4>You can buy tickets and book a campingspot after registration.</h4>        
	    </div>
    </td>
  </tr>

  <tr>
    <td><div align="right">First Name*:</div></td>
    <td><input type="text" name="fname" /></td>
  </tr>

  <tr>
    <td><div align="right">Last Name*:</div></td>
    <td><input type="text" name="lname" /></td>
  </tr>
  
  <tr>
  <td><div align="right">Date Of Birth*:</div></td> 
  <td><input type="date" name="dob" /></td>
  </tr>
  
 
    <tr>
        <td><div align="right">Gender*:</div></td> 
        <td><input type="text" name="gender" /></td>
    </tr>
  
 <tr>
  <td><div align="right">Phone*:</div></td> 
  <td><input type="text" name="phone" /></td>
  </tr>

 <tr>
  <td><div align="right">Country*:</div></td> 
  <td><input type="text" name="country" /></td>
  </tr>

   <tr>
  <td><div align="right">City*:</div></td> 
  <td><input type="text" name="city" /></td>
  </tr>

  <tr>
    <td><div align="right">E-mail*:</div></td>
    <td><input type="email" name="email" /></td>
  </tr>

 <tr>
    <td><div align="right">Password*:</div></td>
    <td><input type="password" name="password" /></td>
  </tr>
  
   <tr>
    <td><div align="right">Confirm password*:</div></td>
    <td><input type="password" name="cpassword" /></td>
  </tr>
  
   
  
  <tr>
    <td><div align="right"></div></td>
    <td><input name="Register" type="submit" value="Register" /></td>
  </tr>
</table>
</form>
    </div>
    
    <div class="tickets">
        
        <h4>BUYING YOUR TICKET</h4>
        <p>It is only possible to buy ticket for the whole weekend.
            <br>
            The price is 60 euros per person, after registration you will have the opportunity to pay.<br><br>
            You can pay via Internet, we have provided you with PayPal and IDeal options. If your payment has been successful you will receive a confirmation 
            on your e-mail and you will be registered to our event! </p>
        <h4>CAMPING</h4>
            <p>One campingspot can have maximum 6 people. The price is 30 euros for the campingspot and 20 euros for every person.
                You can choose your campingspot after signing in with your account - you will see free campingspots on map and you can choose the preferred one.
                <br><br>
                Note: <br>
                All campingspot members must have FeelGood account.
                Tents etc are not provided by us.</p>
        
            <h4>WHY DO I HAVE TO REGISTER?</h4>
            <p> You can use your FeelGood account to buy tickets for other events organised by us! </p>
       
    </div>
    </div>

