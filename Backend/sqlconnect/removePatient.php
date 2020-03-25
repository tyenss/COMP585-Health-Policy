<?php
$ser="localhost";
$user="root";
$pass="";
$db="doctorsorders";

$con= mysqli_connect($ser, $user, $pass, $db,"3308") or die("Connection Failed");
echo "Connection Successful";

$pat= $$_POST["patient_id"];
$removequeue= "DELETE FROM queue WHERE patient_id ='$pat'";
mysqli_query($con, $removequeue)  or die("failure to delete patient");
  

?>