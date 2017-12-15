using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_MyInfo : MonoBehaviour {
	// Use this for initialization
	void Awake () {
        MyInfo.money = 1000000;
        MyInfo.crystal = 1000000;
        MyInfo.towelHP = 100;
        MyInfo.hero = new List<HeroInfo>();
        for (int i = 4; i < 8; i++) MyInfo.hero.Add(new HeroInfo(i, 0));
        MyInfo.settingHero = new List<HeroInfo>();
        for (int i = 4; i < 8; i++) MyInfo.settingHero.Add(new HeroInfo(i, 0));
        for (int i = 0; i < 4; i++) MyInfo.hero.Add(new HeroInfo(i, 0));
        MyInfo.settingHero = new List<HeroInfo>();
        for (int i = 0; i < 4; i++) MyInfo.settingHero.Add(new HeroInfo(i, 0));
        MyInfo.minerID = 0;
        MyInfo.fontType = new List<FontType>();
        MyInfo.fontType.Add(FontType.PigBar);
    }
}
