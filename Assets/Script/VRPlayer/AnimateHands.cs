using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    public InputActionProperty gripAnimationAction;
    public InputActionProperty pinchAnimationAction;
    public Animator handAnimator;

    // Update is called once per frame
    void Update()
    {

        // Animation to close two fingers
        
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        // Animation to close the hand

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }

}
