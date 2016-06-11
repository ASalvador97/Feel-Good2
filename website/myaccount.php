<?php
require_once 'psl-config.php';

if(empty ($_SESSION['LoggedIn']))
    header("Location: index.php");

include_once("header.php");
?>

<div>
button shouls say sign out

</div>