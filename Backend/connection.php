<?php
$ser="localhost";
$user="root";
$pass="";
$db="doctorsorders";

$con= mysqli_connect($ser, $user, $pass, $db,"3308") or die("Connection Failed");
echo "Connection Success";
?>