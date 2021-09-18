using UnityEditor;
using static UnityEditor.AssetDatabase;

public static class ToolsMenu
{
    [MenuItem("Tools/Setup/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        Folders.CreateDirectories("_Project", "Scripts", "Art", "Scenes");
        Refresh();
    }

    [MenuItem("Tools/Setup/Load New Manifest")]
    static async void LoadNewManifest() =>
        await Packages.ReplacePackagesFromGist("ae79e5e1faa93d17d9585f88e5e6c206");

    [MenuItem("Tools/Setup/Packages/inputsystem")]
    static void AddPostInputsystem() => Packages.InstallUnityPackage("inputsystem");
    
    [MenuItem("Tools/Setup/Packages/Post Processing")]
    static void AddPostProcessing() => Packages.InstallUnityPackage("postprocessing");
    
    [MenuItem("Tools/Setup/Packages/Cinemachine")]
    static void AddPostCinemachine() => Packages.InstallUnityPackage("cinemachine");

}