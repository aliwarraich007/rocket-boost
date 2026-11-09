using UnityEngine;
using static Unity.Collections.Unicode;

public class SettingsManager : MonoBehaviour
{

    private static float Master = 1f, Sfx = 1f, Music = 1f;
    private static int Quality;
    private static bool FullScreen = true, Vsync = false;
    private static string Resolution = "";

    // Use this attribute to get a callback when the runtime is starting up and loading the first scene.
    // Runs once at startup in whatever scene you press Play from.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Boot () {
        Load();
    }

    private static void Load() {
        Master = PlayerPrefs.GetFloat("set_master", 1f);
        Sfx = PlayerPrefs.GetFloat("set_sfx", 1f);
        Music = PlayerPrefs.GetFloat("set_music", 1f);
        Quality = PlayerPrefs.GetInt("set_quality", QualitySettings.GetQualityLevel());
        FullScreen = PlayerPrefs.GetInt("set_fullscreen", 1) == 1;
        Vsync = PlayerPrefs.GetInt("set_vsync", 1) == 1;
        Resolution = PlayerPrefs.GetString("set_resolution", $"{Screen.currentResolution.width}x{Screen.currentResolution.height}");
    }

}
