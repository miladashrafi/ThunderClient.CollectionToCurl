using System.Text.Json;
using System.Text.RegularExpressions;
using StringSanitizer.StringSanitizer;
using ThunderClient.CollectionToCurl;

Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("Welcome to Thunder Client Collection to Curl Tool.");
WriteSuccess("Please press any key to start processing.");
Console.ReadKey();
try
{
    DoWork();
}
catch (CustomException e) when (e.Type is CustomExceptionType.Warning)
{
    WriteWarning(e.Message);
}
catch (CustomException e) when (e.Type is CustomExceptionType.Exception)
{
    WriteError(e.Message);
}
catch (Exception e)
{
    WriteError(e.Message);
}
finally
{
    WriteWarning("Click any key to exit ...");
    Console.ReadKey();
}

void DoWork()
{
    var di = new DirectoryInfo("Collections");

    if (di.Exists is false)
        throw new CustomException(CustomExceptionType.Warning,
            "\"Collections\" folder not found!\nPlease create a new folder in root with name of Collections and move your collection json files there.");

    var exportDi = new DirectoryInfo($"Export_{DateTime.Now:yyyyMMdd-HHmmss}");
    if (exportDi.Exists is false)
        exportDi.Create();

    var files = di.GetFiles("*.json");
    if (files.Any() is false)
        throw new CustomException(CustomExceptionType.Warning, "There is no file in Collections folder");

    var models = new List<Collection>();
    foreach (var file in files)
    {
        var json = File.ReadAllText(file.FullName);
        try
        {
            var fileModel = JsonSerializer.Deserialize<Collection>(json);
            fileModel.FileName = FinalizeFileName(GetFirst50Chars(Path.GetFileNameWithoutExtension(file.Name)));
            models.Add(fileModel);
        }
        catch (Exception)
        {
            throw new CustomException(CustomExceptionType.Exception,
                $"file with name {file.Name} is not well-formed as a collection.");
        }
    }

    var curlBaseTemplate = @"curl -X {0} \
                          '{1}' \
                          {2} \
                          {3}"; 
    
    foreach (var model in models)
    {
        var collectionPath = Path.Combine(exportDi.FullName, model.FileName, FinalizeFileName(GetFirst50Chars(model.CollectionName.SanitizeNonAlphanumeric())));
        var collectionDi = new DirectoryInfo(collectionPath);
        if (collectionDi.Exists is false)
            collectionDi.Create();
        var index = 1;
        foreach (var request in model.Requests)
        {
            var requestPath = Path.Combine(collectionPath, FinalizeFileName(GetFirst50Chars(request.Name.SanitizeNonAlphanumeric(replacement: "-")) ?? request.Id) + ".txt");

            if (File.Exists(requestPath))
            {
                requestPath = Path.Combine(collectionPath, FinalizeFileName(GetFirst50Chars(request.Name.SanitizeNonAlphanumeric(replacement: "-")) ?? request.Id) + $"_{index}.txt");
            }
            
            if (request.Body?.Form?.Any() is true)
            {
                WriteWarning($"Form body is not supported yet for {model.CollectionName} {request.Name}");
                continue;
            }
                
            var headerStringWriter = new StringWriter();
            foreach (var header in request.Headers)
                headerStringWriter.WriteLine($"--header '{header.Name}: {header.Value}' \\");

            string body = null;
            if (request.Body is not null)
                body = $"--data-raw '{request.Body?.Raw}'";
            
            var curl = string.Format(curlBaseTemplate, request.Method, request.Url, headerStringWriter, body);
            
            File.WriteAllText(requestPath, curl);
            WriteSuccess($"Request {Path.GetFileNameWithoutExtension(requestPath)} successfully converted to curl.");
        }
    }
    
    WriteSuccess("Finished!");
}

void WriteError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine(message);
}

void WriteSuccess(string message)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Error.WriteLine(message);
}

void WriteWarning(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Error.WriteLine(message);
}

string GetFirst50Chars(string input)
{
    if (input is null)
        return null;

    if (input.Length <= 50)
        return input;

    return input.Substring(0, 50);
}

string FinalizeFileName(string input)
{
    if (input is null)
        return null;

    var reducedString = Regex.Replace(input, "-+", "-");
    var finalString = reducedString.Trim('-');
    return finalString;
}