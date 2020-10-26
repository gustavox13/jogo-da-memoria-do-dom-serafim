using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    private GameObject star1;
    [SerializeField]
    private GameObject star2;
    [SerializeField]
    private GameObject star3;
    [SerializeField]
    private GameObject timer;

    private float score;


    private void Start()
    {
        score = timer.GetComponent<Timer>().currentTime;
        

        StartCoroutine(ShowStars());
    }

    IEnumerator ShowStars()
    {
        if(score <= 50) //3 ESTRELAS SE RESOLVER ATE 50 SEG
        {
            
            star1.SetActive(true);

            yield return new WaitForSeconds(0.4f);

            star2.SetActive(true);

            yield return new WaitForSeconds(0.4f);

            star3.SetActive(true);
        } else if(score > 50 && score < 80) // 2 ESTRELAS SE RESOLVER ATE 80 SEG
        {
            star1.SetActive(true);

            yield return new WaitForSeconds(0.4f);

            star2.SetActive(true);
        }
        else //1 ESTRELA SE PASSAR DE 80 SEG
        {
            star2.SetActive(true);
        }

    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
