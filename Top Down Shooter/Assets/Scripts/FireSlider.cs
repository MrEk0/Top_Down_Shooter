using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSlider : MonoBehaviour
{
    Slider slider;
    GameObject player;

    float fireRate;

    private void Awake()
    {
        slider=GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        player.GetComponent<Fire>().OnShooted += Shot;
    }

    private void OnDisable()
    {
        player.GetComponent<Fire>().OnShooted -= Shot;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = slider.maxValue;
    }

    private void Update()
    {
        slider.value += Time.deltaTime/fireRate;
    }

    private void Shot(float fireRate)
    {
        slider.value = slider.minValue;
        this.fireRate = fireRate;
    }
}
