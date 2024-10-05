using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public GameObject lastDoor;
    public TextMeshProUGUI collectablesText;
    public GameObject[] collectables;
    public GameObject winScreen;
    public bool doWinOnAllCollected = false;

    public GameObject boss;
    public GameObject exitDoor;

    public bool isBossFight = false;
    public int ammo = 0;
    
    private int totalCollectables;
    private int collectedCollectables = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    void Start()
    {
        totalCollectables = collectables.Length;
        collectablesText.text = "0 / " + totalCollectables + " Collected";
    }

    public void Collect(GameObject gameObject)
    {
        collectedCollectables++;
        collectablesText.text = collectedCollectables + " / " + totalCollectables + " Collected";

        if (totalCollectables - 1 == collectedCollectables) 
        {
            if(lastDoor != null)
                lastDoor.SetActive(false);
        }

        if (collectedCollectables == totalCollectables && doWinOnAllCollected) DoWin();
        else if(collectedCollectables == totalCollectables && !doWinOnAllCollected)
        {
            if(exitDoor != null)
                exitDoor.SetActive(false);

            if (boss != null)
                boss.SetActive(true);
        }

        gameObject.GetComponent<Collectable>().OnCollect();
    }

    public void DoWin()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winScreen.SetActive(true);
    }
}
