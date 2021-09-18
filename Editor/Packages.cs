using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public static class Packages
{

    public static async Task ReplacePackagesFromGist(string id, string user = "psarras")
    {
        var url = GetGistUrl(id, user);
        var contents = await GetContents(url);
        if(contents != null) ReplacePackageFile(contents);
    }
    
    
    public static string GetGistUrl(string id, string user = "psarras") =>
        $"https://gist.github.com/{user}/{id}/raw";

    public static async Task<string> GetContents(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        Debug.LogError($"Couldn't find file: {response.StatusCode}");
        return null;
    }

    public static void ReplacePackageFile(string contents)
    {
        var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json"); //../Packages/manifest.json
        File.WriteAllText(existing, contents);
        Client.Resolve();
    }

    public static void InstallUnityPackage(string package)
    {
        Client.Add($"com.unity.{package}");
        Client.Resolve();
    }
}