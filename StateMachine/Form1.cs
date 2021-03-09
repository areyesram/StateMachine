using System;
using System.Windows.Forms;

namespace StateMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DFA _dfa = new DFA();

        private void Form1_Load(object sender, EventArgs e)
        {
            var actions = Enum.GetNames(typeof(DFA.Action));
            var h = pnlActions.Height / actions.Length;
            foreach (var action in actions)
            {
                var button = new Button { Text = action, Dock = DockStyle.Bottom, Height = h };
                button.Click += DoAction;
                pnlActions.Controls.Add(button);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dfa = new DFA();
            ShowCurrentState();
        }

        private void DoAction(object o, EventArgs a)
        {
            var action = (DFA.Action)Enum.Parse(typeof(DFA.Action), ((Button)o).Text);
            if (_dfa.GoNext(action))
                ShowCurrentState();
            else
                MessageBox.Show("Acción no válida.");
        }

        private void ShowCurrentState()
        {
            lblCurrentState.Text = _dfa.CurrentState.ToString();
        }
    }
}
