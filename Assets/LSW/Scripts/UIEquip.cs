using UnityEngine;
using UnityEngine.UI;

public class UIEquip : MonoBehaviour
{
    public Transform equipSlotContainer;  // 아이템 슬롯을 담을 UI 컨테이너
    public GameObject equipSlotPrefab;  // 아이템 슬롯 프리팹
    public int maxSlots = 9;  // 슬롯 개수 (고정)
    public Image equipSlotImage;  // 장착 아이템을 보여줄 슬롯의 이미지
    public Inventory inventory;  // Inventory 인스턴스

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    void Start()
    {
        InitializeSlots();
    }

    // 아이템을 장착하는 메서드
    public void EquipItem(ItemSO item)
    {
        // 장착 슬롯에 아이템을 할당
        equipSlotImage.sprite = item.icon;  // 장착 슬롯에 아이템의 아이콘만 표시
        equipSlotImage.enabled = true;  // 장착 슬롯 이미지 보이게 설정
    }

    // 아이템을 장착 해제하는 메서드 (우클릭 시 호출)
    public void UnequipItem(ItemSO item)
    {
        // 장비창에서 아이템을 제거하고
        equipSlotImage.sprite = null;
        equipSlotImage.enabled = false;

        // 인벤토리에 아이템 추가
        inventory.AddItem(item);
    }

    // 슬롯 초기화 메서드
    void InitializeSlots()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            if (equipSlotContainer.childCount <= i)
            {
                GameObject newSlot = Instantiate(equipSlotPrefab, equipSlotContainer);  // 새로운 슬롯을 생성
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
}
