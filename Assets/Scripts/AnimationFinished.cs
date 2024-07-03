using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFinished : MonoBehaviour
{
    public StartingMenu SM;
    public bool done = false;

    public void EndAnimation()
    {
        SM.SubmitAnimationFinished();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done) { EndAnimation(); }
    }
}
