using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 1000;
    [SerializeField] float rotationStrength = 10f;
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
        propell();
        rotate();
        audioSource.playOnAwake = false;
    }

    void propell()
    {
        if (thrust.IsPressed())
        {
            // adds force relative to position, rotation of the object;
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else audioSource.Stop();
    }

    void rotate()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(rotationStrength * -1);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationThisFrame * Time.fixedDeltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }
}
