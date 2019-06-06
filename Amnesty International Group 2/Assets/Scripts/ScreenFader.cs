using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    public float fadeSpeed;
        
    void Start()
    {
        if (blackScreen == null)
        {
            Image image = GetComponent<Image>();
            if (image != null)
                blackScreen = image;
        }

        if (blackScreen != null)
        {
            Teleporter.OnTeleportStart.AddListener(delegate { StartCoroutine(FadeOut()); });
            Teleporter.OnTeleport.AddListener(delegate { StartCoroutine(FadeIn()); });
        }
    }

    private IEnumerator FadeOut()
    {
        Color color = blackScreen.color;
        while(color.a < 1f)
        {
            color.a += 0.1f * fadeSpeed;
            blackScreen.color = color;
            yield return new WaitForSeconds(0.1f);
        }

        Teleporter.OnTeleportReady.Invoke();
    }

    private IEnumerator FadeIn()
    {
        Color color = blackScreen.color;
        while (color.a > 0f)
        {
            color.a -= 0.1f * fadeSpeed;
            blackScreen.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
