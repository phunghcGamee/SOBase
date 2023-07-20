#if UNITY_EDITOR
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace PancakeEditor
{
    public static class MenuSceneItemCreator
    {
        [MenuItem("Tools/Open Scene/Launcher", priority = 500), UsedImplicitly]
        private static void OpenLauncherScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) EditorSceneManager.OpenScene("Assets/_Root/Scenes/[C] launcher.unity");
        }

        [MenuItem("Tools/Open Scene/Persistent", priority = 501), UsedImplicitly]
        private static void OpenPersistentScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) EditorSceneManager.OpenScene("Assets/_Root/Scenes/[C] persistent.unity");
        }

        [MenuItem("Tools/Open Scene/Menu", priority = 502), UsedImplicitly]
        private static void OpenMenuScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) EditorSceneManager.OpenScene("Assets/_Root/Scenes/[C] menu.unity");
        }

        [MenuItem("Tools/Open Scene/Gameplay", priority = 503), UsedImplicitly]
        private static void OpenGameplayScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) EditorSceneManager.OpenScene("Assets/_Root/Scenes/[C] gameplay.unity");
        }
        
        [MenuItem("Tools/Open Scene/Editor", priority = 504), UsedImplicitly]
        private static void OpenEditorScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) EditorSceneManager.OpenScene("Assets/_Root/Scenes/[C] editor.unity");
        }
    }
}
#endif