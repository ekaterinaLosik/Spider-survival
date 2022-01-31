using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Survival : MonoBehaviour
{
    public static float maxHealth = 20f;
    public static float health = 0f;
    public float hungerSpeed = 2f;

    public Slider slider;
    public GameManager gameManager;


    public Color green, yellow, red;
    public GameObject sliderFill;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            gameManager.EndGame();
        }
        if (!GameManager.isPaused)
        {
            health = health - hungerSpeed * Time.deltaTime;
            slider.value = health;
            setSliderFillColor();
        }

    }
    void setSliderFillColor()
    {
        Material mat = sliderFill.GetComponent<Image>().material;
        if (health >= 14f)
            mat.color = green;
        else if (health >= 7)
            mat.color = yellow;
        else mat.color = red;
    }
}
