using UnityEngine;
using VRTK_OutlineObjectCopyHighliter;

namespace Assets.Scripts
{
    public static class Crafting
    {
        public static string Craft(string a, string b)
        {
            string item = null;

            //todo: switch statement
            if (a.Contains("BasicStick"))
            {
                if (b.Contains("BasicStone"))
                {
                    item = "Hammer";
                }
                else if (b.Contains("BasicRock"))
                {
                    item = "Axe";
                }
            }

            return item;

        }
    }
}
