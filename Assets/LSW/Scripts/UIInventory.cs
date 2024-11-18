using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Inventory inventory;  // 인벤토리 참조
    public Transform itemSlotContainer;  // 아이템 슬롯을 담을 UI 컨테이너
    public GameObject itemSlotPrefab;  // 아이템 슬롯 프리팹
    public int maxSlots = 36;  // 슬롯 개수 (고정)

    public Text itemNameText;
    public Text itemDescriptionText;

    void Start()
    {
        // 인벤토리 슬롯 UI 생성 (슬롯이 없을 경우 동적으로 생성)
        InitializeSlots();
    }

    private void Update()
    {
        UpdateUI();
    }

    // 슬롯을 초기화하는 메서드
    void InitializeSlots()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            if (itemSlotContainer.childCount <= i)
            {
                GameObject newSlot = Instantiate(itemSlotPrefab, itemSlotContainer);  // 새로운 슬롯을 생성
                newSlot.name = "Slot_" + i;  // 슬롯 이름 지정

                // 생성한 슬롯의 ItemSlot 컴포넌트를 가져와 인덱스를 설정
                ItemSlot slotComponent = newSlot.GetComponent<ItemSlot>();
                if (slotComponent != null)
                {
                    slotComponent.index = i;  // 고유 인덱스 번호 지정
                }
            }
        }
    }

    // 인벤토리의 아이템을 UI에 반영하는 메서드
    public void UpdateUI()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slot = itemSlotContainer.GetChild(i).gameObject;
            ItemSlot slotComponent = slot.GetComponent<ItemSlot>();

            if (i < inventory.items.Count)  // 인벤토리에 아이템이 있는 경우
            {
                ItemSO item = inventory.items[i];
                slotComponent.SetItem(item);  // Item과 아이콘 설정
                slot.SetActive(true);  // 슬롯을 활성화
            }
            else  // 인벤토리에 아이템이 없는 경우
            {
                if (slotComponent != null)
                {
                    slotComponent.SetItem(null);  // 슬롯 비우기 (아이콘 초기화)
                }
                slot.SetActive(true);  // 비어 있는 슬롯도 활성화 상태 유지
            }
        }
    }

    public void ClearSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < maxSlots)
        {
            // 인벤토리의 해당 슬롯의 아이템 제거
            if (slotIndex < inventory.items.Count)
            {
                inventory.items.RemoveAt(slotIndex);  // 아이템 제거
            }

            // UI 업데이트
            GameObject slot = itemSlotContainer.GetChild(slotIndex).gameObject;
            ItemSlot slotComponent = slot.GetComponent<ItemSlot>();

            if (slotComponent != null)
            {
                slotComponent.SetItem(null);  // 슬롯 비우기 (아이콘 초기화)
            }

            UpdateUI();  // 전체 UI 갱신
        }
    }
}
