# Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
foreach ($item in Get-ChildItem) {
    if ($item.Name -match '.*\.(json)$') {
        echo "configuration $item"
        .\CombinatorialTheoryOfNumbers.AppDotNet.exe $item "$item.csv"
    }
}