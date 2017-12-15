using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyInfo
{
    // 인게임 말고 외적인 변수
    public static float crystal; // 캐쉬
    //
    public static float money;
    public static int towelHP;
    public static List<HeroInfo> hero;
    public static List<HeroInfo> settingHero;
    public static int minerID;
    public static List<FontType> fontType;
    public static FontType settingFont;

    public static HeroInfo getSettingHeroByloc(int loc)
    {
        if (settingHero.Count < (loc + 1)) return new HeroInfo();
        
        return settingHero[loc];
    }
}
