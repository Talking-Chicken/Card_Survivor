using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase
{
    public virtual void enterState(PlayerControl player){}
    public virtual void updateState(PlayerControl player){}
    public virtual void leaveState(PlayerControl player){}
}
