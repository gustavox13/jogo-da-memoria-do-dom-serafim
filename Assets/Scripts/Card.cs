using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string NameID;

    [SerializeField]
    private GameObject img;

    private Animator cardAnim;

    [SerializeField]
    private GameObject controller;

    public bool found = false;

    private AudioSource soundCard;

    private void Start()
    {
        soundCard = this.gameObject.GetComponent<AudioSource>();

        cardAnim = this.gameObject.GetComponent<Animator>();
    }

    public void Tap()
    {
        //cardAnim.SetTrigger("tap");
        img.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void UnTap()
    {
        soundCard.Play();
        //cardAnim.SetTrigger("untap");
        img.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseUpAsButton()
    {
        UnTap();
        controller.GetComponent<GameController>().UpdateSlot(NameID);
    }

}
