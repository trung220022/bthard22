using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDailyQuest : MonoBehaviour
{
    public Text idText;
    public Text progressText;

    public void UpdateQuest()
    {
        var id = int.Parse(idText.text);
        var progress = int.Parse(progressText.text);
    }

    public void RestData()
    {
        PlayerPrefs.DeleteAll();
    }
}