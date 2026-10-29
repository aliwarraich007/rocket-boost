using UnityEngine;

public class Oscillation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    Vector3 startPosition;
    Vector3 endPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; // current position of the game object;
        endPosition = startPosition + movementVector; // how far the object is allowed to move;
    }

    // Update is called once per frame
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        // Mathf.PingPong -> Increments and decrements a value from 0 to it's given length. for example: time -> it keeps increasing, length -> end-point. when result of pingpong reaches the given length
        // it will start decrementing from that value. (0, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0, 1, 2, 3, 4, 5 ... ) and so on.
        // formula = Pingpong(t, L) = L - | t mod 2L) - L |
        // t = time or input value
        // L = maxmium Length
        // mod = remainder operation
        // |x| = absolute value, neg becomes positive
        // 
        transform.position = Vector3.Lerp(startPosition, endPosition, movementFactor);
        // Lerp will clamp the value to stay between 0 and 1;
        // lerp formula = a + ( b - a ) x t
        // clamp formula = Clamp(x, min, max) = min(max(x, min),max)
    }
}


// 0 1 2
// 0 1 2

// 0 1 2 3 4 5 6 7 -> t
// 0 1 2 3 4 5 4 3 -> length

// 0 1 2 3 4 5 6 7 8 9 10 11
// 0 1 2 3 4 5 4 3 2 1 0 1