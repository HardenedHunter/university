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

        public event Action<int> Start;

        public View()
        {
            InitializeComponent();
        }

        public void OnSimulationFinished()
        {
            buttonStart.Enabled = true;
        }

        public void OnRequestAdded(Request request)
        {
            richTextBoxCommittee.Text = $"Принято: {request}\n" + richTextBoxCommittee.Text;
        }

        public void OnRequestProcessed(Request request)
        {
            richTextBoxDispatcher.Text = $"Обработано: {request}\n" + richTextBoxDispatcher.Text;
        }

        public void OnRequestPostponed(Request request)
        {
            richTextBoxDispatcher.Text = $"Отложено:     {request}\n" + richTextBoxDispatcher.Text;
        }

        public void OnRequestFinished(Request request, Employee employee)
        {
            richTextBoxDepartments.Text =
                $"{employee} выполнил(а) заявку №{request.RequestId}.\n" + richTextBoxDepartments.Text;
        }

        private void View_Load(object sender, EventArgs e)
        {
            Context = SynchronizationContext.Current;
        }

        private void ClearTextBoxes()
        {
            richTextBoxCommittee.Clear();
            richTextBoxDepartments.Clear();
            richTextBoxDispatcher.Clear();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var view = new ViewTestSize(size =>
            {
                ClearTextBoxes();
                buttonStart.Enabled = false;
                Start?.Invoke(size);
            });
            view.Show();
        }
    }
}