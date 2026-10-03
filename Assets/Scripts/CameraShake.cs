using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 10f;

    // A measure of magnitude for the shake. Tweak based on your preference
    [SerializeField] private float shakeMagnitude = 0;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;
    private bool isShaking = false;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.GetComponent<Transform>();
        initialPosition = transform.position;
    }

    void Update() 
    {
        if (isShaking == true)
            transform.position = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    }

    public void ShakeWrapper() 
    {
        StartCoroutine(ShakeCam());
    }

    private IEnumerator ShakeCam() 
    {
        isShaking = true;
        yield return new WaitForSeconds(0.5f);
        isShaking = false;
        transform.position = initialPosition;
    }
}
