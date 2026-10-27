
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    const string FRIENDLY = "friendly";
    const string FINISH = "finish";



    private void OnCollisionEnter(Collision collision)


    {

        switch (collision.gameObject.tag)
        {
            case FRIENDLY:

                break;
            case FINISH:
                Debug.Log("TOUCHED");
                LoadNextScene();
                break;

            default:
                ReloadScene();
                break;
        }
        //if (!new[] { FINISH, FRIENDLY }.Contains(collision.gameObject.tag))  SceneManager.LoadScene(currentScene);
        //if (!collision.gameObject.CompareTag(FINISH) && !collision.gameObject.CompareTag(FRIENDLY)) reloadScene();
    }


    private void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(nextScene);

    }

    private void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
