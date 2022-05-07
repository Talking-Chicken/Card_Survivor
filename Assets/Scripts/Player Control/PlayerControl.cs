using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Card currentCard;
    [SerializeField] private CardShadow shadow; //appears during holding state, indicates where will the holding card land

    //getters & setters
    public Card CurrentCard {get => currentCard; set => currentCard = value;}
    public CardShadow Shadow {get => shadow;}
    
    private PlayerStateBase currentState;
    public PlayerStateIdle stateIdle = new PlayerStateIdle();
    public PlayerStateHolding stateHolding = new PlayerStateHolding();
    public void changeState(PlayerStateBase newState) {
        if (newState != currentState) {
            if (currentState != null)
            {
                currentState.leaveState(this);
            }

            currentState = newState;

            if (currentState != null)
            {
                currentState.enterState(this);
            }
        }
    }
    void Start()
    {
        changeState(stateIdle);
    }

    
    void Update()
    {
        currentState.updateState(this);
    }

    /* return the card that player cursor is hovering*/
    public Card hoveringCard() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (hit.transform.GetComponent<Card>() != null)
                return hit.transform.GetComponent<Card>();
        
        return null;
    }

    /* select currently hovering card (if there's one)
       return true if selected sucessfully, false if nothing to select */
    public bool selectCard() {
        if (hoveringCard() != null) {
            CurrentCard = hoveringCard();
            return true;
        } else {
            return false;
        }
    }
}
