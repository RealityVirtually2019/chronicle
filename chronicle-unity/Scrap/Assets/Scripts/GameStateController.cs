using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameStateController
{
    public enum ChronicleState {Edit, View};
    public static ChronicleState CurrentState = ChronicleState.Edit;

    public static UnityEvent OnChronicleStateChanged = new UnityEvent();

    public static void ToggleChronicleState(){

        if(CurrentState == ChronicleState.Edit){
            CurrentState = ChronicleState.View;
        }else{
            CurrentState = ChronicleState.Edit;
        }

        OnChronicleStateChanged.Invoke();
    }
}
