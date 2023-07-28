using UnityEngine;

namespace ItemResources
{
    /// <summary>
    ///  This class is responsible for managing the needs of the villager.
    ///  This class is a ScriptableObject, which means that it can be created as an asset
    ///  in the project folder. This is useful because we can create multiple instances of
    ///  this class with different values for each instance.
    /// </summary>
    public class Item : ScriptableObject
    {
        public int stackSize;

        /// <summary>
        /// The amount of space that one item takes in an inventory. For example, one apple
        /// is going to take 1 space, but a rock is going to take 5 space per item.
        /// </summary>
        public int spaceTaken;

        /// <summary>
        /// The name of the item. (only really used in UIObjectInventory.cs but
        /// will probably be used elsewhere later too)
        /// </summary>
        public string itemName;
        
        /// <summary>
        ///  The sprite of the item. (only really used in UIObjectInventory.cs)
        /// </summary>
        public Sprite sprite;
    }
}