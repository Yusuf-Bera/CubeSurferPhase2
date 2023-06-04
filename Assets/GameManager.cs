using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HmsPlugin;
using HuaweiMobileServices.Ads;
using HuaweiMobileServices.IAP;
=======
using UnityEngine.SceneManagement;
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53

public class GameManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] heros;
    public Transform herosParent;
    public RuntimeAnimatorController herosAnim;

    [Header("Other")]
    public Animator planeAnim;
    public GameObject storeImg;
    public GameObject finalAnim;

<<<<<<< HEAD
    [Header("Purchase")]
    public GameObject IAPCanvas;
    public GameObject StartCanvas;
    ScoreManager scoreManager;

    public static int lastSceneIdx;
    public static bool readyformovement;
    GameObject newObj;

    private void Awake()
    {
        newObj = Instantiate(heros[Charactermenu.currIndex], herosParent);
        newObj.AddComponent<Animator>();
    }
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        lastSceneIdx = SceneManager.GetActiveScene().buildIndex;
        newObj.GetComponent<Animator>().runtimeAnimatorController = herosAnim;
        if (PlayerPrefs.GetInt("adState") == 1)
        {
            HMSAdsKitManager.Instance.ShowBannerAd();
        }
    }

    //private void OnEnable()
    //{
    //    Btn_ItemGem1000.onClick.AddListener(PurchaseProduct);
    //}

    //private void OnDisable()
    //{
    //    Btn_ItemGem1000.onClick.RemoveListener(PurchaseProduct);
    //}

    public void loadStoreScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("store scene");
=======
    public static int lastSceneIdx;
    private void Start()
    {
        lastSceneIdx = SceneManager.GetActiveScene().buildIndex;
        GameObject newObj = Instantiate(heros[Charactermenu.currIndex],herosParent);
        newObj.AddComponent<Animator>();
        newObj.GetComponent<Animator>().runtimeAnimatorController = herosAnim;
    }

    public void loadStoreScene()
    {
        SceneManager.LoadScene(0);
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
    }
    public void nextLevel()
    {
        finalAnim.SetActive(true);
        planeAnim.SetTrigger("Fly");
        FindObjectOfType<CameraFollowController>().finishCameraMovement();
<<<<<<< HEAD
        HMSAdsKitManager.Instance.ShowInterstitialAd();
=======
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
        Invoke("loadNextScene", 3f);
    }
    public void startGame()
    {
        storeImg.SetActive(false);
    }
    public void rePlay()
    {
        Invoke("resetGame", 1.99f);
    }

    void loadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
<<<<<<< HEAD
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
=======
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
        }
    }

    void resetGame()
    {
<<<<<<< HEAD
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }


    public void PurchaseProduct()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess += OnBuyProductSuccess;
        HMSIAPManager.Instance.PurchaseProduct(HMSIAPConstants.coins1000);
    }
    public void RemoveBanner()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        HMSIAPManager.Instance.PurchaseProduct(HMSIAPConstants.removeADS);
    }

    public void ChangeCanvas()
    {
        if (IAPCanvas.active)
        {
            IAPCanvas.SetActive(false);
            StartCanvas.SetActive(true);
        }
        else
        {
            IAPCanvas.SetActive(true);
            StartCanvas.SetActive(false);
        }
    }
    private void OnBuyProductSuccess(PurchaseResultInfo obj)
    {
        Debug.Log("OnBuyProductSuccess");

        if (obj.InAppPurchaseData.ProductId == HMSIAPConstants.coins1000)
        {
            //HMSIAPManager.Instance.OnBuyProductSuccess += OnBuyProductSuccess;
            scoreManager.addScore(1000);
        }
        if (obj.InAppPurchaseData.ProductId == HMSIAPConstants.removeADS)
        {
            //HMSIAPManager.Instance.OnBuyProductSuccess += OnBuyProductSuccess;
            PlayerPrefs.SetInt("adState", 0);
            HMSAdsKitManager.Instance.DestroyBannerAd();
        }
    }
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


>>>>>>> 77af4fa27b3f4787a2f54d9355e64b2ded9c9c53
}
