using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 2000;
    [SerializeField] float rotationStrength = 70f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;


    Rigidbody rb;
    AudioSource audioSource;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        Propell();
        Rotate();
        audioSource.playOnAwake = false;
    }

    void Propell()
    {
        if (thrust.IsPressed())
        {
            // adds force relative to position, rotation of the object;
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if (!audioSource.isPlaying) audioSource.PlayOneShot(mainEngine);
            if (!mainEngineParticles.isPlaying)
                mainEngineParticles.Play();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    void Rotate()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0) RotateRight();
        else if (rotationInput > 0) RotateLeft();
        else StopRotation();
    }


    private void RotateRight()
    {
        ApplyRotation(rotationStrength);
        if (!rightEngineParticles.isPlaying)
        {
            leftEngineParticles.Stop();
            rightEngineParticles.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationStrength * -1);
        if (!leftEngineParticles.isPlaying)
        {
            rightEngineParticles.Stop();
            leftEngineParticles.Play();
        }
    }

    private void StopRotation()
    {
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationThisFrame * Time.fixedDeltaTime * Vector3.forward);
        rb.freezeRotation = false;

    }
}
