using UnityEditor;
using UnityEngine.UI;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

public static class ToolsMenu
{
    [MenuItem("Tools/Setup/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        CreateDirectories("_Project", "Scripts", "Art", "Scenes");
        Refresh();
    }

    public static void CreateDirectories(string root, params string[] dir)
    {
        var fullpath = Combine(dataPath, root);
        foreach (var newDirectory in dir)
        {
            CreateDirectory(Combine(fullpath, newDirectory));
        }
    }
}