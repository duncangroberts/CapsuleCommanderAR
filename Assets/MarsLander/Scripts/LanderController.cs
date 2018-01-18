using UnityEngine;
using UnityEngine.UI;

public class LanderController : MonoBehaviour {

    public Toggle antennaToggle;
    public Toggle receiverToggle;
    public Toggle solarPanelsToggle;
    public Toggle armToggle;
    public AudioSource audio;
    
    public Animator receiverAnimation;
    public Animator solarPanelsAnimation;
    public Animator armToggleAnimation;
    public Animator landerAnimator;
    
    void Start()
    {
        // Performance reason
        InvokeRepeating("ControlAnimations", 0, 0.1f);
    }
	
	void ControlAnimations ()
    {
        // Control the animations with toggle elements in Canvas
        AnimationControl(antennaToggle, landerAnimator, "Antenna Off", string.Empty,"Antenna_Active");
        AnimationControl(receiverToggle, receiverAnimation, "Receiver Off",string.Empty, "Receiver_Active");
        AnimationControl(solarPanelsToggle, solarPanelsAnimation, "Solar Panels Off", "Solar Panels On", "Solar_Panels_On");
        AnimationControl(armToggle, armToggleAnimation, "Arm Off", "Arm On", "Arm_On");
        
        // Play alert sound only during animation
        // Future release - add hydraulics sound
        PlaySoundOnAnimation();

        // Disable toggle elements when animation is playing
        RestrictToggle(landerAnimator, antennaToggle);
        RestrictToggle(solarPanelsAnimation, solarPanelsToggle);
        RestrictToggle(armToggleAnimation, armToggle);
        RestrictToggle(receiverAnimation, receiverToggle);
    }

    private void AnimationControl(Toggle toggle, Animator anim, string animName1, string animName2, string param1)
    {
        if (!toggle.isOn)
        {
            anim.CrossFade(animName1, 0, 0);
            anim.SetBool(param1, false);
        }
        if (toggle.isOn)
        {
            if (!string.IsNullOrEmpty(animName2))
                anim.CrossFade(animName2, 0, 0);

            anim.SetBool(param1, true);
        }
    }

    private void RestrictToggle(Animator anim, Toggle toggle)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            toggle.enabled = false;
        }
        else
        {
            toggle.enabled = true;
        }
    }

    private void PlaySoundOnAnimation()
    {
        if (landerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f
            || solarPanelsAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f
            || armToggleAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f
            || receiverAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            
            if (!audio.isPlaying)
                audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }


}
