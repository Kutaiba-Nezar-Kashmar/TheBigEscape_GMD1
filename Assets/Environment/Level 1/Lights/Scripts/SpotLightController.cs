using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment.Level_1.Lights.Scripts
{
    public class SpotLightController : MonoBehaviour
    {
        [SerializeField] private bool isFlicker = false;
        private float timer;
        private Light _light;

        private void Start()
        {
            _light = gameObject.GetComponent<Light>();
        }

        private void Update()
        {
            if (!isFlicker)
            {
                StartCoroutine(FlickerLight());
            }
        }

        /**
        * Wait for time intervals to switch the lights on and off.
        */
        private IEnumerator FlickerLight()
        {
            isFlicker = true;
            _light.enabled = false;
            timer = Random.Range(1f, 4f);
            yield return new WaitForSeconds(timer);
            _light.enabled = true;
            timer = Random.Range(1f, 4f);
            yield return new WaitForSeconds(timer);
            isFlicker = false;
        }
    }
}