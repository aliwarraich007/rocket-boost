using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class UiHandler : MonoBehaviour
{
    private PanelRenderer panelRenderer;
    private void Awake()
    {
        Debug.Log("SCRIPT HAS LOADED");
        panelRenderer = GetComponent<PanelRenderer>();
        panelRenderer.RegisterUIReloadCallback(OnUiReload);
    }

    private void OnDestroy()
    {
        if(panelRenderer != null)
        {
            panelRenderer.UnregisterUIReloadCallback(OnUiReload);
        }
    }

    private void OnUiReload(PanelRenderer panelRenderer, VisualElement root, int version)
    {
        Button playButton = root.Q<Button>("launch-btn");

        if(playButton == null)
        {
            Debug.Log("Could not find the play button");
            return;
        }

        playButton.RegisterCallback<ClickEvent>(OnPlayClicked);

     }

    private void OnPlayClicked(ClickEvent click)
    {
        Debug.Log("btn was clicked");
        SceneManager.LoadScene(1);
    }
}
