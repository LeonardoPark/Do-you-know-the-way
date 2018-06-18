using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using CodingGame_KOI.game;

namespace CodingGame_KOI
{
    class CodeblockManager
    {
        private Form frmGame = null;
        private PictureBox picSource = null;
        private List<PictureBox> blockList = null;

        /*
         * code block will append to frmGame form.
         * picSource will use when create a code block as replica.
        */
        public CodeblockManager(Form frmGame, PictureBox picSource)
        {
            this.frmGame = frmGame;
            this.picSource = picSource;
            this.blockList = new List<PictureBox>();
        }


        // returns code blocks list after convert image to character direction.
        public List<Character.DIRECTION> getCodeblocks()
        {
            List<Character.DIRECTION> list = new List<Character.DIRECTION>();

            foreach(PictureBox e in blockList)
            {
                list.Add(getDirectionFromPicturebox(e));
            }
            clearAll();

            return list;
        }


        // returns DOWN if occur error.
        private Character.DIRECTION getDirectionFromPicturebox(PictureBox pb)
        {
            try
            {
                if (pb.Image == null)
                    throw new Exception("hasn't a image.");
                
                Character.DIRECTION[] dir = { Character.DIRECTION.UP, Character.DIRECTION.DOWN, Character.DIRECTION.LEFT, Character.DIRECTION.RIGHT};
                string[] resourceNames = { "up", "down", "left", "right" };
                
                for (int i = 0; i < resourceNames.Length; i++)
                {
                    string n = resourceNames[i];
                    if (n == pb.Name)
                        return dir[i];
                }

                throw new Exception("not matched.");
            }
            catch
            {
                return Character.DIRECTION.DOWN;
            }
        }

        // remove all elements to blockList.
        private void clearAll()
        {
            foreach(PictureBox e in blockList)
            {
                this.frmGame.Controls.Remove(e);
            }
            blockList.Clear();
        }

        // remove a last element to blockList.
        public void removeLastBlock()
        {
            if (blockList.Count >= 1)
            {
                PictureBox e = blockList.Last();
                this.frmGame.Controls.Remove(e);
                blockList.Remove(e);
            }
        }

        public void addBlock(Character.DIRECTION dir)
        {
            PictureBox picBlock = null;

            try
            {
                string resourceName = "";

                switch (dir)
                {
                    case Character.DIRECTION.UP:
                        resourceName = "up";
                        break;
                    case Character.DIRECTION.DOWN:
                        resourceName = "down";
                        break;
                    case Character.DIRECTION.LEFT:
                        resourceName = "left";
                        break;
                    case Character.DIRECTION.RIGHT:
                        resourceName = "right";
                        break;
                }
                
                // create a code block
                Bitmap imgBlock = (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                picBlock = new PictureBox();
                picBlock.Size = picSource.Size;
                picBlock.Location = (blockList.Count == 0) ? picSource.Location : blockList.Last().Location;
                picBlock.Height /= 2;
                if (blockList.Count == 0)
                    picBlock.Top += picSource.Height + 10;
                else
                    picBlock.Top += picBlock.Height + 10;
                picBlock.SizeMode = PictureBoxSizeMode.StretchImage;
                picBlock.Image = imgBlock;
                picBlock.Name = resourceName;

                blockList.Add(picBlock);
                frmGame.Controls.Add(picBlock);
            }
            catch
            {
                // pass
            }
        }
            
    }
}
