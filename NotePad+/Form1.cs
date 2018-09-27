using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotePad_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.AddExtension = true;
            


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(File.Create(saveFileDialog1.FileName));
                UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
                file.Write(tab.t.Text);
               // Tab1.SelectedTab.Text = saveFileDialog1.FileName;
                file.Dispose();

                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                //    //// Code to write the stream goes here.
                //    //using (StreamWriter file = new StreamWriter("this.saveFileDialog1.FileName"))
                //    //{

                //    //    file.Write(tab.t.Text);
                //    //    //Tab1.SelectedTab.Text = saveFileDialog1.FileName;
                //    //    // file.Dispose();

                //    //}

                    

                //    myStream.Close();
                //}
            }

            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = new UserControl1();
            this.Tab1.Controls.Add(tab);
            Tab1.SelectedTab = tab;
            
    
        }


        private TabPage tabPage3;
        private TextBox textBox3;


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tabPage3 = new System.Windows.Forms.TabPage();
                this.textBox3 = new System.Windows.Forms.TextBox();
                this.tabPage3.Controls.Add(this.textBox3);
                this.Tab1.Controls.Add(this.tabPage3);
                //  this.Tab1.SelectedIndex = 2;
                Tab1.SelectedTab = tabPage3;

                this.tabPage3.Location = new System.Drawing.Point(4, 25);
                this.tabPage3.Name = "tabPage3";
                this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
                this.tabPage3.Size = new System.Drawing.Size(1182, 458);
                this.tabPage3.TabIndex = 2;
                this.tabPage3.Text = "Tab3";
                this.tabPage3.UseVisualStyleBackColor = true;

                this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
                this.textBox3.Location = new System.Drawing.Point(3, 3);
                this.textBox3.Multiline = true;
                this.textBox3.Name = "textBox3";
                this.textBox3.Size = new System.Drawing.Size(1176, 452);
                this.textBox3.TabIndex = 2;

                using (StreamReader sr = new StreamReader(this.openFileDialog1.FileName))
                {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        textBox3.Text += (line) + "\r\n";
                    }
                }

                

            }

            
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            fontDialog1.Font = tab.t.Font;
            fontDialog1.Color = tab.t.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                tab.t.Font = fontDialog1.Font;
                tab.t.ForeColor = fontDialog1.Color;
            }

        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = false;
            // Sets the initial color select to the current text color.
            MyDialog.Color = tab.t.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                tab.t.BackColor = MyDialog.Color;
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pgSetup = new PageSetupDialog();
            pgSetup.PageSettings = new System.Drawing.Printing.PageSettings();
            pgSetup.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pgSetup.ShowNetwork = true;
            pgSetup.AllowMargins = true;
            pgSetup.AllowMargins = true;
            pgSetup.AllowPrinter = true;
            pgSetup.ShowHelp = true;


            pgSetup.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var printDoc = new PrintDialog();
            printDoc.AllowCurrentPage = true;
            printDoc.AllowPrintToFile = true;
            printDoc.AllowSelection = true;
            printDoc.AllowSomePages = true;
            

            printDoc.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (tab.t.CanUndo == true)
            {
                tab.t.Undo();
                tab.t.ClearUndo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (tab.t.SelectedText != "")
            {
                tab.t.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (tab.t.SelectionLength > 0)
            {
                tab.t.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                tab.t.Paste();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (tab.t.SelectionLength > 0)
            {
                tab.t.SelectedText = "";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (tab.t.SelectionLength == 0)
            {
                tab.t.SelectAll();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            if (tab.t.WordWrap == true)
            {
                tab.t.WordWrap = false;
                tab.t.ScrollBars = ScrollBars.Horizontal;
            }
            else
            {
                tab.t.WordWrap = true;
                tab.t.ScrollBars = ScrollBars.None;
            }
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
            DateTime thisDay = DateTime.Now;

            tab.t.AppendText(thisDay.ToString());
        }

        

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            

                //// Declare the StatusBar control
                //StatusBar simpleStatusBar = new StatusBar();

                //// Set the ShowPanels property to False.
                //simpleStatusBar.ShowPanels = false;

                //// Set the text.
                //simpleStatusBar.Text = "This is a single-panel status bar";

                //// Set the width and anchor the StatusBar
                //simpleStatusBar.Width = 200;
                //simpleStatusBar.Anchor = AnchorStyles.Top;

                //// Add the StatusBar to the form.
                //this.Controls.Add(simpleStatusBar);

                //if (simpleStatusBar.Visible)
                //{
                //    simpleStatusBar.Visible = false;
                //}
                //else
                //{
                //    simpleStatusBar.Visible = true;
                //}

            

            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(File.Create(saveFileDialog1.FileName));
                UserControl1 tab = (UserControl1)this.Tab1.SelectedTab;
                sw.Write(tab.t.Text);
                Tab1.SelectedTab.Text = saveFileDialog1.FileName;
                sw.Dispose();

            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/en-us/dotnet/index?view=netframework-4.7.2");
        }
    }
}
