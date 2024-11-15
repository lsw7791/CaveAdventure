using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public int index;  // 슬롯의 고유 인덱스 번호
    private Image slotImage;  // 슬롯의 Icon 이미지
    private ItemSO currentItem;  // 현재 슬롯의 아이템
    public UIEquip uiEquip;
    public UIInventory uiInventory;
    // 외부 텍스트 UI를 할당하기 위한 변수
    public Text itemNameText;  // 아이템 이름을 표시할 텍스트
    public Text itemDescriptionText;  // 아이템 설명을 표시할 텍스트

    void Awake()
    {
        itemNameText = uiInventory.itemNameText;
        itemDescriptionText = uiInventory.itemDescriptionText;

        // Icon이라는 이름의 자식 Image 컴포넌트를 찾아서 할당
        slotImage = transform.Find("Icon").GetComponent<Image>();

        if (slotImage != null)
        {
            slotImage.enabled = false;  // 초기에는 비활성화된 상태
        }
    }

    // 이미지와 아이템 할당 메서드
    public void SetItem(ItemSO item)
    {
        currentItem = item;
        if (slotImage != null && item != null)
        {
            slotImage.sprite = item.icon;  // 아이템 아이콘 설정
            slotImage.enabled = true;  // 이미지 활성화
        }
        else if (slotImage != null)
        {
            slotImage.enabled = false;  // 아이템이 없을 경우 비활성화
        }
    }

    // 아이콘 클릭 시 호출될 메서드
    public void OnClickIcon()
    {
        if (currentItem != null && itemNameText != null && itemDescriptionText != null)
        {
            // 아이템의 이름과 설명을 텍스트에 표시
            itemNameText.text = currentItem.itemName;  // ItemSO에 정의된 아이템 이름
            itemDescriptionText.text = currentItem.description;  // ItemSO에 정의된 아이템 설명
        }
    }

    
    public void OnEquip()
    {
        if (currentItem != null)
        {
            uiEquip.EquipItem(currentItem);

            currentItem = null;
            if (slotImage != null)
            {
                slotImage.sprite = null;
                slotImage.enabled = false;
            }

            itemNameText.text = "";
            itemDescriptionText.text = "";
        }
    }
}
