using UnityEngine;

public class AlarmLigtController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100;

    private void Update()
    {
        transform.RotateAround
        (
            transform.position,
            Vector3.back,
            rotationSpeed * Time.deltaTime
        );
    }
}