using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyQuestManager : MonoBehaviour
{

    public QuestDataBase questDatabase;
    public DailyQuestItemHandler dailyQuestItemHandler;
    public Transform rootUiContent;

    public QuestProgressDatabase questProgressDatabase;
    public Dictionary<int, DailyQuestItemHandler> uiHandlerDict;


    private void Start()
    {
        uiHandlerDict = new Dictionary<int, DailyQuestItemHandler>();
        LoadQuestProgress();

        foreach (var questData in questDatabase.questData)
        {
            QuestProgress questProgress = questProgressDatabase.questProgress.Find(questProgress => questProgress.id.ToString() == questData.id);
            CreatQuest(questData, questProgress);
        }
    }

    private void LoadQuestProgress()
    {
        var defaultQuestProgressDatabaseString = JsonUtility.ToJson(questProgressDatabase);
        var questProgressDatabaseValue = PlayerPrefs.GetString(nameof(questProgressDatabase), defaultQuestProgressDatabaseString);
        questProgressDatabase = JsonUtility.FromJson<QuestProgressDatabase>(questProgressDatabaseValue);

    }


    private void CreatQuest(DailyQuestData questData, QuestProgress questProgress)
    {
        var quest = Instantiate(dailyQuestItemHandler, rootUiContent);
        quest.SetData(questData, questProgress);
        uiHandlerDict.Add(questProgress.id, quest);
    }
    private void OnApplicationQuit()
    {
        SaveProgress();
    }


    [ContextMenu("Save Quest Progress")]
    private void SaveProgress()
    {
        var questProgressDatabaseString = JsonUtility.ToJson(questProgressDatabase);
        PlayerPrefs.SetString(nameof(questProgressDatabase), questProgressDatabaseString);
        PlayerPrefs.Save();
    }

    public void UpdateQuestProgress(QuestProgress questProgress)
    {
        var questIndex = questProgressDatabase.questProgress.FindIndex(progress => questProgress.id == progress.id);
        questProgressDatabase.questProgress[questIndex] = questProgress;
        uiHandlerDict[questProgress.id].UpdateProgress(questProgress);
    }

}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DailyQuestManager : MonoBehaviour
//{
//    public QuestDataBase questDatabase;
//    public DailyQuestItemHandler dailyQuestItemHandler;
//    // public QuestProgressDatabase questProgressDatabase;
//    public Transform rootUiContent;

//    public QuestProgressDatabase questProgressDatabase;
//    public QuestProgress questProgress;
//    public Dictionary<int, DailyQuestItemHandler> uiHandlerDict;
//    private void Start()
//    {
//        uiHandlerDict = new Dictionary<int, DailyQuestItemHandler>();
//        LoadQuestProgress();


//        foreach (var questData in questDatabase.questData)
//        {
//            QuestProgress questProgress = questProgressDatabase.questProgress.Find(questProgress => questProgress.id.ToString() == questData.id);
//            CreatQuest(questData, questProgress);
//        }
//    }


//    private void CreatQuest(DailyQuestData questData, QuestProgress questProgress)
//    {
//        var quest = Instantiate(dailyQuestItemHandler, rootUiContent);
//        quest.SetData(questData, questProgress);
//        uiHandlerDict.Add(questProgress.id, quest);
//    }

//    [ContextMenu("Save Quest Progress")]
//    private void SaveProgress()
//    {
//        var questProgressDatabaseString = JsonUtility.ToJson(questProgressDatabase);
//        PlayerPrefs.SetString(nameof(questProgressDatabase), questProgressDatabaseString);
//        PlayerPrefs.Save();
//    }

//    [ContextMenu("Load Quest Progress")]
//    private void LoadQuestProgress()
//    {
//        var defaultQuestProgressDatabaseString = JsonUtility.ToJson(questProgressDatabase);
//        var questProgressDatabaseValue = PlayerPrefs.GetString(nameof(questProgressDatabase), defaultQuestProgressDatabaseString);
//        questProgressDatabase = JsonUtility.FromJson<QuestProgressDatabase>(questProgressDatabaseValue);

//    }

//    private void OnApplicationQuit()
//    {
//        SaveProgress();
//    }

//    [ContextMenu("Add progress")]
//    private void AddProgress()
//    {
//        questProgress.progress += 1;
//        Debug.Log("add progress");
//    }
//    public void UpdateQuestProgress(QuestProgress questProgress)
//    {
//        var questIndex = questProgressDatabase.questProgress.FindIndex(progress => questProgress.id == progress.id);
//        questProgressDatabase.questProgress[questIndex] = questProgress;
//        uiHandlerDict[questProgress.id].UpdateProgress(questProgress);
//    }
//}