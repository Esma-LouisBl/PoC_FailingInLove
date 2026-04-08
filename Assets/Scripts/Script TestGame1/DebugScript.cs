using System;
using Unity.Netcode;
using UnityEngine;

public class DebugScript : NetworkBehaviour
{
    public NetworkVariable<int> testInt = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    delegate void MyDelegate();
    MyDelegate myDelegate;
    
    void Start () 
    {
        //myDelegate = OnIncrement;
    }

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(IsOwner);
            Increment();
        }
    }
    */
    
    //[ServerRpc]
    public void Increment()
    {
        if (IsOwner)
        {
            testInt.Value++;
        }
        print(testInt.Value);
    }
}
