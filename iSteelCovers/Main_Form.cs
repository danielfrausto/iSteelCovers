using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iSteelCovers
{
    public partial class Main_Form : Form
    {
        public class Globals
        {
            public static DataGridView Results_DataGrid;
            public static ComboBox SearchMethod_ComboBox;
            public static PictureBox ArtPreview_PictureBox;
        }

        public Main_Form()
        {
            InitializeComponent();
            Globals.Results_DataGrid = Results_DataGrid;
            Globals.SearchMethod_ComboBox = SearchMethod_ComboBox;
            Globals.ArtPreview_PictureBox = ArtPreview_PictureBox;
            iFunctions.CheckHomes();

            SearchMethod_ComboBox.SelectedIndex = 0;
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            iFunctions.iSearch(SearchQuery_TextBox.Text);
        }

        private void Results_DataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Debug.WriteLine("Preview Needed");
            
        }

        private void Results_DataGrid_SelectionChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Well,Preview Needed");
            iFunctions.GetArtPreview();

        }

        private void SearchMethod_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SearchMethod_ComboBox.SelectedIndex)
            {
                case 1:
                    ArtPreview_PictureBox.Image =Properties.Resources.Artist;
                    break;
                default:
                    break;
            }
        }
    }
}
