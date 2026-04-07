using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneScript : MonoBehaviour
{
    public GameObject ObjectToHide;
    
    private void Start()
    {
        HidePhone();
    }

    [ServerRpc]
    public void HidePhone()
    {
        //print("heho");
        ObjectToHide.SetActive(false);
        //NetworkSceneManager.Load();
        //NetworkManager.SceneManager.LoadScene("TestChangeScene", LoadSceneMode.Additive);

    }
}
