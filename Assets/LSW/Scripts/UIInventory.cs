using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Inventory inventory;  // 인벤토리 참조
    public Transform itemSlotContainer;  // 아이템 슬롯을 담을 UI 컨테이너
    public GameObject itemSlotPrefab;  // 아이템 슬롯 프리팹
    public int maxSlots = 36;  // 슬롯 개수 (고정)

    void Start()
    {
        // 인벤토리 슬롯 UI 생성 (슬롯이 없을 경우 동적으로 생성)
        InitializeSlots();

        // UI 갱신
        UpdateUI();
    }

    // 슬롯을 초기화하는 메서드
    void InitializeSlots()
    {
        // 현재 슬롯이 없거나, 슬롯의 수가 36개보다 적으면 동적으로 생성
        for (int i = 0; i < maxSlots; i++)
        {
            if (itemSlotContainer.childCount <= i)
            {
                GameObject newSlot = Instantiate(itemSlotPrefab, itemSlotContainer);  // 새로운 슬롯을 생성
                newSlot.name = "Slot_" + i;  // 슬롯 이름 지정
            }
        }
    }

    // 인벤토리의 아이템을 UI에 반영하는 메서드
    public void UpdateUI()
    {
        // 슬롯들을 순차적으로 갱신
        for (int i = 0; i < maxSlots; i++)
        {
            if (i < inventory.items.Count)  // 아이템이 있는 경우
            {
                GameObject slot = itemSlotContainer.GetChild(i).gameObject;
                slot.SetActive(true);  // 슬롯을 활성화

                // 슬롯 내 아이템 아이콘을 설정
                ItemSO item = inventory.items[i];
                Image itemIconImage = slot.GetComponentInChildren<Image>();  // 슬롯 내 Image 컴포넌트를 찾기
                if (itemIconImage != null && item.icon != null)
                {
                    itemIconImage.sprite = item.icon;  // 아이템 아이콘을 이미지로 설정
                }
            }
            else
            {
                itemSlotContainer.GetChild(i).gameObject.SetActive(false);  // 슬롯을 비활성화 (아이템이 없을 때)
            }
        }
    }
}
