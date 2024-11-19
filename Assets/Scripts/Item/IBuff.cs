public interface IBuff
{
    void ApplyBuff(Player player);      
    void RemoveBuff(Player player);    
    float BuffDuration { get; }         
}
