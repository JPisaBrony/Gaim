﻿using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using QuickFont;
using System.Drawing;

namespace DungeonShambles.UI
{
    public class Inventory
    {
        // variables
        QFont header, testText;
        String testString;
        string title = "Inventory";

        TextureImporter text1;

        int maxSlot = 15;


        public Inventory()
        {
            header = new QFont("UI/Fonts/ModerneFraktur.ttf", 35);
            header.Options.Colour = new Color4(0.3f, 0.5f, 0.4f, 1.0f);
            header.Options.DropShadowActive = true;

            text1 = new TextureImporter();
            text1.importTexture("Images/800x60.jpg");

            // test
            testString = "TESTING\n Testng";

            testText = new QFont("Fonts/times.ttf", 30, FontStyle.Bold);
            testText.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);
        }


        public void RenderMenu()
        {
            float yOffset = 20;

            text1.renderTexture(1.0f, 0f, 0f);

            QFont.Begin();
            header.Print(title, QFontAlignment.Right);

            yOffset += 100;

            for (int i = 0; i < 4; i++)
            {
                DrawBox(new RectangleF(50f, yOffset, 100, 80), ref yOffset);
                DrawBox(new RectangleF(170f, yOffset, 100, 80), ref yOffset);
                DrawBox(new RectangleF(290f, yOffset, 100, 80), ref yOffset);
                DrawBox(new RectangleF(410f, yOffset, 100, 80), ref yOffset);
                DrawBox(new RectangleF(530f, yOffset, 100, 80), ref yOffset);
                DrawBox(new RectangleF(650f, yOffset, 100, 80), ref yOffset);
                yOffset += 130f;
            }

            QFont.End();
        }


        // box with text
        public void TextBorders(QFont font, string text, RectangleF bounds, QFontAlignment alignment, ref float yOffset)
        {
            float maxWidth = bounds.Width;
            float height = font.Measure(text, maxWidth, alignment).Height;

            GL.Begin(BeginMode.LineLoop);
            GL.Vertex3(bounds.X, bounds.Y, 0f);
            GL.Vertex3(bounds.X + bounds.Width, bounds.Y, 0f);
            GL.Vertex3(bounds.X + bounds.Width, bounds.Y + height, 0f);
            GL.Vertex3(bounds.X, bounds.Y + height, 0f);
            GL.End();

            font.Print(text, maxWidth, alignment, new Vector2(bounds.X, bounds.Y));

            yOffset += height;
        }

        // draw box
        public void DrawBox(RectangleF bounds, ref float yOffset)
        {
            // currently under title
            float height = 100f;

            GL.Begin(PrimitiveType.LineLoop);
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.Vertex3(bounds.X, bounds.Y, 0f);
            GL.Vertex3(bounds.X + bounds.Width, bounds.Y, 0f);
            GL.Vertex3(bounds.X + bounds.Width, bounds.Y + height, 0f);
            GL.Vertex3(bounds.X, bounds.Y + height, 0f);
            GL.End();
        }
    }
}
