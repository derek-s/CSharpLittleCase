$diskNum=8
for($i=0;$i -le $diskNum;$i++){
    $selectDisk = "select disk x" -replace "x", $i
    $selectDisk, "att disk clear readonly" | diskpart
}
