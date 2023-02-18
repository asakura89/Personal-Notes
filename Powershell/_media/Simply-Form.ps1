Clear-Host

Add-Type -AssemblyName PresentationFramework

$grid = New-Object Windows.Controls.Grid
$grid.Margin = New-Object System.Windows.Thickness 10

$row1 = New-Object Windows.Controls.RowDefinition
$row2 = New-Object Windows.Controls.RowDefinition
$row1.Height = "70"
$row2.Height = "100*"
$grid.RowDefinitions.Add($row1)
$grid.RowDefinitions.Add($row2)

$label = New-Object System.Windows.Controls.Label
$label.Content = "Test Label"
$label.HorizontalAlignment = [System.Windows.HorizontalAlignment]::Right
$label.VerticalAlignment = [System.Windows.VerticalAlignment]::Center
$label.Margin = New-Object System.Windows.Thickness 5
[System.Windows.Controls.Grid]::SetRow($label, $row)
[System.Windows.Controls.Grid]::SetColumn($label, 0)
[void]$grid.Children.Add($label)


$window = New-Object System.Windows.Window
$window.Title = "Hello"
$window.Height = "748"
$window.Width = "1424"
$window.WindowStartupLocation = "CenterScreen"
$window.Content = $grid


If ($psISE -Eq $null) {
    $app = New-Object System.Windows.Application 
    $app.Run($window)
}
Else {
    [void]$window.ShowDialog()
}