using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject testPanel;
    public Button closeButton;
    public Button showButton;
    public Text questProgressValue;
    public InputField idValue;
    public InputField questProgressValueChange;
    public QuestData questData;
    public QuestProgressData questProgressData;
    public QuestDataHandler questDataHandler;

    private void Awake()
    {
        UIController.instance = this;
    }

    private void Start()
    {
        testPanel.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    public void ActiveTestPanel()
    {
        testPanel.SetActive(true);
    }

    public void DisableTestPanel()
    {
        testPanel.SetActive(false);
    }

    public void ActiveCloseButton()
    {
        closeButton.gameObject.SetActive(true);
    }

    public void DisableCloseButton()
    {
        closeButton.gameObject.SetActive(false);
    }

    public void ActiveShowButton()
    {
        showButton.gameObject.SetActive(true);
    }

    public void DisableShowButton()
    {
        showButton.gameObject.SetActive(false);
    }


}
