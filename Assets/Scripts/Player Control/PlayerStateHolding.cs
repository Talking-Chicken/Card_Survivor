using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHolding : PlayerStateBase
{
    public override void enterState(PlayerControl player){
        Cursor.visible = false;
        player.Shadow.gameObject.SetActive(true);
    }
    public override void updateState(PlayerControl player){
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z-1));
            player.CurrentCard.transform.position = new Vector3(mousePos.x, 1, mousePos.z);
            player.Shadow.transform.position = new Vector3(player.CurrentCard.transform.position.x, 0.5f, player.CurrentCard.transform.position.z);
            //Debug.Log(mousePos);
        }
        else
            player.changeState(player.stateIdle);
    }
    public override void leaveState(PlayerControl player){
        Cursor.visible = true;
        player.Shadow.gameObject.SetActive(false);
    }
}
