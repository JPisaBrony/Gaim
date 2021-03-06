﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class GameEntities
    {
		//Dimension for rectangular collision box
		//Center of character is coordinate 0,0
		protected float collisionOffset = Globals.TextureSize / 2;
		// create a texture for the character
		protected TextureImporter characterImage = new TextureImporter ();
        protected double currentHealth;
		protected double currentMana;
		protected double meleeModifier;
		protected double magicModifier;
		// character x and y position
		protected float x, y;
		// character movement speed can only be multiples of 2
		protected float speed;
		protected Room currentRoom;
		// used for creating an animation
		private Animation[] animiation;
		// entity rotation
		private int currentRotation;
		// if the entity is moving or not
		private Boolean moving;

        public GameEntities(String ci, Room room)
        {
			characterImage.importTexture (ci);
			x = 0f;
			y = 0f;
			speed = 0.025f;
            currentHealth = 100;
            currentMana = 100;
            meleeModifier = 0;
            magicModifier = 0;
            currentRoom = room;
        }

		public GameEntities(String[] anims, int animSetSize, int animSetAmount, int delay) {
			String[] sets = new String[animSetSize];
			animiation = new Animation[animSetAmount];
			int animationToPutInSet = 0;
			for (int i = 0; i < animSetAmount; i++) {
				for (int j = 0; j < animSetSize; j++) {
					sets [j] = anims [animationToPutInSet];
					animationToPutInSet++;
				}
				animiation[i] = new Animation (sets, delay, false);
			}
			x = 0f;
			y = 0f;
			speed = 0.025f;
			currentHealth = 100;
			currentMana = 100;
			meleeModifier = 10;
			magicModifier = 0;
			currentRotation = 0;
			moving = false;
		}

		public GameEntities(string ci, float inputX, float inputY)
		{
			characterImage.importTexture (ci);
			x = 0f;
			y = 0f;
			speed = 0.015f;
			currentHealth = 100;
			meleeModifier = 0;
			magicModifier = 0;
		}

		public GameEntities(string ci, float initialX, float initialY,
			float initialSpeed, double h, double m, double cMod, double aMod)
        {
			characterImage.importTexture (ci);
			x = initialX;
			y = initialY;
			speed = initialSpeed;
            currentHealth = h;
            currentMana = m;
            meleeModifier = cMod;
            magicModifier = aMod;
        }

		public void chase(GameEntities target, Dungeon dung)
		{
			if (target.getX () > x)
				changeX (1, dung);
			else if (target.getX () + speed < x)
				changeX (-1, dung);
			else if (target.getY () > y)
				changeY (1, dung);
			else if (target.getY () + speed < y)
				changeY (-1, dung);
		}

		public void renderCharacter() 
		{
			characterImage.renderTexture (Globals.TextureSize, x, y);
		}

		public void renderAnimation(int animSet, float size, float x, float y, Boolean moving) {
			animiation[animSet].renderAnimation(size, x, y);
			if (moving)
				animiation [animSet].setPlaying (true);
			else {
				animiation [animSet].setPlaying (false);
				animiation [animSet].setToFrame (0);
			}
		}

        public Boolean changeX(float delta, Dungeon dung) 
		{
            float mod = Globals.TextureSize * -1 / 4;
            if (delta > 0)
                mod = Globals.TextureSize * 2;
            
            try
            {
                currentRoom.getTileAtLocation((int)(x*5+delta > 0 ? 1 : 0), (int)(y*5+delta > 0 ? 1 : 0));
                if (!collisionTests.wallCollision(currentRoom, (x + mod - currentRoom.getOffsetX()), (y - currentRoom.getOffsetY())))
                {
                    x += delta * speed;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                collisionTests.setCurrentRoom(this, delta > 0 ? 3 : 1, dung);
                return false;
            }


		}

        public Boolean changeY(float delta, Dungeon dung)
        {
            float mod = Globals.TextureSize * -1 / 4;
            if (delta > 0)
                mod = Globals.TextureSize * 2;

            try
            {
                currentRoom.getTileAtLocation((int)(x*5+delta > 0 ? 1 : 0), (int)(y*5+delta > 0 ? 1 : 0));
                if (!collisionTests.wallCollision(currentRoom, (x - currentRoom.getOffsetX()), (y + mod - currentRoom.getOffsetY())))
                {
                    y += delta * speed;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                collisionTests.setCurrentRoom(this, delta > 0 ? 2 : 0, dung);
                return false;
            }
            

		}

		public void changeImage(int direction)
		{
			characterImage.removeTexture ();
			switch(direction)
			{
			case 0:
				characterImage.importTexture ("meshes/Sword/swordDown.png");
				break;
			case 1:
				characterImage.importTexture ("meshes/Sword/swordLeft.png");
				break;
			case 2:
				characterImage.importTexture ("meshes/Sword/swordUp.png");
				break;
			case 3:
				characterImage.importTexture ("meshes/Sword/swordRight.png");
				break;
			}
		}

		public double getDamage() 
		{
			return meleeModifier;
		}

		public void changeHealth(double damage)
		{
			currentHealth -= damage;
		}

		public void setHealth(){
			currentHealth = Globals.maxHealth;
		}

		public float getSpeed() 
		{
			return speed;
		}

		public float getX()
		{
			return x;
		}

		public float getY()
		{
			return y;
		}

		public void setX(float inputX) {x = inputX;}
		public void setY(float inputY) {y = inputY;}

		public Boolean getMoving() {
			return moving;
		}

		public int getRotation() {
			return currentRotation;
		}
			
		public void setMoving(Boolean m) {
			moving = m;
		}

		public void setRotation(int r) {
			currentRotation = r;
		}

        public void setCurrentRoom(Room cr) {
            currentRoom = cr;
        }

        public Room getCurrentRoom() {
            return currentRoom;
        }
        
        public double getHealth()
        {
            return currentHealth;
        }
    }    
}
