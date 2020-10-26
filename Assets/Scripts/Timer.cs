using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    private Image fillImg;

    [SerializeField]
    private float maxTime;

    [SerializeField]
    private GameObject defeatScreen;

    public float currentTime = 0;


    private void Start()
    {
        fillImg = this.GetComponent<Image>();
    }


    private void Update()
    {


        if(currentTime < maxTime)
        {
            currentTime += Time.deltaTime;

            fillImg.fillAmount = (currentTime / maxTime);
            
        }
        else
        {
            defeatScreen.SetActive(true);
        }


    }





}
