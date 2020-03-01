# 批量硬盘脱机 跳过指定硬盘

# 硬盘数量
$diskNum=8

# 硬盘序列号
$diskSN = "WD-WCC4M7XFSU0P"
# 正则表达式
$pattern = "\d"

# 遍历本机全部硬盘的信息
$diskInfo = Get-WmiObject Win32_PhysicalMedia
foreach($n in $diskInfo){
#$n["SerialNumber"]
if($n["SerialNumber"].Contains($diskSN)){
    $diskTagString = $n["Tag"]
    }
}

# 正则匹配获得磁盘号
$diskTagString -match $pattern
$diskTagNumber = [Int32]($Matches.Values | Out-String)

$diskTagNumber.GetType().Name


# 操作diskpart
for($i=0;$i -le $diskNum;$i++){
    if($i -ne $diskTagNumber){
        $selectDisk = "select disk x" -replace "x", $i
        $selectDisk, "offline disk" | diskpart
        }
}

# 设置电源管理
& "powercfg" -x disk-timeout-ac 1
& "powercfg" -x disk-timeout-dc 1