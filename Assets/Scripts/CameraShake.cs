using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance; // <-- Add this line

    public AnimationCurve curve;
    public float ShakeTime = 1f;

    private void Awake()
    {
        instance = this; // <-- Add this line
    }

    public IEnumerator Shake()
    {
        Vector3 Startposition = transform.position;
        float TimeUsed = 0f;

        while (TimeUsed < ShakeTime)
        {
            TimeUsed += Time.deltaTime;
            float strength = curve.Evaluate(TimeUsed / ShakeTime);
            transform.position = Startposition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = Startposition;
    }
}
