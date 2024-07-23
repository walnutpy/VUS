using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WearingEquipment : MonoBehaviour
{
    EquipmentData equipmentData;            //착용한 장비의 데이터
    [SerializeField]EQUIPMENTTYPE equipType;//해당 칸의 무기 타입
    [SerializeField] Sprite[] sprite;       //장비들의 이미지 
    [SerializeField] Image img;             //해당 칸 이미지 변환 
    [SerializeField] string path;           //해당 칸의 경로 설정
    [SerializeField] GameObject wearingEquipInfo;
    [SerializeField] GameObject Blocker;
    private void Start()
    {
        DataLoad();
    }

    void DataLoad() //데이터 로드 과정
    {
        string filePath = Path.Combine(Application.dataPath, path);

        if (File.Exists(filePath))
        {
            // JSON 파일 읽기
            string jsonData = File.ReadAllText(filePath);

            // JSON 데이터를 EquipmentData 객체로 변환
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);
            img.sprite = sprite[equipmentData.id];
        }
        else
        {
            Debug.LogError("Cannot find JSON file at " + filePath);
        }
    }
    
    public void ShowButton()//데이터를 보여주는 버튼 
    {
        Blocker.GetComponent<Canvas>().sortingOrder += 1;
        wearingEquipInfo.SetActive(true);
        wearingEquipInfo.transform.GetChild(2).GetComponent<Text>().text = equipmentData.name;
        wearingEquipInfo.transform.GetChild(5).GetComponentInChildren<Text>().text =
            $"{((equipmentData.attackPower != 0) ? "공격력 : + " + equipmentData.attackPower + "\n" : null)}" +
            $"{((equipmentData.magicPower != 0) ? "주문력 : + " + equipmentData.magicPower + "\n" : null)}" +
            $"{((equipmentData.speed != 0) ? "이동 속도 : + " + equipmentData.speed + "\n" : null)}" +
            $"{((equipmentData.maxHp != 0) ? "육체강화 : + " + equipmentData.maxHp/10 + "\n" : null)}" +
            $"{((equipmentData.cri != 0) ? "치명타 : + " + equipmentData.cri + "\n" : null)}" +
            $"{((equipmentData.criDmg != 0) ? "치명타 데미지 : + " + equipmentData.criDmg + "\n" : null)}";
        SynergySort();
    }

    void SynergySort()
    {
        switch (equipmentData.synergy)
        {
            case EQUIPMENTSYNERGY.NONE:
                for (int i = 0; i < 6; i++)
                {
                    wearingEquipInfo.transform.GetChild(6).GetChild(i).GetComponent<Text>().text = null;
                }
                break;
            default:
                break;
        }
    }
}
