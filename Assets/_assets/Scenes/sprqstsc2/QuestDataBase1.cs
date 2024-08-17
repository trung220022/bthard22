using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestDataBase", menuName = "ScriptableObjects/QuestDataBase", order = 2)]
public class QuestDataBase1 : ScriptableObject
{
    public List<DailyQuestData> questDataList;
}
