$diskNum=8
for($i=0;$i -le $diskNum;$i++){
    $selectDisk = "select disk x" -replace "x", $i
    $selectDisk, "online disk" | diskpart
}

& "powercfg" -x disk-timeout-ac 0
& "powercfg" -x disk-timeout-dc 0