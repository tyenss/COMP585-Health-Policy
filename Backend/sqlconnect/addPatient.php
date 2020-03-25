<?php
$ser="localhost";
$user="root";
$pass="";
$db="doctorsorders";

$con= mysqli_connect($ser, $user, $pass, $db,"3308") or die("Connection Failed");
echo "Patient added successfully";


$doc= $$_POST["doctor_id"];
$pat= $$_POST["patient_id"];

$insertqueue= "INSERT INTO queue(doctor_id, patient_id) VALUES('$doc','$pat')";


mysqli_query($con, $insertqueue)  or die("failure to insert patient");

?>