using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest11 : MonoBehaviour
{
    
    public Quest quest;

    public Text nameText;

    public Text nameText1;

    public Image artwork1;

    public Text nameText2;


    void Start()
    {

        nameText.text = quest.name123;
        nameText1.text = quest.name8;

        artwork1.sprite = quest.artwork;
        nameText2.text = quest.name9;
    }

}
