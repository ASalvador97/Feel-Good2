<?php

include"psl-config.php";
$_SESSION["LoggedIn"] =0;
$_SESSION["Username"] ="";
session_destroy();
header("location: index.php");

?>