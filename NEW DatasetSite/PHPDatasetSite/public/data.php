<!DOCTYPE html>
<html lang="en">
<head>
    Dataset Index
</head>
<body class="bginfo">
    <?php
    include_once 'public/header.php';
    ?>

    <div class="container-fluid col-md-10 offset-md-1">
        <div class="row">
            <div class="card mt-3 px-2 py-2">
                

                
                <?php
                print <<< HERE
                    <table border = "1">
                    <tr>
                        <th>Offence</th>
                        <th>2003</tr>
                        <th>2004</tr>
                        <th>2005</tr>
                        <th>2006</tr>
                        <th>2007</tr>
                        <th>2008</tr>
                        <th>2009</tr>
                        <th>2010</tr>
                        <th>2011</tr>
                        <th>2012</tr>
                        <th>2013</tr>
                        <th>2014</tr>
                        <th>2015</tr>
                    </tr>
                HERE;

                $data = file("resources_26904f63-e13a-450c-85c7-954b66229871_summary-of-all-offences-2003-2015.csv");
                $count = 0;

                foreach ($data as $line)
                {
                    $count++;
                    if ($count == 15)
                    {
                        $lineArray = explode("t", $line);
                        list($offence, $y03, $y04, $y05, $y06, $y07, $y08, $y09, $y10, $y11, $y12, $y13, $y14, $y15) = $lineArray;
                        print <<< HERE
    <tr>
    <td>$offence</td>
    <td>$y03</td>
    <td>$y04</td>
    <td>$y05</td>
    <td>$y06</td>
    <td>$y07</td>
    <td>$y08</td>
    <td>$y09</td>
    <td>$y10</td>
    <td>$y11</td>
    <td>$y12</td>
    <td>$y13</td>
    <td>$y14</td>
    <td>$y15</td>
    </tr>
HERE;
                    }
                }
                print "</table> n";
                ?>
            </div>
        </div>
    </div>

    <?php
    include_once 'public/footer.php';
    ?>
</body>
</html>