using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDataHandler : MonoBehaviour
{
    public Quest quest;
    public QuestProgress questProgressData;
    public Text questName;
    public Image questImg;
    public Text questProgress;
    public Button completeButton;
    public void UpdateUI(Quest quest, QuestProgress questProgressData)
    {
        this.quest = quest;
        this.questProgressData = questProgressData;
        questName.text = quest.questName;
        questImg.sprite = quest.questImg;
        questProgress.text = questProgressData.progress.ToString();
        if (questProgressData.hasClaimed)
        {
            completeButton.interactable = true;
        }
        else completeButton.interactable = false;
    }

    public void UpdateUIData(QuestProgress questProgressData)
    {
        questProgress.text = questProgressData.progress.ToString();
    }

    /*public void ResetDataUI(Quest quest, QuestProgress questProgressData)
    {
        UpdateUI(quest, questProgressData);
    }

    public void UpdateDataUI(Quest quest,QuestProgress questProgressData)
    {
        UpdateUI(quest, questProgressData);
    }*/

}
