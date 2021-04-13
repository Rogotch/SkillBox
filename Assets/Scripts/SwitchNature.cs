using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class SwitchNature : MonoBehaviour
{
    public AudioMixerSnapshot firstSound;
    public AudioMixerSnapshot secondSound;

    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 9 && !flag)
        {
            secondSound.TransitionTo(5);
            flag = true;
        }

        if (transform.position.y <= 9 && flag)
        {
            firstSound.TransitionTo(5);
            flag = false;
        }
    }
}
