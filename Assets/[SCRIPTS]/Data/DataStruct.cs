using UnityEngine;

public struct DataStruct
{
    #region Properties

    public string Name { get; }

    public RarityOfCard Rarity { get; set; }

    public int ID { get; }

    public bool IsOwned { get; set; }

    public TypeOfCard TypeOfCard { get; }

    public Sprite Sprite { get; set; }

    #endregion
    
    /**
     * Constructor
     * 
     * @name
     * @rarity
     * @id
     * @isOwned
     * @typeOfCard
     * @sprite
     */
    public DataStruct(string name, RarityOfCard rarity, int id, bool isOwned, TypeOfCard typeOfCard, Sprite sprite)
    {
        Name = name;
        Rarity = rarity;
        ID = id;
        IsOwned = isOwned;
        TypeOfCard = typeOfCard;
        Sprite = sprite;
    }
}

public enum RarityOfCard
{
    NONE,
    Common,
    Rare,
    Special
}

public enum TypeOfCard
{
    NONE,
    BurCA,
    Staff,
    Ext,
    Com,
    Part,
    Int,
    Louv,
    OLD
}
