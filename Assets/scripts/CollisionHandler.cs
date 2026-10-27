
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisionHandler : MonoBehaviour
{
    const string FRIENDLY = "friendly";
    const string FINISH = "finish";
    [SerializeField] float loadDelay = 2f;
    // Movement movement;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    AudioSource audioSource;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool isControllable = true;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable) return;
        switch (collision.gameObject.tag)
        {
            case FRIENDLY:

                break;
            case FINISH:
                StartSuccessSequence();
                break;

            default:
                StartCrashMethodSequence();
                break;
        }
        //if (!new[] { FINISH, FRIENDLY }.Contains(collision.gameObject.tag))  SceneManager.LoadScene(currentScene);
        //if (!collision.gameObject.CompareTag(FINISH) && !collision.gameObject.CompareTag(FRIENDLY)) reloadScene();
    }
    private void StartCrashMethodSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", loadDelay);
    }

    private void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", loadDelay);
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
