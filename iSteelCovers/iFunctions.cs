using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iSteelCovers
{
    class iFunctions
    {
        static DataGridView Results_DataGrid = Main_Form.Globals.Results_DataGrid;
        static ComboBox SearchMethod_ComboBox = Main_Form.Globals.SearchMethod_ComboBox;
        static PictureBox ArtPreview_PictureBox = Main_Form.Globals.ArtPreview_PictureBox;

        static string[] ArtistSearch_ColumnNames = { "Artist", "Itunes Id", "AMG Id", "Genre" };
        static string[] AlbumSearch_ColumnNames = { "Album", "Artist", "Year", "Tracks", "Genre", "Sort" };

        static public string qLink = "https://itunes.apple.com/search?term={{Query}}";
        static public string entity_Artist = "&entity=allArtist";
        static public string entity_Album = "&entity=album";

        static public string CoversHomeDefault = Properties.Settings.Default.CoversHomeDefault;
        static public string CoversHomeUser = Properties.Settings.Default.CoversHomeUser;
        static public string CoversHome;

        static public string ResultsHomeDefault = Properties.Settings.Default.ResultsHomeDefault;
        static public string ResultsHomeUser = Properties.Settings.Default.ResultsHomeUser;
        static public string ResultsHome;

        public static string MakeLink(string Query)
        {
            if (System.IO.Path.GetExtension(Query) != "")
            {
                Query = Query.Replace(System.IO.Path.GetExtension(Query), "").ToLower();
            }
            Query = Regex.Replace(Query, "[^a-zA-Z0-9 ]+", "", RegexOptions.Compiled);
            Query = Regex.Replace(Query, @"\s+", "+");
            Query = qLink.Replace("{{Query}}", Query).ToLower();
            return Query;
        }

        public static void MakeResultsArtistSearch(string Query)
        {
            Results_DataGrid.Columns.Clear();
            Results_DataGrid.ReadOnly = true;

            foreach (string ColumnName in ArtistSearch_ColumnNames)
            {
                AddColumn(ColumnName);
            }
            string iUrl = MakeLink(Query) + entity_Artist;
            Debug.WriteLine(iUrl);
            var SearchResults = iDownloader.JsonData(iUrl);
            if ((int)SearchResults["resultCount"] > 0)
            {
                foreach (JObject Result in SearchResults["results"])
                {
                    AddArtistSerchResult(Result);
                }
            }
        }

        public static void MakeResultsAlbumSearch(string Query)
        {
            Results_DataGrid.Columns.Clear();
            Results_DataGrid.ReadOnly = true;

            foreach (string ColumnName in AlbumSearch_ColumnNames)
            {
                AddColumn(ColumnName);
            }
            string iUrl = MakeLink(Query) + entity_Album;
            Debug.WriteLine(iUrl);
            var SearchResults = iDownloader.JsonData(iUrl);
            if ((int)SearchResults["resultCount"] > 0)
            {
                foreach (JObject Result in SearchResults["results"])
                {
                    AddAlbumSerchResult(Result);
                }
            }
        }

        public static void AddArtistSerchResult(JObject Result)
        {
            int rowIndex = Results_DataGrid.Rows.Add();
            var row = Results_DataGrid.Rows[rowIndex];
            row.Cells["Artist"].Value = Result["artistName"];
            row.Cells["Itunes Id"].Value = Result["artistId"];
            row.Cells["AMG Id"].Value = Result["amgArtistId"];
            row.Cells["Genre"].Value = Result["primaryGenreName"];
            row.Tag = Result;
        }

        public static void AddAlbumSerchResult(JObject Result)
        {
            Result["coverPreview"] = Result["artworkUrl100"].ToString().Replace("100x100bb", "250x250");
            Result["coverLink"] = Result["artworkUrl100"].ToString().Replace("100x100bb", "3000x3000");
            int rowIndex = Results_DataGrid.Rows.Add();
            var row = Results_DataGrid.Rows[rowIndex];
            row.Cells["Album"].Value = Result["collectionName"];
            row.Cells["Artist"].Value = Result["artistName"];
            row.Cells["Year"].Value = DateTime.Parse((string)Result["releaseDate"]).Year.ToString();
            row.Cells["Tracks"].Value = Result["trackCount"];
            row.Cells["Genre"].Value = Result["primaryGenreName"];
            row.Cells["Sort"].Value = Result["artistName"] + " " + DateTime.Parse((string)Result["releaseDate"]).Year.ToString();
            //row.Tag = Result["artworkUrl100"].ToString().Replace("100x100bb","{{ImageSize}}");
            row.Tag = Result;


            // Results_DataGrid.Columns["Album"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SortByArtist_AlbumYear();
        }

        public static void SortByArtist_AlbumYear()
        {
            Results_DataGrid.Sort(Results_DataGrid.Columns["Sort"], ListSortDirection.Ascending);
        }

        public static void AddColumn(string ColumnName)
        {
            DataGridViewColumn col = new DataGridViewColumn();
            //if (ColumnName == "Artist" || ColumnName=="Album")
            //{
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}
            //else
            //{
            //  col.Width = 100;
            //}

            col.HeaderText = ColumnName;
            col.Name = ColumnName;
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.CellTemplate = new DataGridViewTextBoxCell();

            if (ColumnName == "Sort")
            {
                col.Visible = false;
            }
            //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Results_DataGrid.Columns.Add(col);
        }

        public static void iSearch(string Query)
        {
            int Mode = SearchMethod_ComboBox.SelectedIndex;
            switch (Mode)
            {
                case 0:
                    break;
                case 1:
                    iFunctions.MakeResultsArtistSearch(Query);
                    break;
                case 2:
                    iFunctions.MakeResultsAlbumSearch(Query);
                    break;
                default:
                    break;

            }
        }

        public static void CheckHomes()
        {
            if (CoversHomeUser != "")
            {
                CoversHome = CoversHomeUser;
            }
            else
            {
                CoversHome = CoversHomeDefault;
            }

            if (ResultsHomeUser != "")
            {
                ResultsHome = ResultsHomeUser;
            }
            else
            {
                ResultsHome = ResultsHomeDefault;
            }
            Directory.CreateDirectory(CoversHome);
            Directory.CreateDirectory(ResultsHome);
        }

        public static void GetArtPreview()
        {

            if (Results_DataGrid.Rows[Results_DataGrid.CurrentCell.RowIndex].Tag != null)
            {
                //string ArtPreviewLink = Results_DataGrid.Rows[Results_DataGrid.CurrentCell.RowIndex].Tag.ToString().Replace("{{ImageSize}}", "250x250");
                //Debug.WriteLine(ArtPreviewLink);
                 string ArtPreviewLink = "";
                JObject Result = (JObject)Results_DataGrid.Rows[Results_DataGrid.CurrentCell.RowIndex].Tag;
                if (Result["wrapperType"].ToString() == "collection")
                {
                    ArtPreviewLink = Result["coverPreview"].ToString();
                    ArtPreview_PictureBox.Load(ArtPreviewLink);
                }

                if (Result["wrapperType"].ToString() == "artist")
                {
                     ArtPreviewLink = Result["artistLinkUrl"].ToString();
                    //ArtPreview_PictireBox.Load(ArtPreviewLink);
                    ArtPreviewLink = iDownloader.GetArtistPreview(ArtPreviewLink);
                    if (ArtPreviewLink != "")
                    {
                        ArtPreview_PictureBox.Load(ArtPreviewLink);
                    }
                    else
                    {
                        ArtPreview_PictureBox.Image = Properties.Resources.Artist;
                    }
                }
                Debug.WriteLine(ArtPreviewLink);
            }
        }
    }
}
