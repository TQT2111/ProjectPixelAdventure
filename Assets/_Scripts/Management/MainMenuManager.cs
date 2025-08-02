using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject trans;
    [SerializeField] SceneManagement sceneManagement;
    void Start()
    {
        setting.SetActive(false);
        level.SetActive(false); 
        credit.SetActive(false);
        trans.SetActive(false);
    }
    public void OpenSetting()
    {
        setting.SetActive(true);
    }
    public void CloseSetting()
    {
        setting.SetActive(false);
    }
    public void OpenLevel()
    {
        level.SetActive(true);
    }
    public void CloseLevel()
    {
        level.SetActive(false);
    }
    public void OpenCredit()
    {
        credit.SetActive(true);
    }
    public void CloseCredit()
    {
        credit.SetActive(false);
    }

    public void StartTrans()
    {
        trans.SetActive(true);
        Invoke(nameof(WaitToLoadScene), 1.5f);
    }

    private void WaitToLoadScene()
    {
        sceneManagement.PlayScene();
    }
}
