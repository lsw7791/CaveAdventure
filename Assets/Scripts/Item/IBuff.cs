public interface IBuff
{
    float BuffDuration { get; }                     // 버프 지속 시간
    void ApplyBuff(Player player);                  // 버프 적용
    void RemoveBuff(Player player);                 // 버프 해제
    void ActivateEffect(Player player);             // 버프 효과 활성화
    void DeactivateEffect(Player player);           // 버프 효과 비활성화
}
