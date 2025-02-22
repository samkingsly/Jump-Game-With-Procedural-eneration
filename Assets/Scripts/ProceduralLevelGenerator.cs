using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ProceduralLevelGenerator : MonoBehaviour
{

    [SerializeField] List<ProceduralLevelDesignInputObject> LevelConfigs;
    [SerializeField] GameObject LevelObjectsHolder;
    [SerializeField] List<GameObject> PlatformsList;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Canvas;
    [SerializeField] SceneHandler sceneHandler;
    [SerializeField] TextMeshProUGUI LevelCountDisplay;

    private GameObject prevPlatform;
    // Start is called before the first frame update
    void Start()
    {
        prevPlatform = null;
        Player.SetActive(false);
        Player.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createLevel(int LevelConfigID)
    {
        sceneHandler.CurrentLevelCount = LevelConfigID;
        LevelCountDisplay.text = ("Level " + (LevelConfigID + 1).ToString());
        DestroyLevelContent(LevelObjectsHolder);
        prevPlatform = null;
        Player.transform.SetParent(null);
        Canvas.SetActive(false);
        LevelObjectsHolder.SetActive(true);
        ProceduralLevelDesignInputObject x = LevelConfigs[LevelConfigID];
        int steps = x.TotalSteps;
        string Arrangement = x.stepArrangementString;
        string life = x.stepLifeString;
        Debug.Log("Card Data " + steps + " " + Arrangement + " " + life);

        for(int i = 0; i < steps; i++)
        {
            char ArrangeValChar = Arrangement[i];
            int ArrangeVal = ArrangeValChar - '0';
            char LifeValChar = life[i];
            int LifeVal = LifeValChar - '0';

            if(prevPlatform == null)
            {
                Debug.Log("Arrangement " + (ArrangeVal));
                GameObject platform = Instantiate(PlatformsList[ArrangeVal - 1]);
                platform.transform.SetParent(LevelObjectsHolder.transform);
                platform.transform.localPosition = Vector3.zero;
                platform.GetComponent<PlatformBehaviour>().LifeCount = LifeVal;
                prevPlatform = platform;
                

            }
            else
            {
                Debug.Log("Arrangement " + (ArrangeVal - 1));
                GameObject platform = Instantiate(PlatformsList[ArrangeVal - 1]);
                platform.transform.SetParent(LevelObjectsHolder.transform);
                platform.transform.position = getTransformDifference(ArrangeVal - 1) + prevPlatform.transform.localPosition;
                platform.GetComponent<PlatformBehaviour>().LifeCount = LifeVal;
                prevPlatform = platform;
            }

            Player.transform.position = new Vector3(0, 4, 0);
            Player.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled = true;

        }

        

    }

    public Vector3 getTransformDifference(int i)
    {
        Vector3 diffPos = Vector3.zero;
        
        switch(i)
        {
            case 0: diffPos = new Vector3(0, 0, 20); break;
            case 1: diffPos = new Vector3(0, 0, 10); break;
            case 2: diffPos = new Vector3(0, 0, 20); break;
            case 3: diffPos = new Vector3(0, 0, 15); break;
        }

        return diffPos;
    }

    public void DestroyLevelContent(GameObject levelObjHolder)
    {
        foreach(Transform child in levelObjHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
