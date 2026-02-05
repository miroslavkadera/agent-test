var webHostConfig = WebApplication.CreateBuilder(args);
var serverInstance = webHostConfig.Build();

serverInstance.MapGet("/", () => 
{
    var currentMoment = DateTime.Now;
    var formattedTimestamp = currentMoment.ToString("MMMM dd, yyyy");
    
    var htmlContent = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Welcome Page</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #f0f0f0;
        }}
        .container {{
            text-align: center;
            padding: 40px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        }}
        h1 {{
            color: #333;
            margin-bottom: 20px;
        }}
        .timestamp {{
            color: #666;
            font-size: 18px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>Hello World</h1>
        <div class='timestamp'>Today is: {formattedTimestamp}</div>
    </div>
</body>
</html>";
    
    return Results.Content(htmlContent, "text/html");
});

serverInstance.Run();
