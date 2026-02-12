using FluentAssertions;
using Xunit;

namespace GildedRose.Tests;

public class GildedRoseTests
{
    #region Tests de caractérisation - Articles normaux

    [Fact]
    public void NormalItem_BeforeSellDate_QualityDecreasesByOne()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        items[0].SellIn.Should().Be(9);
        items[0].Quality.Should().Be(19);
    }

    [Fact]
    public void NormalItem_AfterSellDate_QualityDecreasesByTwo()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].SellIn.Should().Be(-1);
        items[0].Quality.Should().Be(18);
    }

    [Fact]
    public void NormalItem_QualityNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }

    #endregion

    #region Tests de caractérisation - Aged Brie

    [Fact]
    public void AgedBrie_QualityIncreasesWithAge()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(21);
    }

    [Fact]
    public void AgedBrie_QualityNeverExceeds50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(50);
    }

    #endregion

    #region Tests de caractérisation - Backstage passes

    [Fact]
    public void BackstagePasses_MoreThan10Days_QualityIncreasesByOne()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(21);
    }

    [Fact]
    public void BackstagePasses_10DaysOrLess_QualityIncreasesByTwo()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(22);
    }

    [Fact]
    public void BackstagePasses_5DaysOrLess_QualityIncreasesByThree()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(23);
    }

    [Fact]
    public void BackstagePasses_AfterConcert_QualityDropsToZero()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }

    #endregion

    #region Tests de caractérisation - Sulfuras

    [Fact]
    public void Sulfuras_NeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        items[0].SellIn.Should().Be(10);
        items[0].Quality.Should().Be(80);
    }

    #endregion

    #region Tests pour Conjured (à implémenter)

    // TODO: Décommentez ces tests quand vous êtes prêt à implémenter Conjured

    // [Fact]
    // public void ConjuredItem_BeforeSellDate_QualityDecreasesByTwo()
    // {
    //     var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 20 } };
    //     var app = new GildedRose(items);

    //     app.UpdateQuality();

    //     items[0].Quality.Should().Be(18);
    // }

    // [Fact]
    // public void ConjuredItem_AfterSellDate_QualityDecreasesByFour()
    // {
    //     var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 20 } };
    //     var app = new GildedRose(items);

    //     app.UpdateQuality();

    //     items[0].Quality.Should().Be(16);
    // }

    // [Fact]
    // public void ConjuredItem_QualityNeverNegative()
    // {
    //     var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 1 } };
    //     var app = new GildedRose(items);

    //     app.UpdateQuality();

    //     items[0].Quality.Should().Be(0);
    // }

    #endregion
}
