
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    const string FRIENDLY = "friendly";
    const string FINISH = "finish";

    private void OnCollisionEnter(Collision collision)


    {
        //if (!new[] { FINISH, FRIENDLY }.Contains(collision.gameObject.tag))  SceneManager.LoadScene(currentScene);

        if (!collision.gameObject.CompareTag(FINISH) && !collision.gameObject.CompareTag(FRIENDLY)) reloadScene();
    }


    private void reloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
