using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
    public override void enterState(PlayerControl player){}
    public override void updateState(PlayerControl player){
        if (Input.GetMouseButtonDown(0))
            if (player.selectCard())
                player.changeState(player.stateHolding);
    }
    public override void leaveState(PlayerControl player){}
}
