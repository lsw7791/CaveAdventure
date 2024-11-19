using UnityEngine;

public class UIEquip : MonoBehaviour
{
    public Transform equipSlotContainer;  // 아이템 슬롯을 담을 UI 컨테이너
    public GameObject equipSlotPrefab;    // 아이템 슬롯 프리팹
    public int maxSlots = 9;              // 슬롯 개수 (9개)
    private ItemUse itemUse;              // ItemUse 인스턴스

    private void Start()
    {
        itemUse = FindObjectOfType<ItemUse>();
        InitializeSlots();
    }

    // 슬롯을 초기화하는 메서드 (9개의 슬롯을 생성)
    void InitializeSlots()
    {
        EquipSlot[] equipSlots = new EquipSlot[maxSlots];

        for (int i = 0; i < maxSlots; i++)
        {
            if (equipSlotContainer.childCount <= i)
            {
                GameObject newSlot = Instantiate(equipSlotPrefab, equipSlotContainer);
                newSlot.name = "Slot_" + i;

                EquipSlot slotComponent = newSlot.GetComponent<EquipSlot>();
                if (slotComponent != null)
                {
                    slotComponent.index = i;  // 슬롯의 인덱스 설정
                    equipSlots[i] = slotComponent;
                }
            }
        }

        // 생성된 슬롯 배열을 ItemUse에 전달
        if (itemUse != null)
        {
            itemUse.SetEquipSlots(equipSlots);
        }
    }
}
