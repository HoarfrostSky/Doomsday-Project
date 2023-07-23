using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraNamespace
{
    public class ManageFade : MonoBehaviour
    {
        public float durationFade;

        public void FadeIn()
        {
            StartCoroutine(FadeManager(new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 0f, 0f), durationFade));
        }

        public void FadeOut()
        {
            StartCoroutine(FadeManager(new Color(0f, 0f, 0f, 0f), new Color(0f, 0f, 0f, 1f), durationFade));
        }

        IEnumerator FadeManager(Color iniColor, Color finalColor, float totalTime)
        {
            float elapsed = 0;
            while(elapsed/totalTime <= 1)
            {
                GetComponent<SpriteRenderer>().color = Color.Lerp(iniColor, finalColor, elapsed / totalTime);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
