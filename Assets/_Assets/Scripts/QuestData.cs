using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/ListQuest")]
public class QuestData : ScriptableObject
{
    public List<Quest> quests = new List<Quest>();
}

[System.Serializable]
public class QuestProgress
{
    public int id;
    public int progress;
    public bool hasClaimed;
}

[Serializable]
public class QuestProgressData
{
    public List<QuestProgress> questProgresses = new List<QuestProgress>();
}
