using System.Globalization;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        bool[] checkinput = new bool[4];
        bool deletingFromList = false;

        private void Application_Idle(object sender, EventArgs e)
        {
            checkinput[3] = (radioButton1.Checked || radioButton2.Checked) ? true : false;
            if (checkinput.All(x => x))
                button1.Enabled = true;
            if (listBox1.SelectedItem != null) button3.Enabled = true;
            button5.Enabled = button6.Enabled = listBox1.Items.Count > 1;
            button4.Enabled = button2.Enabled = listBox1.Items.Count > 0;
        }
        void ret_old()
        {
            textBox1.Text = textBox2.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            comboBox1.Items.Clear();
            button1.Enabled = false;
            load_file("lok.txt");
        }
        public Form1()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }
        private void load_file(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                comboBox1.Items.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom čitanja podataka: " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load_file("lok.txt");
        }
        void pisi(string filepath)
        {
            TextWriter txt = new StreamWriter(filepath);
            foreach (var item in listBox1.Items)
            {
                txt.WriteLine(item.ToString());
            }

            txt.Close();
            MessageBox.Show("Podaci su sacuvani!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.Title = "Izaberite fajl za snimanje";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pisi(saveFileDialog.FileName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string whichvrsta;
            if (radioButton1.Checked) whichvrsta = "Zivotinja";
            else whichvrsta = "Biljka";

            Vrsta novi = new Vrsta(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), whichvrsta);
            listBox1.Items.Add(novi.ToString());
            //MessageBox.Show(novi.ToString());
            ret_old();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkinput[0] = (string.IsNullOrWhiteSpace(textBox1.Text)) ? false : true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            checkinput[1] = (string.IsNullOrWhiteSpace(textBox1.Text)) ? false : true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkinput[2] = (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString())) ? false : true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        void kopiraj(List<string> sortt) {
            foreach (var item in listBox1.Items)
            {
                sortt.Add(item.ToString());
            }
        }
        void ubaciSortiranuListu(List<string> sorted)
        {
            listBox1.Items.Clear();
            foreach (var item in sorted)
            {
                listBox1.Items.Add(item);

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            List<string> sorted = new List<string>();
            kopiraj(sorted);
            sorted.Sort((x, y) => string.Compare(y, x));
            ubaciSortiranuListu(sorted);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List <string> sorted = new List<string>();
            kopiraj(sorted);
            sorted.Sort();
            ubaciSortiranuListu(sorted);
        }
    }
}