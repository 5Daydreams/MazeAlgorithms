using System.Collections;
using System.Collections.Generic;
using _Code.Observer.Event;
using _Code.Observer.Listener;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VoidEventListener))]
public class AlgorithmReader : MonoBehaviour
{
    [SerializeField] private VoidEvent _event;

    
    // Start is called before the first frame update
    private void Start()
    {
        // nothing goes here :)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _event.Raise();
        }
    }

    public void DebugHello(string number)
    {
        Debug.Log("Hello " + number);
    }
}
