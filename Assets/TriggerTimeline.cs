using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TriggerTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector _director;
    // Start is called before the first frame update
    void Start()
    {
        if (_director == null)
        {
            Debug.LogError("Can't find director");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        _director.Play();
        Destroy(this);
    }
}
