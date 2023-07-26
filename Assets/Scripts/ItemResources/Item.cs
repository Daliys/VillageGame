using UnityEngine;

namespace ItemResources
{
    public class Item : ScriptableObject
    {
        
        public int stackSize;

        /// <summary>
        /// The amount of space that one item takes in an inventory. For example, one apple
        /// is going to take 1 space, but a rock is going to take 5 space per item.
        /// </summary>
        public int spaceTaken;
    }
}