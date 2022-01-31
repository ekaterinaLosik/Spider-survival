using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;
public class RainManager : MonoBehaviour
{
    public AudioSource rainSound;
    public VisualEffect rainVFX;
    public VisualEffect fogVFX;

    float endFog = 300f;
    float endFogRain = 100f;

    bool isRaining = false;
    float fadingTime = 1f;
    float fogFadingTime = 3f;
    float volume = 0.5f;
    void Start()
    {
        StartCoroutine(RainCoroutine());
    }

    IEnumerator RainCoroutine()
    {
        if (!isRaining)
        {
            yield return new WaitForSeconds(Random.Range(60f, 180f));
            StartRain();
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(10f, 40f));
            StopRain();
        }
        StartCoroutine(RainCoroutine());
    }
    void StartRain()
    {
        rainVFX.Play();
        fogVFX.Play();
        isRaining = true;
        StartCoroutine(FadeInAudio());
        StartCoroutine(FadeInFog());

    }
    void StopRain()
    {
        StartCoroutine(FadeOutAudio());
        StartCoroutine(FadeOutFog());
        rainVFX.Stop();
        fogVFX.Stop();
        isRaining = false;

    }
    IEnumerator FadeOutAudio()
    {
        float startVolume = rainSound.volume;
        while (rainSound.volume > 0f)
        {
            var tmp = rainSound.volume;
            rainSound.volume = tmp - (startVolume * Time.deltaTime / fadingTime);
            yield return new WaitForEndOfFrame();
        }
        rainSound.Stop();
    }
    IEnumerator FadeInAudio()
    {
        rainSound.Play();
        while (rainSound.volume < volume)
        {
            var tmp = rainSound.volume;
            rainSound.volume = tmp + (volume * Time.deltaTime / fadingTime);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator FadeInFog()
    {
        float startFog = RenderSettings.fogEndDistance;
        while (RenderSettings.fogEndDistance > endFogRain)
        {
            var tmp = RenderSettings.fogEndDistance;
            RenderSettings.fogEndDistance = tmp - (startFog * Time.deltaTime / fogFadingTime);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator FadeOutFog()
    {
        while (RenderSettings.fogEndDistance < endFog)
        {
            var tmp = RenderSettings.fogEndDistance;
            RenderSettings.fogEndDistance = tmp + (endFog * Time.deltaTime / fogFadingTime);
            yield return new WaitForEndOfFrame();
        }
    }


}
