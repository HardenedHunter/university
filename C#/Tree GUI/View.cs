using System;
using System.Drawing;
using System.Windows.Forms;

// ReSharper disable LocalizableElement
// ReSharper disable StringLiteralTypo

namespace Tree_GUI
{
    public partial class View : Form, IView
    {
        private readonly Graphics _canvas;

        public event EventHandler<EventArgs> AddNode;
        public event EventHandler<EventArgs> DeleteNode;
        public event EventHandler<EventArgs> Clear;

        public View()
        {
            InitializeComponent();
            _canvas = panelCanvas.CreateGraphics();
            _canvas.Clip = new Region(new Rectangle(0, 0, panelCanvas.Width, panelCanvas.Height));
        }

        private void Setup()
        {
            _canvas.Clear(Color.BlueViolet);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNode?.Invoke(this, EventArgs.Empty);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteNode?.Invoke(this, EventArgs.Empty);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(this, EventArgs.Empty);
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            // Setup();
        }

        public void DrawTree(Action<Graphics> draw)
        {
            draw(_canvas);
        }

        public string InputAdd
        {
            get
            {
                string rv = textBoxAdd.Text;
                textBoxAdd.Clear();
                return rv;
            }
        }

        public string InputDelete
        {
            get
            {
                string rv = textBoxDelete.Text;
                textBoxDelete.Clear();
                return rv;
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            Setup();
        }

        // protected void Page_Load(object sender, EventArgs e)
        // {
        //     var image = new Bitmap(800, 600);
        //     try
        //     {
        //         var graph = Graphics.FromImage(image);
        //         graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
        //         for (int col = 0; col < image.Width; col += 100)
        //         {
        //             graph.DrawLine(Pens.Black, new Point(col, 0), new Point(col, image.Height));
        //         }
        //         for (int row = 0; row < image.Height; row += 30)
        //         {
        //             graph.DrawLine(Pens.Black, new Point(0, row), new Point(image.Width, row));
        //         }
        //         graph.DrawRectangle(Pens.Black, new Rectangle(0, 0, image.Width - 1, image.Height - 1));
        //
        //         Response.Clear();
        //         Response.ContentType = "image/jpeg";
        //         image.Save(Response.OutputStream, ImageFormat.Jpeg);
        //         Response.End();
        //     }
        //     finally
        //     {
        //         image.Dispose();
        //     }
        // }
    }
}