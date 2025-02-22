using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject LevelObjHolder;
    [SerializeField] GameObject Camera;
    [SerializeField] ProceduralLevelGenerator proceduralLevelGenerator;
    [SerializeField] GameObject RestartCanvas;
    [SerializeField] GameObject WinningCanvas;
    public int CurrentLevelCount;
    // Start is called before the first frame update

    private void Awake()
    {
        player.transform.SetParent(null);
        player.SetActive(false);
        canvas.SetActive(true);
        Camera.transform.SetParent(null);
        RestartCanvas.SetActive(false) ;
        WinningCanvas.SetActive(false) ;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            player.transform.SetParent(null);
            player.SetActive(false);
            LevelObjHolder.SetActive(false);
            canvas.SetActive(true);
            Camera.transform.SetParent(null);
            RestartCanvas.SetActive(false);
        }

    }

    public void SelectLevel()
    {
        player.transform.SetParent(null);
        player.SetActive(false);
        LevelObjHolder.SetActive(false);
        canvas.SetActive(true);
        Camera.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "Player")
        {
            if (LevelObjHolder.transform.childCount != 0)
            {
                CurrentLevelCount = 0;
                proceduralLevelGenerator.createLevel(CurrentLevelCount);
            }
            else 
            {
                if(CurrentLevelCount < 4)
                {
                    proceduralLevelGenerator.createLevel(CurrentLevelCount + 1);
                }
                else
                {
                    Winning();
                }
            }
        }
    }

    public void onRestartButtonClicked()
    {
        proceduralLevelGenerator.createLevel(CurrentLevelCount);
    }

    public void Winning()
    {
        Camera.transform.SetParent(null);
        player.transform.SetParent(null);
        player.SetActive(false);
        LevelObjHolder.SetActive(false);
        RestartCanvas.SetActive(false) ;
        WinningCanvas.SetActive(true);
        StartCoroutine(GoNormal());
    }

    IEnumerator GoNormal()
    {
        yield return new WaitForSeconds(5);
        player.transform.SetParent(null);
        player.SetActive(false);
        LevelObjHolder.SetActive(false);
        canvas.SetActive(true);
        Camera.transform.SetParent(null);
        WinningCanvas.SetActive(false);
        RestartCanvas.SetActive(false);
    }
}
