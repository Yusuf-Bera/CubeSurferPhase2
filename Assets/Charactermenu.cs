<<<<<<< HEAD
using HmsPlugin;
using HuaweiMobileServices.Ads;
=======
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Charactermenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characterList;
    [Space]
    public GameObject[] Header;
    public GameObject lockImg;
    public GameObject okImg;
    [Space]
    public Button priceImg;
    public static int currIndex = 0;
    public CoinsManager coins;
<<<<<<< HEAD
    private ScoreManager scoreManager;
=======
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    void Awake()
    {
        updateCharacter(currIndex);
        if (PlayerPrefs.GetInt("AvailableCharacterIndex") == null)
        {
            PlayerPrefs.SetInt("AvailableCharacterIndex", 0);
        }
    }

<<<<<<< HEAD
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        HMSAdsKitManager.Instance.LoadAllAds();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 30 * Time.deltaTime, UnityEngine.Space.Self);
=======
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 30 * Time.deltaTime, Space.Self);
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    }

    public void nextCharacter()
    {
        if (++currIndex == 3)
        {
            currIndex = 0;
        }
        updateCharacter(currIndex);
    }

    public void previousChaacter()
    {
        if (--currIndex == -1)
        {
            currIndex = 2;
        }
        updateCharacter(currIndex);
    }

    private void updateCharacter(int index)
    {
        checkAvailable(currIndex);
        for (int i = 0; i < characterList.Length;i++)
        {
            if(i == currIndex)
            {
                characterList[i].SetActive(true);
                Header[i].SetActive(true);
            }
            else
            {
                characterList[i].SetActive(false);
                Header[i].SetActive(false);
            }
        }
    }

    public void buyCharacter()
    {
        int temp = PlayerPrefs.GetInt("AvailableCharacterIndex");
        if (currIndex > temp +1)
        {
            return;
        }
        else
        {
            if (PlayerPrefs.GetInt("Gem") >= 2500)
            {
                coins.scoreMan.addScore(-2500);
                PlayerPrefs.SetInt("AvailableCharacterIndex", temp + 1);
            }
            else
            {
                return;
            }
        }
        updateCharacter(currIndex);
    }

    void checkAvailable(int idx)
    {
        ColorBlock colors = priceImg.colors;
        Color normalColor = colors.normalColor;
        if (idx <= PlayerPrefs.GetInt("AvailableCharacterIndex"))
        {
            okImg.SetActive(true);
            lockImg.SetActive(false);
            Debug.Log(PlayerPrefs.GetInt("AvailableCharacterIndex"));
            priceImg.interactable = false;

            normalColor.a = 0.6f;
        }
        else
        {
            okImg.SetActive(false);
            lockImg.SetActive(true);
            priceImg.interactable = true;
            normalColor.a = 1f;
        }
        colors.normalColor = normalColor;
        priceImg.colors = colors;
    }

    public void loadGameScene()
    {
<<<<<<< HEAD
        SceneManager.LoadScene(1);
    }

    public void GetRewardwithADS()
    {
        HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
        HMSAdsKitManager.Instance.ShowRewardedAd();
    }

    private void OnRewarded(Reward reward)
    {
        scoreManager.addScore(100);
=======
        SceneManager.LoadScene(GameManager.lastSceneIdx);
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    }
}
