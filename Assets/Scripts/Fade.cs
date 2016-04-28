using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    public static float alpha;
    public static bool fadeIn;
    public static bool fadeOut;
    private Image image;
    // Use this for initialization
    void Start()
    {
        fadeIn = false;
        fadeOut = false;
        alpha = 0;
        image = gameObject.GetComponent<Image>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Color c = image.color;
        if (fadeIn)
        {
            image.enabled = true;
            alpha -= 0.01f;
            if (alpha <= 0f)
            {
                alpha = 0f;
                fadeIn = false;
                image.enabled = false;
            }
        }
        if (fadeOut)
        {
            image.enabled = true;
            alpha += 0.01f;
            if (alpha >= 1f)
            {
                alpha = 1f;
                fadeOut = false;
            }
        }
        c.a = alpha;
        image.color = c;
    }
}
