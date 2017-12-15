using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class StoreState
{
    public static int selpackNum;
    public static int selgoldNum;
    public static int selCrystalNum;
    public enum selobjState : int {
        Init = -1, Gold = 0, Pack, Crystal
    };

    public static void InitSel()
    {
        selpackNum = selgoldNum = selCrystalNum = - 1;
    }
    public static void InitSel(int sel)
    {
        switch (sel)
        {
            case (int)selobjState.Gold:
                selpackNum = -1;
                selCrystalNum = -1;
                break;
            case (int)selobjState.Pack:
                selgoldNum = -1;
                selCrystalNum = -1;
                break;
            case (int)selobjState.Crystal:
                selpackNum = -1;
                selgoldNum = -1;
                break;
        }
    }
}

