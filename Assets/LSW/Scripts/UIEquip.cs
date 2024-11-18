using UnityEngine;
using UnityEngine.UI;

public class UIEquip : MonoBehaviour
{
    public Transform equipSlotContainer;  // 아이템 슬롯을 담을 UI 컨테이너
    public GameObject equipSlotPrefab;    // 아이템 슬롯 프리팹
    public int maxSlots = 9;              // 슬롯 개수 (9개)
    public Inventory inventory;           // 인벤토리 참조

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Start()
    {
        InitializeSlots();
    }

    // 슬롯을 초기화하는 메서드 (9개의 슬롯을 생성)
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

                // 아이템 아이콘을 비활성화
                Transform iconTransform = newSlot.transform.Find("Icon");
                if (iconTransform != null)
                {
                    Image iconImage = iconTransform.GetComponent<Image>();
                    if (iconImage != null)
                    {
                        iconImage.enabled = false;  // 초기에는 아이콘을 비활성화
                    }
                }
            }
        }
    }

    // 아이템을 장착하는 메서드
    public void EquipItem(ItemSO item, int slotIndex)
    {
        if (item != null)
        {
            // 슬롯의 자식 중 "Icon"이라는 이름을 가진 객체를 찾음
            Transform slot = equipSlotContainer.GetChild(slotIndex);
            Image iconImage = slot.Find("Icon").GetComponent<Image>();  // 아이콘을 표시할 Image 컴포넌트 찾기

            // 아이템 아이콘을 비활성화한 후, 장착 시 활성화
            if (iconImage != null)
            {
                iconImage.enabled = true;  // 아이템 아이콘 활성화
                iconImage.sprite = item.icon;  // 아이템 아이콘 설정
                Debug.Log("Equipped item: " + item.name);
            }
        }
        else
        {
            Debug.Log("No item to equip.");
        }
    }

    // 아이템을 장착 해제하는 메서드 (우클릭 시 호출)
    public void UnequipItem(int slotIndex)
    {
        // 슬롯의 자식 중 "Icon"이라는 이름을 가진 객체를 찾음
        Transform slot = equipSlotContainer.GetChild(slotIndex);
        Image iconImage = slot.Find("Icon").GetComponent<Image>();  // 아이콘을 표시할 Image 컴포넌트 찾기

        if (iconImage != null && iconImage.enabled)  // 아이콘이 활성화되어 있는지 확인
        {
            // 해당 슬롯에서 아이템을 가져옴
            ItemSO item = inventory.GetItemInSlot(slotIndex);  // 해당 슬롯의 아이템을 가져옴 (아이템이 있다면)

            iconImage.sprite = null;  // 아이템 아이콘 제거
            iconImage.enabled = false;  // 아이템 아이콘 숨기기
            Debug.Log("Unequipped item: " + item.name);

            // 인벤토리에 아이템 추가
            inventory.AddItem(item);
        }
        else
        {
            Debug.Log("No item equipped in this slot.");
        }
    }

    // Update에서 마우스 우클릭 감지
    void Update()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            // 마우스 우클릭을 감지하여 해당 슬롯에서 아이템 해제
            if (Input.GetMouseButtonDown(1))  // 1은 우클릭
            {
                UnequipItem(i);  // 해당 슬롯의 아이템 해제
            }
        }
    }
}
