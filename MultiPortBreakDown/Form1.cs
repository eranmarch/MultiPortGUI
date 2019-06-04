using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static MultiPortBreakDown.PortEntry;

namespace MultiPortBreakDown
{
    public partial class Form1 : Form
    {
        public XmlSerializer xs;
        List<PortEntry> Ports;
        bool saved = false;

        public Form1()
        {
            InitializeComponent();
            Ports = new List<PortEntry>();
            xs = new XmlSerializer(typeof(List<PortEntry>));
            ReadDataBase();
            InitFields();
        }

        private void InitFields()
        {
            PortNameText.Text = "";
            MemorySizeText.Text = "full";
            CommentText.Text = "";
            ValidCheckBox.Checked = false;
            R_WCombo.SelectedIndex = 0;
            DataSizeBox.SelectedIndex = 0;
            TypeOpts.SelectedIndex = 0;
            BankBox.SelectedIndex = 0;
            numericUpDown1.Value = 99;
            numericUpDown2.Value = 1;
            RelativeAddressCheckBox.Checked = true;
            EmergencyCheckBox.Checked = false;
            DebugCheckBox.Checked = false;
        }

        private bool CheckDup(PortEntry new_entry)
        {
            string name_new = new_entry.GetName();
            foreach (PortEntry item in Ports)
            {
                if (item.GetIsComment() || item == new_entry)
                    continue;
                if (item.GetName().Equals(name_new))
                {
                    new_entry.SetReason("Name " + name_new + " is already in the list");
                    new_entry.SetValid(false);
                    return false;
                }
            }
            return true;
        }

        /* Validate Opened file */
        private void OpenValidation()
        {
            //List<int> priorities = new List<int>();
            foreach (PortEntry new_entry in Ports)
            {
                //priorities.Add(new_entry.GetPriority());
                if (CheckDup(new_entry))
                    if (FileValidator.ValidEntry(new_entry))
                    {
                        new_entry.SetValid(true);
                        new_entry.SetReason("");
                    }
            }
            /*priorities.Sort();
            bool test = false;
            Console.WriteLine("Length: " + Ports.ToString());
            for (int i = 0; i < priorities.Count - 1; i++)
            {
                MessageBox.Show(i.ToString());
                if (i < priorities.Count - 2 && priorities[i] + 1 != priorities[i + 1])
                {
                    PriorityError.Text = "Note That Priority " + (priorities[i] + 1).ToString() + " is not in the list";
                    test = true;
                    break;
                }
            }
            if (!test)
                PriorityError.Text = "All priorities are good!";*/
            ColorInValid();
        }

        /* Check the a port can be added to the chart */
        private bool InputValidation(PortEntry entry)
        {
            if (entry.GetName()[0] >= '0' && entry.GetName()[0] <= '9')
            {
                MessageBox.Show("Port name can't begin with a digit");
                return false;
            }
            int index = -1;
            for (int i = 0; i < Ports.Count; i++)
                if (Ports[i].GetName().Equals(entry.GetName()))
                    index = i;
            if (index != -1)
            {
                MessageBox.Show("Port " + entry.GetName() + " is already in the list");
                return false;
            }

            // check sequintial here
            return true;
        }

        private void UpdateTable(List<PortEntry> lst)
        {
            var bindingList = new BindingList<PortEntry>(lst);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            dataGridView1.Columns["IsComment"].Visible = false;
            dataGridView1.Columns["IsValid"].Visible = false;
            dataGridView1.Columns["Reason"].Visible = false;
            dataGridView1.Columns["Index"].Visible = false;
            //ColorInValid();
        }

        /* Insert port to the table */
        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (PortNameText.Text.Equals(""))
            {
                MessageBox.Show("Invalid port name: Empty name");
                InitFields();
                return;
            }

            char Anable_emerge = 'Y';
            if (!EmergencyCheckBox.Checked)
                Anable_emerge = 'N';
            /*Console.WriteLine(PortNameText.Text);
            Console.WriteLine(ValidCheckBox.Checked.ToString());
            Console.WriteLine(TypeOpts.SelectedItem.ToString());
            Console.WriteLine(R_WCombo.SelectedItem.ToString());
            Console.WriteLine(DataSizeBox.SelectedItem.ToString());
            Console.WriteLine(BankBox.SelectedItem.ToString());
            Console.WriteLine(MemorySizeText.Text);
            Console.WriteLine(numericUpDown2.Value.ToString());
            Console.WriteLine(RelativeAddressCheckBox.Checked.ToString());
            Console.WriteLine(numericUpDown1.Value.ToString());
            Console.WriteLine(Anable_emerge);
            Console.WriteLine(DebugCheckBox.Checked.ToString());
            Console.WriteLine(CommentText.Text);*/
            PortEntry entry = new PortEntry(PortNameText.Text, ValidCheckBox.Checked.ToString(), TypeOpts.SelectedItem.ToString(), R_WCombo.SelectedItem.ToString()[0], DataSizeBox.SelectedItem.ToString(),
            BankBox.SelectedItem.ToString()[0], MemorySizeText.Text, numericUpDown2.Value.ToString(), RelativeAddressCheckBox.Checked.ToString(), numericUpDown1.Value.ToString(), Anable_emerge, DebugCheckBox.Checked.ToString(), CommentText.Text);
            if (!InputValidation(entry))
                return;
            AddEntryToTable(entry);
            searchBox.Text = "";
            UpdateTable(Ports);
            ErrorMessage.Text = "[#] Port named " + PortNameText.Text + " was added";
            InitFields();
            saved = false;
        }

        /* Open a file */
        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileValidator fv = new FileValidator(openFileDialog1.FileName);
                if (fv.IsFileValid())
                {
                    PathToFile.Text = openFileDialog1.FileName;
                    File.WriteAllText(@"file_path.txt", openFileDialog1.FileName);
                    Console.WriteLine("Adding entries to table...");
                    AddManyRegisters(fv.GetPortList());
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            PortEntry pe = null;
            DataGridViewRow item_f = null;
            int i = -1;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                i = (int)item.Cells["Index"].Value;
                pe = Ports[i];
                item_f = item;
                break;
            }
            if (pe == null)
            {
                MessageBox.Show("Please select a port in order to edit");
                return;
            }
            string name = PortNameText.Text;
            if (!pe.GetName().Equals(name))
            {
                MessageBox.Show("You can't edit a port's name");
                PortNameText.Text = pe.GetName();
                return;
            }
            string memory_size = MemorySizeText.Text;
            bool valid = ValidCheckBox.Checked;
            char r_w = R_WCombo.SelectedItem.ToString()[0];
            bool relative_address = RelativeAddressCheckBox.Checked;
            char emergency_enable = 'N';
            if (EmergencyCheckBox.Checked)
                emergency_enable = 'Y';
            bool debug_enable = DebugCheckBox.Checked;
            int priority = (int)numericUpDown1.Value;
            int memory_section = (int)numericUpDown2.Value;
            int data_size = int.Parse(DataSizeBox.SelectedItem.ToString());
            char bank = BankBox.SelectedItem.ToString()[0];
            string comment = CommentText.Text;
            p_type type = (p_type)Enum.Parse(typeof(p_type), TypeOpts.Text, true);

            if (i == -1)
            {
                MessageBox.Show("No such port " + name);
                InitFields();
                return;
            }
            if (pe.GetIsComment())
            {
                MessageBox.Show("This port is a comment and can't be edited");
                //InitFields();
                return;
            }
            pe.EditPort(valid, type, r_w, data_size, bank, memory_size, memory_section, relative_address, priority, emergency_enable, debug_enable, comment);
            OpenValidation();
            UpdateDataBase();
            EditCell(item_f, pe.GetTableEntry());
            //MessageBox.Show(pe.ToString());
            saved = false;
        }

        private void EditCell(DataGridViewRow cell, object[] ent)
        {
            for (int i = 0; i < ent.Length; i++)
                cell.Cells[i].Value = ent[i];
        }

        private void UpdateDataBase()
        {
            FileStream fs = new FileStream(@"ports.txt", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, Ports);
            fs.Close();
            File.WriteAllText(@"file_path.txt", PathToFile.Text);
        }

        private void ReadDataBase()
        {
            try
            {
                FileStream fs = new FileStream(@"ports.txt", FileMode.Open, FileAccess.Read);
                Ports = (List<PortEntry>)xs.Deserialize(fs);
                fs.Close();
                //dataGridView1.DataSource = Ports;
                UpdateTable(Ports);
                ColorInValid();
            }
            catch (Exception e)
            {
                Console.WriteLine("FAILED\nException caught: " + e.Message + "\nReseting list...");
                Ports = new List<PortEntry>();
            }
            try
            {
                Console.Write("Restoring opened file from 'file_path.txt': ");
                PathToFile.Text = File.ReadAllText(@"file_path.txt");
                Console.WriteLine("SUCCESS");
            }
            catch (Exception e)
            {
                Console.WriteLine("FAILED\nException caught: " + e.Message + "\nReseting path...");
                PathToFile.Text = "";
            }
        }

        private void ColorInValid()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int index = (int)row.Cells["Index"].Value;
                //MessageBox.Show(index + ", " + Ports.Count);
                PortEntry port = Ports[index];
                bool isComment = port.GetIsComment(), isValid = port.GetValid();
                foreach (DataGridViewCell cell in row.Cells)
                    if (isComment)
                        cell.Style.BackColor = Color.LimeGreen;
                    else if (!isValid)
                        cell.Style.BackColor = Color.Red;
                    else
                        cell.Style.BackColor = Color.White;
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTable(Ports.Where(v => v.GetName().Contains(searchBox.Text)).ToList());
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            List<int> indices = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                indices.Add((int)row.Cells["Index"].Value);
            }
            foreach (int index in indices.OrderByDescending(v => v))
            {
                for (int i = index + 1; i < Ports.Count; i++)
                    Ports[i].Index--;
                Ports.RemoveAt(index);
            }
            SearchBox_TextChanged(sender, e);
            OpenValidation();
            UpdateDataBase();
            UpdateTable(Ports);
            saved = false;
        }

        private void AddEntryToTable(PortEntry entry, bool open = false)
        {
            entry.SetIndex(Ports.Count);
            Ports.Add(entry);
            if (!open)
                UpdateDataBase();
        }

        private void AddManyRegisters(List<PortEntry> entries)
        {
            Console.Write("Adding prots: ");
            foreach (PortEntry port in entries)
            {
                AddEntryToTable(port, true);
            }
            Console.Write("DONE\nValidating logic with table: ");
            OpenValidation();
            UpdateDataBase();
            Console.WriteLine("DONE");
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "VHD files (*.vhd)|*.vhd",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathToFile.Text = saveFileDialog1.FileName;
                File.WriteAllText(@"file_path.txt", saveFileDialog1.FileName);
                SaveButton_Click(sender, e);
            }
        }

        private String GetSpaces(int x)
        {
            return String.Concat(Enumerable.Repeat(" ", x));
        }

        private bool IsNum(String s)
        {
            return double.TryParse(s, out double num);
        }

        // FIX AS FAST AS POSSIBLE
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (PathToFile.Text.Equals(""))
            {
                SaveAsButton_Click(sender, e);
                return;
            }
            StreamReader file;
            try
            {
                file = new StreamReader("mycorrect.vhd");
                string line;
                string res = "";
                string title = Path.GetFileNameWithoutExtension(PathToFile.Text);
                string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                string introDec = "Original path: " + PathToFile.Text + "</br>The following is a documentation for " + title + ". The table " +
                    "contains the registers created using the GUI.";
                //MessageBox.Show(Path.GetFileNameWithoutExtension(PathToFile.Text));
                string doc = "<html><head><title>" + title + " Documentation" + "</title>";
                doc += "<style>table, th, td { border: 1px solid black; } th, td {padding: 5px; text-align: center;}" + "</style></head><body>";
                doc += "<h1><font face = 'arial'><u>Documentation For " + title + "</h1></u>";
                doc += date;
                doc += "<h2>" + date + "<br/>" + introDec + "</h2>";
                doc += "<table style='width: 100 %'>";
                doc += "<tr><th>Name</th><th>Valid</th><th>Type</th><th>Write/Read</th><th>Data Size</th><th>Bank</th><th>Memory Size</th><th>Memory Section</th><th>Relative Address</th><th>Priority</th><th>Emergency></th><th>Comment</th></tr>";
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length == 0)
                    {
                        res += "\n";
                        continue;
                    }
                    //System.Console.WriteLine(line);
                    if ('#' == line[0])
                        continue;
                    if (line.Equals("0o0o0o0o0o0o0o0o0o0o0o0o0o00o0o0o0o0o0o00o0o0o0o0o0"))
                        break;
                    res += line + "\n";
                }
                string prop = "", names = "";
                foreach (PortEntry l in Ports)
                {
                    names += l.ToName();
                    prop += l.ToEntry(l.Index == Ports.Count - 1);
                    doc += l.ToXMLstring();

                }

                doc += "</table></font></body></html>";
                res += names;
                while ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);
                    if (line.Length == 0)
                    {
                        res += "\n";
                        continue;
                    }
                    if ('#' == line[0])
                        continue;
                    if (line.Equals("0o0o0o0o0o0o0o0o0o0o0o0o0o00o0o0o0o0o0o00o0o0o0o0o0"))
                        break;
                    res += line + '\n';
                }
                res += prop;
                while ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);
                    if (line.Length == 0)
                    {
                        res += "\n";
                        continue;
                    }
                    if ('#' == line[0])
                        continue;
                    res += line + '\n';
                }
                file.Close();
                try
                {
                    File.WriteAllText(PathToFile.Text, res);
                    //MessageBox.Show(Path.GetDirectoryName(PathToFile.Text) + "\\" + title + "_doc.txt");
                    File.WriteAllText(Path.GetDirectoryName(PathToFile.Text) + "\\" + title + "_doc.html", doc);
                    saved = true;
                    ErrorMessage.Text = "[#] File Saved!";

                }
                catch
                {
                    MessageBox.Show("Invalid Path to File");
                }
            }
            catch (IOException t)
            {
                MessageBox.Show("ArgumentException " + t.ToString());
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Ports.Clear();
            dataGridView1.DataSource = Ports;
            UpdateDataBase();
            InitFields();
        }

        private void PortNameText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                InsertButton_Click(sender, e);
        }

        private void CommentText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                InsertButton_Click(sender, e);
        }

        private void MemorySizeText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                InsertButton_Click(sender, e);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (PathToFile.Text.Equals(""))
                return;
            if (saved)
                PathToFile.Text = "";
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the file without saving?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //SaveButton_Click(sender, e);
                    PathToFile.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            PortEntry pe = null;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                pe = Ports[(int)item.Cells["Index"].Value];
                //MessageBox.Show(item.Cells["Index"].Value.ToString());
                break;
            }
            if (pe != null)
            {
                PortNameText.Text = pe.GetName();
                CommentText.Text = pe.GetComment();
                MemorySizeText.Text = pe.GetMemorySize();
                ValidCheckBox.Checked = pe.GetValidField();
                RelativeAddressCheckBox.Checked = pe.GetRelative_address();
                EmergencyCheckBox.Checked = pe.GetAnable_emerge() == 'Y';
                DebugCheckBox.Checked = pe.GetRead_bk_address();

                int index = R_WCombo.FindStringExact(pe.GetR_W().ToString());
                if (index == -1)
                    index = 0;
                R_WCombo.SelectedIndex = index;
                index = DataSizeBox.FindStringExact(pe.GetData_size().ToString());
                if (index == -1)
                    index = 0;
                DataSizeBox.SelectedIndex = index;
                index = TypeOpts.FindStringExact(pe.GetPortType().ToString());
                if (index == -1)
                    index = 0;
                TypeOpts.SelectedIndex = index;

                if (pe.GetIsComment())
                    ErrorMessage.Text = "> ";
                else if (!pe.GetValid())
                    ErrorMessage.Text = "[@] " + pe.GetReason();
                else
                    ErrorMessage.Text = "> ";
            }
        }

        private void DataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Delete_Click(sender, e);
        }

        /*private void frm_sizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Size = new Size(this.Size.Width, this.Size.Height - this.panel4.Size.Height - 45);
        }*/

        private void CommentButton_Click(object sender, EventArgs e)
        {
            PortEntry entry;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                entry = Ports[(int)item.Cells["Index"].Value];
                entry.SetIsComment(true);
            }
            searchBox.Text = "";
            OpenValidation();
            UpdateDataBase();
        }

        private void UnCommentButton_Click(object sender, EventArgs e)
        {
            PortEntry entry;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                entry = Ports[(int)item.Cells["Index"].Value];
                entry.SetIsComment(false);
            }
            searchBox.Text = "";
            OpenValidation();
            UpdateDataBase();
        }
    }
}
