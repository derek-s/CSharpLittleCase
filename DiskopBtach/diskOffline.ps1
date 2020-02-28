$diskNum=8
for($i=0;$i -le $diskNum;$i++){
    $selectDisk = "select disk x" -replace "x", $i
    $selectDisk, "offline disk" | diskpart
}

& "powercfg" -x disk-timeout-ac 1
& "powercfg" -x disk-timeout-dc 1