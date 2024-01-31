using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Playergravityswitch
{
    public Playerstatemachine psm;
    public static Action platformrotate;

    public void playerswitchgravity()
    {
        if (psm.checkcontroller(psm.controls.Player.Gravityswitch.WasPerformedThisFrame(), Input.GetButtonDown("Gravity"), psm.controls.Player.Controllergravityswitch.WasPerformedThisFrame()) == true)
        // if (psm.controls.Player.Gravityswitch.WasPerformedThisFrame() || psm.controls.Player.Controllergravityswitch.WasPerformedThisFrame()) //Input.GetButtonDown("Gravity")) //psm.controls.Player.Controllergravityswitch.WasPerformedThisFrame())
        {
            if (Globalcalls.dontreadplayerinputs == false && Globalcalls.currentgravitystacks > 0)
            {
                Globalcalls.currentgravitystacks--;
                Cooldowns.instance.handlegravitystacks();
                psm.gravityswitchactiv = !psm.gravityswitchactiv;
                psm.transform.Rotate(180, 0, 0);
                if (psm.rb.gravityScale > 0) psm.rb.gravityScale = psm.airgravityscale * -1;
                else psm.rb.gravityScale = psm.airgravityscale;
                psm.playersounds.playgravityswitch();
                platformrotate?.Invoke();
            }
        }
    }
    public void triggerplatformrotate()
    {
        platformrotate?.Invoke();
    }
    public void resetgravity()
    {
        Globalcalls.currentgravitystacks = 0;
        Cooldowns.instance.handlegravitystacks();
        if (psm.gravityswitchactiv == true)
        {
            psm.gravityswitchactiv = !psm.gravityswitchactiv;
            psm.transform.Rotate(180, 0, 0);
            psm.rb.gravityScale = psm.airgravityscale;
            platformrotate?.Invoke();
        }
    }
}
