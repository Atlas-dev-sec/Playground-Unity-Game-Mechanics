using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image artworkImage;
    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text deffenseText;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        //card.Print();
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        deffenseText.text = card.deffense.ToString();
        healthText.text = card.health.ToString();
    }

    
}
