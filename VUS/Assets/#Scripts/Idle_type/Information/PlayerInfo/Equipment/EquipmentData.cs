using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentData//장비 데이터
{
    public string name;             //장비 이름 
    public string info;             //장비의 설명
    public int level;               //장비 레벨
    public int id;                  //장비 아이디
    //강화할 수 있는 능력치 => 강화했을 때 이전 레벨보다 모든 스탯이 10% 증가
    public float attackPower;
    public float magicPower;
    public float speed;
    public float maxHp;
    public float maxMp;
    public float dp;
    public float mr;
    public float cri;
    public float criDmg;

    public int upgradeCost;         //업그레이드 하는데 필요한 비용

    public EQUIPMENTTYPE type;      //장비 타입 
    public EQUIPMENTSYNERGY synergy;//장비에 해당하는 시너지
    public EQUIPMENTSKILL skill;    //무기 스킬
}
