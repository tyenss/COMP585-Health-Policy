<?php
$ser="localhost";
$user="root";
$pass="";
$db="doctorsorders";

$con= mysqli_connect($ser, $user, $pass, $db,"3308") or die("Connection Failed");
echo "Connection Successful";

$insertqueue= "INSERT INTO test(name) VALUES(1)";
mysqli_query($con, $insertqueue)  or die("failure to insert patient");
  

?>