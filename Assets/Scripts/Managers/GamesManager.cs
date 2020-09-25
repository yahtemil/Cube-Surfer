using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI nowLevel, nextLevel;
    public GameObject StartPanel;
    public PlayerController playerController;
    public GoldUI _goldUI;

    public GameObject winpanel, losepanel;

    // Start is called before the first frame update
    void Start()
    {
        nowLevel.text = PlayerPrefs.GetInt("nowLevel", 1).ToString();
        nextLevel.text = PlayerPrefs.GetInt("nextLevel", 2).ToString();
        goldText.text = PlayerPrefs.GetInt("gold", 0).ToString();
        _goldUI = FindObjectOfType<GoldUI>();
        playerController = FindObjectOfType<PlayerController>();
    }



    public void StartButton()
    {
        StartPanel.SetActive(false);
        playerController.GameControl = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void WinButton()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void TryAgainButton()
    {
        losepanel.SetActive(false);
        PlayerPrefs.SetInt("nowLevel", PlayerPrefs.GetInt("nowLevel",1)+1);
        PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel", 2) + 1);
        SceneManager.LoadScene(0);
    }
}
