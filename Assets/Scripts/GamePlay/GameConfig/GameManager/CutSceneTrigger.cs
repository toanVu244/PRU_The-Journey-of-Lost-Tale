using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    private void OnTriggerEnter(Collider other)
    {
        PlayCutscene();
    }

    void PlayCutscene()
    {
        if (timeline != null)
        {
            timeline.Play();
        }
    }
}
