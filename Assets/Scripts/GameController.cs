using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cards = new GameObject[12];

    private Vector3[] oldPosition = new Vector3[12];

    private string name1 = null;

    private string name2 = null;

    private int countPair;

    [SerializeField]
    private GameObject defeatScreen;

    [SerializeField]
    private GameObject endScreen;

    private void Start()
    {
        ShuffleCards(); //EMBARALHA CARTAS
    }


    private void Update()
    {
        if (defeatScreen.activeInHierarchy) //VERIFICA SE ACABOU O TEMPO
        {
            LockButtons();
        }
    }


    public void UpdateSlot(string currentName)  //ADD O NOME DAS CARTAS A VARIAVEL NAME1 E NAME2
    {
            if (name1 == null)
            {
                name1 = currentName;
            }
            else //SE TIVER ESCOLHIDO AS 2 CARTAS
            {
                name2 = currentName;
                LockButtons();
                VerifyAnswer();
            }
        
    }

    private void VerifyAnswer() //VERIFICA DUAS CARTAS
    {
        
        if(name1 == name2)          //EH UM PAR
        {
            countPair++;
            MakeFoundCard(name1);
        }
        else                        //NAO EH PAR
        { 
            StartCoroutine(Wronganswer());

        }
    }

    IEnumerator Wronganswer() //RESPOSTA ERRADA.. ESPERA 1 SEG PARA VIRAR AS CARTAS NOVAMENTE
    {
            yield return new WaitForSeconds(1f);

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().NameID == name1 || cards[i].GetComponent<Card>().NameID == name2)
            {
                cards[i].GetComponent<Card>().Tap();
            }
        }

        ResetStrings();

        Debug.Log("valores de name1 e name2 " + name1 + " " + name2);

        UnlockButtons();
    }

    private void MakeFoundCard(string currentName)  //ATUALIZA O STATUS DO CARD PARA "ENCONTRADO"
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().NameID == currentName)
            {
                cards[i].GetComponent<Card>().found = true;
            }
        }
        ResetStrings();
        UnlockButtons();
    }

    private void LockButtons() //DESABILITA O ACESSO AS CARTAS
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    private void UnlockButtons() //HABILITA O ACESSO AS CARTAS QUE NAO FORAM ENCONTRADAS... VERIFICA FIM DE JOGO
    {
        if (countPair < 6)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].GetComponent<Card>().found == false) //VERIFICA SE A CARTA JA FOI ENCONTRADA
                {
                    cards[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
        else //SE ENCONTRAR TODAS AS CARTAS HABILITA A TELA DE FIM DE JOGO
        {
            
            LockButtons();
            endScreen.SetActive(true);
        }
    }

    private void ResetStrings() //RESETA O VALOR DAS STRINGS NAME1 E NAME2 PARA UMA NOVA TENTATIVA
    {
        name1 = null;
        name2 = null;
    }

    private void ShuffleCards() //EMBARALHA OS CARDS EM POSICOES ALEATORIAS
    {
        //SALVA POSICAO ANTIGA
        for (int i = 0; i < cards.Length; i++)
        {
            oldPosition[i] = new Vector3(cards[i].transform.position.x,
                                         cards[i].transform.position.y,
                                         cards[i].transform.position.z);
        }

        //EMBARALHA ARRAY
        for (int i = 0; i < cards.Length; i++)
        {
            GameObject obj = cards[i];
            int randomizeArray = Random.Range(0, i);
            cards[i] = cards[randomizeArray];
            cards[randomizeArray] = obj;
        }

        //ADD NOVAS POSICOES
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = oldPosition[i];
        }


    }
}
