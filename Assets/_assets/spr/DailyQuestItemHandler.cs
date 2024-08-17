using UnityEngine;
using UnityEngine.UI;

public class DailyQuestItemHandler : MonoBehaviour
{
    public DailyQuestData dailyQuestData;
    public QuestProgress questProgress;

    public Text nameText;
    public Text nameText1;
    public Text nameText2;
    public Text nameText3;
    public Image icon;

    public void SetData(DailyQuestData dailyQuestData, QuestProgress questProgress)
    {
        Debug.Log("SetData");
        this.dailyQuestData = dailyQuestData;
        this.questProgress = questProgress;
        UpdateUi();
    }
    public void UpdateUi()
    {
        Debug.Log("UpdateUi");
        nameText.text = dailyQuestData.name1;
        nameText1.text = dailyQuestData.name2.ToString();
        icon.sprite = dailyQuestData.icon;

        nameText2.text = $"{questProgress.progress}";
        nameText3.text = $"{dailyQuestData.taskCount}";
    }
}