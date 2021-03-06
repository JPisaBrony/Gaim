using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Items;
using DungeonShambles.Cranting;

namespace DungeonShambles.Entities
{
    class Player : GameEntities
    {
		private static String[] images = {
			"meshes/Steve/SteveFrontStanding.png",
			"meshes/Steve/SteveFrontStep1.png",
			"meshes/Steve/SteveFrontStep2.png",
			"meshes/Steve/SteveBackStanding.png",
			"meshes/Steve/SteveBackStep1.png",
			"meshes/Steve/SteveBackStep2.png",
			"meshes/Steve/SteveLeftStanding.png",
			"meshes/Steve/SteveLeftStep1.png",
			"meshes/Steve/SteveLeftStep2.png",
			"meshes/Steve/SteveRightStanding.png",
			"meshes/Steve/SteveRightStep1.png",
			"meshes/Steve/SteveRightStep2.png"
		};

        private Double crafting;
        private Double enchanting;
        private Weapon weapon;
        private OffHand offHand;
        private Helm helm;
        private Chest chest;
        private Legs legs;
        private Gloves gloves;
        private Boots boots;

        public Double Crafting { get; set; }
        public Double Enchanting { get; set; }
        public Double Weapon { get; set; }
        public Double OffHand { get; set; }
        public Double Helm { get; set; }
        public Double Chest { get; set; }
        public Double Legs { get; set; }
        public Double Gloves { get; set; }
        public Double Boots { get; set; }
                
		public Player() : base(images, 3, 4, 5)
        {
            crafting = 0;
            enchanting = 0;
            weapon = new PhysicalWeapon();
            offHand = new OffHand();
            helm = new Helm();
            chest = new Chest();
            legs = new Legs();
            gloves = new Gloves();
            boots = new Boots();
        }
    }
}
