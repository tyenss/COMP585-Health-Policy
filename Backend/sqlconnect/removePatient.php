<?php
$ser="localhost";
$user="root";
$pass="";
$db="doctorsorders";

$con= mysqli_connect($ser, $user, $pass, $db,"3308") or die("Connection Failed");
echo "Connection Successful";

$removequeue= "DELETE FROM test WHERE id ='8'";
mysqli_query($con, $removequeue)  or die("failure to delete patient");
  

?>