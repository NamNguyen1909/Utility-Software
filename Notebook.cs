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

namespace Utility_Apps
{
    public partial class Notebook : Form
    {
        public Notebook()
        {
            InitializeComponent();
            this.txtMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMain_KeyDown);


        }
        string fileName = "Untitled";


        private void Notebook_Load(object sender, EventArgs e)
        {
            this.Text="Notebook - "+ fileName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = txtMain.SelectionFont;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txtMain.SelectionFont = fontDialog.Font;
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd= new SaveFileDialog();
            sfd.Filter = "Text File(*.txt)|*.txt"
                    + "|Microsoft Word Document(*.docx)|*.docx"
                    + "|Microsoft Word 97-2003 Document(*.doc)|*.doc"
                    + "|RTF File(*.rtf)|*.rtf"
                    + "|WPS Writer Document(*.wps)|*.wps";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                File.WriteAllText(sfd.FileName, txtMain.Text);
                this.Text = "Notebook - " + sfd.FileName; 
            }

        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fileName == "Untitled")
            {
                saveAsToolStripMenuItem1_Click(sender, e); // Gọi lại saveAsToolStripMenuItem1_Click và truyền sender và e
            }
            else
            {
                File.WriteAllText(fileName, txtMain.Text);
                this.Text = "Notebook - " + fileName;
            }
        }

        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            if (txtMain.Modified)
            {
                this.Text = "Notebook - " + fileName+" *";
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (txtMain.Modified)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu những thay đổi đã thực hiện với file?",
                    "Lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem1_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Trở về mà không làm gì cả
                }
            }


            OpenFileDialog ofd= new OpenFileDialog();
            ofd.Filter = "Text File(*.txt)|*.txt"
                   + "|Microsoft Word Document(*.docx)|*.docx"
                   + "|Microsoft Word 97-2003 Document(*.doc)|*.doc"
                   + "|RTF File(*.rtf)|*.rtf"
                   + "|WPS Writer Document(*.wps)|*.wps";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName= ofd.FileName;
                txtMain.Text = File.ReadAllText(ofd.FileName);
                this.Text = "Notebook - " + ofd.FileName;
            }

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Notebook notebook = new Notebook();
            notebook.Show();
            notebook = null;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtMain.SelectedText != "")
            {
                Clipboard.SetText(txtMain.SelectedText);
                txtMain.SelectedText = "";
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtMain.SelectedText != "")
            {
                Clipboard.SetText(txtMain.SelectedText);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectionStart = txtMain.SelectionStart; // Lưu vị trí con trỏ trước khi dán

            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                if (txtMain.SelectionLength > 0)
                {
                    txtMain.SelectedText = Clipboard.GetData(DataFormats.Text).ToString();
                }
                else
                {
                    txtMain.Text = txtMain.Text.Insert(txtMain.SelectionStart, Clipboard.GetData(DataFormats.Text).ToString());
                }
            }

            txtMain.SelectionStart = selectionStart + Clipboard.GetText().Length; // Khôi phục vị trí con trỏ
            txtMain.SelectionLength = 0;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectAll();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectedText = "";
        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Redo();
        }

        private void ToggleFontStyle(FontStyle fontStyle)
        {
            Font currentFont = txtMain.SelectionFont;
            FontStyle newFontStyle;

            if (currentFont == null) return;

            if (currentFont.Style.HasFlag(fontStyle))
            {
                newFontStyle = currentFont.Style & ~fontStyle;
            }
            else
            {
                newFontStyle = currentFont.Style | fontStyle;
            }

            txtMain.SelectionFont = new Font(currentFont, newFontStyle);
        }

        private void boldToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtMain.SelectionColor = colorDialog.Color;
            }
        }

        private void txtMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Ngăn chặn việc thêm ký tự tab vào vị trí con trỏ mặc định

                int selectionStart = txtMain.SelectionStart; // Lưu vị trí con trỏ trước khi thêm ký tự tab

                txtMain.SelectionIndent += 30; // Thêm khoảng trắng khi nhấn Tab

                // Đặt lại vị trí con trỏ sau khi thêm khoảng trắng
                txtMain.SelectionStart = selectionStart + 1;
                txtMain.SelectionLength = 0;
            }
        }

        private void Notebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtMain.Modified)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu những thay đổi đã thực hiện với file?",
                    "Lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem1_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Trở về mà không làm gì cả
                }
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
}
