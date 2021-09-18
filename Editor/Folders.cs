using System.IO;
using UnityEngine;

public static class Folders
{
    public static void CreateDirectories(string root, params string[] dir)
    {
        var fullpath = Path.Combine(Application.dataPath, root);
        foreach (var newDirectory in dir)
        {
            Directory.CreateDirectory(Path.Combine(fullpath, newDirectory));
        }
    }
}