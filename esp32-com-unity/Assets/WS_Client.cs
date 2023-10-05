using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WebSocketSharp;

public class WS_Client : MonoBehaviour
{
    private WebSocket ws;
    void Start()
    {
        ws = new WebSocket(("ws://localhost:8080"));
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message received from " + ((WebSocket)sender).Url + ", Data: " + e.Data.ToString());
        };
        ws.Connect();
        Debug.Log("Valid");
    }

    void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("Hello");
        }
    }
}
