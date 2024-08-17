using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/quest", order = 1)]
public class QuestDataBase : ScriptableObject
{
    public List<DailyQuestData> questData;
}

[Serializable]
public class QuestProgress
{
    public int id;
    public int progress;
    public bool hasClaimed;
}

[Serializable]
public class QuestProgressDatabase
{
    public List<QuestProgress> questProgress;
}