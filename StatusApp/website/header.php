<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css" href="design.css">
<?php 
require_once 'psl-config.php'?>
<title>FeelGood Event</title>
<link rel="shortcut icon" href="icon.jpg">
</head>
<body>
<div class="nav">
<ul>
	<li><a href="index.php">HOME</a></li>
	<li><a href="program.php">PROGRAM</a></li>
<?php
	if(empty($_SESSION["LoggedIn"]) || empty($_SESSION["Email"])) {
		echo
		'
		<li><a href="tickets.php">TICKETS & CAMPING</a></li>
		
		';
	} ?>
	
	
	<li><a href="info.php">INFO</a></li>
	<li><a href="workshops.php">WORKSHOPS</a></li>
	<li><a href="gallery.php">GALLERY</a></li>
	
	<?php
	if(empty($_SESSION["LoggedIn"]) || empty($_SESSION["Email"])) {
		echo
		'
		<li><a href="login.php">LOG IN</a></li>
		
		';
	} 
	
	else 
	{
		echo 
		'
		<li><a href="myaccount.php">MY ACCOUNT</a></li>
		<li><a href="logout.php">LOG OUT</a></li>
		
		';
	}
 ?>
</ul>
</div>
