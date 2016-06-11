<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css" href="design.css">
<title>FeelGood Event</title>
</head>
<body>
<div class="nav">
<ul>
	<li><a href="index.php">HOME</a></li>
	<li><a href="program.php">PROGRAM</a></li>
	
	<?php
	if(empty($_SESSION["LoggedIn"]) || empty($_SESSION["Username"])) {
		echo
		'
		<a href="login.php"><id="login">Sign in</a>
		
		';
	} 
	
	else 
	{
		echo 
		'
		<a href="logout.php"><id="logout">Log out</a>
		';
	}
 ?>
 
	<li><a href="tickets.php">TICKETS & CAMPING</a></li>
	<li><a href="info.php">INFO</a></li>
	<li><a href="workshops.php">WORKSHOPS</a></li>
	<li><a href="gallery.php">GALLERY</a></li>
	<li><a href="login.php">LOG IN</a></li>
</ul>
</div>
