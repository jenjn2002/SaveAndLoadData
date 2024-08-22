using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestData questData;
    public GameObject questPrefabs;
    public GameObject panel;
    public QuestProgressData questProgressData;
    public Dictionary<int, QuestDataHandler> uiQuestData;

    //public List<GameObject> questObjects;

    private void Start()
    {
        uiQuestData = new Dictionary<int, QuestDataHandler>();
        LoadQuestProgress();
        SetData();  
    }
    public void SetData()
    {
        foreach(var quest in questData.quests)
        {
            QuestProgress tempQuestProgress = questProgressData.questProgresses.Find(t=>t.id == quest.id);
            GameObject questPrefab = Instantiate(questPrefabs, panel.transform.parent);
            //questObjects.Add(questPrefab);
            QuestDataHandler questDataHandler = questPrefab.GetComponent<QuestDataHandler>();
            uiQuestData.Add(tempQuestProgress.id, questDataHandler);
            questDataHandler.UpdateUI(quest,tempQuestProgress);
        }
    }
    public void ResetQuestProgressData(QuestProgress questProgress)
    {
        /*Dictionary<int, QuestProgress> questProgressDictionary = new Dictionary<int, QuestProgress>();

        foreach (var questProgress in questProgressData.questProgresses)
        {
            questProgressDictionary[questProgress.id] = questProgress;
        }
        foreach (var questObject in questObjects)
        {
            QuestDataHandler questDataHandler = questObject.GetComponent<QuestDataHandler>();
            Quest quest = questDataHandler.quest;
            if(questProgressDictionary.TryGetValue(quest.id, out QuestProgress questProgress)){
                questDataHandler.ResetDataUI(quest, questProgress);
            }
        }*/
        var questProgressIndex = questProgressData.questProgresses.FindIndex(t=>t.id == questProgress.id);
        questProgressData.questProgresses[questProgressIndex] = questProgress;
        uiQuestData[questProgress.id].UpdateUIData(questProgress);
    }

    public void ResetDataUI()
    {
        for(int i = 0; i < questProgressData.questProgresses.Count; i++)
        {
            QuestProgress questProgress = questProgressData.questProgresses[i];
            questProgress.progress = 0;
            ResetQuestProgressData(questProgress);
        }
    }

    public void UpdateDataUI()
    {
        var questProgess = questProgressData.questProgresses.Find(t=>t.id == int.Parse(UIController.instance.idValue.text.ToString().Trim()));
        questProgess.progress = int.Parse(UIController.instance.questProgressValueChange.text.ToString().Trim());
        ChangeQuestProgressData(questProgess);
    }

    public void ChangeQuestProgressData(QuestProgress questProgress)
    {
        /*int targetId = int.Parse(UIController.instance.idValue.text.ToString().Trim());
        QuestProgress questProgresses = questProgressData.questProgresses.Find(t => t.id ==  targetId);
        foreach (var questObject in questObjects)
        {
            QuestDataHandler questDataHandler = questObject.GetComponent<QuestDataHandler>();
            Quest quests = questData.quests.Find(t=>t.id == targetId);
            if(quests != null && questDataHandler.quest.id == targetId)
            {
                questDataHandler.UpdateDataUI(quests, questProgresses);
                break;
            }
        }*/
        var questProgressIndex = questProgressData.questProgresses.FindIndex(t=>t.id == questProgress.id);
        questProgressData.questProgresses[questProgressIndex] = questProgress;
        uiQuestData[questProgress.id].UpdateUIData(questProgress);
    }

    public void LoadQuestProgress()
    {
        string questProgressJson = PlayerPrefs.GetString(nameof(questProgressData));
        var questProgressDatabase = JsonUtility.FromJson<QuestProgressData>(questProgressJson);
        questProgressData = questProgressDatabase;
    }

    public void SaveQuestProgress()
    {
        var questProgressJson = JsonUtility.ToJson(questProgressData);
        PlayerPrefs.SetString(nameof(questProgressData), questProgressJson);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveQuestProgress();      
    }
}


