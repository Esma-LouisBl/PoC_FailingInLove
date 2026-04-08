using UnityEngine;

public class InputSender : MonoBehaviour
{
    private PlayerNetwork player;

    void Start()
    {
        player = GetComponent<PlayerNetwork>();
    }

    void Update()
    {
        if (!player.IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SendInputServerRpc(2);
        }
    }

    //OUTDATED
    public void Move()
    {
        if (!player.IsOwner) return;

        player.SendInputServerRpc(1);
    }
    
    public void Jump()
    {
        if (!player.IsOwner) return;
        
        player.SendInputServerRpc(2);
    }
}
