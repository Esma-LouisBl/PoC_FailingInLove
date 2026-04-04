using Unity.Netcode;
using UnityEngine;

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
        print("heho");
        ObjectToHide.SetActive(false);
    }
}
