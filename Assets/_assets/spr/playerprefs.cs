using System;
using UnityEngine;

public class playerprefs : MonoBehaviour
{

    public GameInfo aGameInfo;

    [ContextMenu("Savegame")]
    public void Savegame()
    {
        var gamefovalue = JsonUtility.ToJson(aGameInfo);
        PlayerPrefs.SetString(nameof(aGameInfo), gamefovalue);
        PlayerPrefs.Save();
    }
    [ContextMenu("loadgame")]
    public void Loadgame()
    {
        string defaultValue = JsonUtility.ToJson(new GameInfo());
        string gameInfovalue = PlayerPrefs.GetString(nameof(aGameInfo), defaultValue);
        aGameInfo = JsonUtility.FromJson<GameInfo>(gameInfovalue);
    }

    [Serializable]
    public class GameInfo
    {
        
        public string quest;
        
    }

    private void Start()
    {
        Savegame();
        Loadgame();
    }
}
