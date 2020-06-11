using System;
using System.Threading;
using System.Windows.Forms;
// ReSharper disable StringLiteralTypo
// ReSharper disable LocalizableElement

namespace Modeling
{
    public partial class View : Form, IView
    {
        public SynchronizationContext Context { get; set; }
        public event EventHandler<EventArgs> Start;
        public event EventHandler<EventArgs> Stop;
        
        public void OnRequestAdded(Request request)
        {
            richTextBoxAdded.Text += $"Добавлено: {request}\n";
        }

        public void OnRequestProcessed(Request request)
        {
            richTextBoxHandled.Text += $"Обработано: {request}\n";
        }

        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            Context = SynchronizationContext.Current;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Start?.Invoke(this, EventArgs.Empty);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop?.Invoke(this, EventArgs.Empty);
        }
    }
}
