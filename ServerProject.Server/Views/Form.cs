using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.Views
{
    public static class Form
    {
        public const string HTML = @"<!DOCTYPE html>
<html>
<head>
    <title>Simple Form</title>
</head>
<body>
    <form id=""""myForm"""" >
        <label for=""""name"""">Name:</label>
        <input type=""""text"""" id=""""name"""" name=""""name""""><br><br>
        
        <label for=""""email"""">Email:</label>
        <input type=""""email"""" id=""""email"""" name=""""email""""><br><br>
        
        <label for=""""message"""">Message:</label><br>
        <textarea id=""""message"""" name=""""message"""" rows=""""4"""" cols=""""50""""></textarea><br><br>
        
        <button type=""""submit"""">Submit</button>
    </form>
</body>
</html>"";";
    }
}