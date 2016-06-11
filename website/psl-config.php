<?php
/**
 * These are the database login details
 */  
 session_start();
$dbHOST="athena01.fhict.local";     // The host you want to connect to.
$dbUSER="dbi338468";    // The database username. 
$dbPASSWORD= "Xm6y5xuH99";    // The database password. 
$dbDATABASE="dbi338468";    // The database name.
 


$con = mysqli_connect($dbHOST, $dbUSER, $dbPASSWORD, $dbDATABASE);

if (mysqli_connect_error())
{
	echo "Failed to connect" . mysqli_connect_error();
}

?>