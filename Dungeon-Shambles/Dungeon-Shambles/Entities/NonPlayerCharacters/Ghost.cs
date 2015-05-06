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
		const String image = "ghost.png";
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
