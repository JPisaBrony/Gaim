using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Items;
using DungeonShambles.Cranting;

namespace DungeonShambles.Entities
{
	class Ghost : GameEntities
	{
		const String image = "meshes/Ghost/GhoastFrontStanding.png";
		private static String[] images = {
			"meshes/Ghost/GhostFrontStanding.png",
			"meshes/Ghost/GhostFrontStep1.png",
			"meshes/Ghost/GhostFrontStep2.png",
			"meshes/Ghost/GhostBackStanding.png",
			"meshes/Ghost/GhostBackStep1.png",
			"meshes/Ghost/GhostBackStep2.png",
			"meshes/Ghost/GhostLeftStanding.png",
			"meshes/Ghost/GhostLeftStep1.png",
			"meshes/Ghost/GhostLeftStep2.png",
			"meshes/Ghost/GhostRightStanding.png",
			"meshes/Ghost/GhostRightStep1.png",
			"meshes/Ghost/GhostRightStep2.png"
		};
		const float initialSpeed = 0.015f;
		const Double initialHealth = 10;
		const Double initialMana = 0;
		const Double initialMeleeModifier = 10;
		const Double initialMagicModifier = 0;

		public Ghost(float initialX, float initialY) :
		base(image, initialX, initialY, initialSpeed, initialHealth, initialMana, initialMeleeModifier, initialMagicModifier)
		{
		}
	}
}
