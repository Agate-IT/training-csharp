namespace GildedRose;

/// <summary>
/// Représente un article de l'inventaire.
/// ATTENTION : Ne modifiez pas cette classe ! Elle appartient au gobelin du coin.
/// </summary>
public class Item
{
    public string Name { get; set; } = string.Empty;
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public override string ToString()
    {
        return $"{Name}, {SellIn}, {Quality}";
    }
}
