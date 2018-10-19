using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayTest : MonoBehaviour 
{
    private Animation playerAnimation;
    private Dictionary<int, string> keyValuePairs=new Dictionary<int, string>();
    private int CurrAniIndex;

	// Use this for initialization
	void Start ()
    {
        playerAnimation = GetComponent<Animation>();
        CurrAniIndex = 0;
        foreach (AnimationState ani in playerAnimation)
        {
            Debug.Log(ani.clip.name);
            keyValuePairs.Add(CurrAniIndex, ani.clip.name);
            CurrAniIndex++;
        }
        CurrAniIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debuger.Log("Play Clip: {0} ,index: {1}", keyValuePairs[CurrAniIndex], CurrAniIndex);
            playerAnimation.Play(keyValuePairs[CurrAniIndex]);
            
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            CurrAniIndex--;
            if (CurrAniIndex < 0) CurrAniIndex = keyValuePairs.Keys.Count - 1;
            Debuger.Log("Play Clip: {0} ,index: {1}", keyValuePairs[CurrAniIndex], CurrAniIndex);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            CurrAniIndex++;
            if (CurrAniIndex > keyValuePairs.Keys.Count - 1) CurrAniIndex = 0;
            Debuger.Log("Play Clip: {0} ,index: {1}", keyValuePairs[CurrAniIndex], CurrAniIndex);
        }
		
	}
}
