using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodingGame_KOI.game;

namespace CodingGame_KOI
{
    public partial class frmGame : Form
    {

        // constanats
        private const int REFRESH_TIME = 10;

        // the objects that related game.
        private Timer tmRefresh;
        private Character character;

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            initCharacter();
            initEvent();
        }

        private void initEvent()
        {
            tmRefresh = new Timer();
            tmRefresh.Tick += new EventHandler(refresh);
            tmRefresh.Interval = REFRESH_TIME;
            tmRefresh.Enabled = true;
        }

        private void refresh(object sender, EventArgs e)
        {
            gameScreen.Invalidate();
        }

        private void initCharacter()
        {
            this.character = new Character(4, 1, Character.DIRECTION.DOWN);
        }

        private Bitmap loadImageFromResources(string resourceName)
        {
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
        }

        private void drawCharacter(Graphics g)
        {
            Bitmap characters = loadImageFromResources("characters");
            int imgWidth, imgHeight;
            int chWidth, chHeight;
            
            imgWidth = characters.Width;
            imgHeight = characters.Height;

            chWidth = imgWidth / 12;
            chHeight = imgHeight / 8;

            Point imgSrcXY = new Point();
            Point imgDestXY = new Point();

            
            imgSrcXY.X = chWidth * ( (character.ChNo >= 4) ? character.ChNo - 4 : character.ChNo ) * 3 + chWidth * character.ChMotion;
            imgSrcXY.Y = ((character.ChNo >= 4) ? chHeight * 4 : 0) + chHeight * (int)character.ChDirection;

            imgDestXY.X = character.X;
            imgDestXY.Y = character.Y;

            g.DrawImage(characters,
                new Rectangle(imgDestXY, new Size(chWidth, chHeight)),
                new Rectangle(imgSrcXY, new Size(chWidth, chHeight)),
                GraphicsUnit.Pixel
            );
        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bg = loadImageFromResources("background");
            Graphics g = e.Graphics;

            g.DrawImage(bg, new Rectangle(new Point(0, 0), gameScreen.Size));
            drawCharacter(g);
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    character.move(Character.DIRECTION.UP);
                    break;
                case Keys.Down:
                    character.move(Character.DIRECTION.DOWN);
                    break;
                case Keys.Left:
                    character.move(Character.DIRECTION.LEFT);
                    break;
                case Keys.Right:
                    character.move(Character.DIRECTION.RIGHT);
                    break;
            }
        }
    }
}
