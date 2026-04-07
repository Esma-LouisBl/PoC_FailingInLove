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

    public void Move()
    {
        print("moooove");
        print(player.IsOwner);
        if (!player.IsOwner) return;

        player.SendInputServerRpc(1);
    }
}
