using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Collections;
using System.Drawing.Drawing2D;
using BOSERP.Utilities.Paint;
using Localization;
using System.Drawing.Imaging;
using DevExpress.XtraBars;

namespace BOSERP.UI.Paint
{
    public partial class guiPaint : BOSERPScreen
    {
        #region MainMenu

        private MainMenu MenuPaint = new MainMenu();

        #region MenuFile
        // MenuFile and list menus in it
        private MenuItem MenuFile = new MenuItem();
        private MenuItem MenuNew = new MenuItem();
        private MenuItem MenuOpen = new MenuItem();
        private MenuItem MenuSave = new MenuItem();
        private MenuItem MenuSaveAs = new MenuItem();
        private MenuItem MenuLine1 = new MenuItem();
        private MenuItem MenuExit = new MenuItem();
        #endregion

        #region MenuEdit
        // MenuEdit and list menus in it
        private MenuItem MenuEdit = new MenuItem();
        private MenuItem MenuUndo = new MenuItem();
        private MenuItem MenuRedo = new MenuItem();
        private MenuItem MenuLine2 = new MenuItem();
        private MenuItem MenuCut = new MenuItem();
        private MenuItem MenuCopy = new MenuItem();
        private MenuItem MenuPaste = new MenuItem();
        private MenuItem MenuDeleteSelection = new MenuItem();
        private MenuItem MenuSelectAll = new MenuItem();
        #endregion

        #region MenuView
        // MenuView and list menus in it
        private MenuItem MenuView = new MenuItem();
        private MenuItem MenuToolbar = new MenuItem();
        private MenuItem MenuViewStatus = new MenuItem();
        private MenuItem MenuLine3 = new MenuItem();
        private MenuItem MenuFullScreen = new MenuItem();
        private MenuItem MenuZoom = new MenuItem();
        #endregion

        #region MenuImage
        // MenuImage and list menus in it
        private MenuItem MenuImage = new MenuItem();
        private MenuItem MenuRotate = new MenuItem();
        private MenuItem MenuResize = new MenuItem();
        private MenuItem MenuInverted = new MenuItem();
        private MenuItem MenuRotateRight90Deg = new MenuItem();
        private MenuItem MenuRotateLeft90Deg = new MenuItem();
        private MenuItem MenuRotate180Deg = new MenuItem();
        private MenuItem MenuRotateFlipH = new MenuItem();
        private MenuItem MenuRotateFlipV = new MenuItem();
        #endregion

        #region Menu invisible
        private MenuItem MenuSetAsWallpaperTitled = new MenuItem();
        private MenuItem MenuSetAsWallpaperCenterd = new MenuItem();
        private MenuItem MenuSetForBeijing = new MenuItem();
        private MenuItem MenuMostRecentlyUsedFiles = new MenuItem();
        private MenuItem MenuReadRecent1 = new MenuItem();
        private MenuItem MenuReadRecent2 = new MenuItem();
        private MenuItem MenuReadRecent3 = new MenuItem();
        private MenuItem MenuReadRecent4 = new MenuItem();
        #endregion

        // Menu update picture in richtextbox
        private MenuItem MenuUpdateImage = new MenuItem();

        #endregion

        #region Variable

        /// <summary>
        /// Image status bar
        /// </summary>
        private StatusBar StatusBar;
        private List<String> FileList = new List<String>();
        private Colors PaintColor = new Colors();
        /// <summary>
        /// Current shape type
        /// </summary>
        private DrawShape.ShapeType CurrentShapeType = DrawShape.ShapeType.Pencil;
        private SolidBrush TextColor = new SolidBrush(Color.Black);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the mouse location status
        /// </summary>
        public static StatusBarPanel LocationStatus { get; set; }
        /// <summary>
        /// Gets or sets size of canvas status
        /// </summary>
        public static StatusBarPanel CanvasSizeStatus { get; set; }
        public SaveDialog SaveDialog { get; set; }
        /// <summary>
        /// Allows you to set the current image as wallpaper
        /// </summary>
        public bool EnableSetWallpaper { get; set; }
        /// <summary>
        /// Gets or sets Current file path of image
        /// </summary>
        public string CurrentFilePath { get; set; }
        /// <summary>
        /// Original image before zooming
        /// </summary>
        public static Image OriginalImage { get; set; }

        #endregion

        #region Constant

        private const string ImageNameBehind = " - Paint";
        private const string FilePathConfigName = "\\config.ini";
        private const string MenuLine = "-";

        #endregion

        public guiPaint()
        {
            InitializeComponent();
            // set variables canvas1 in PaintForm
            canvas1.PaintForm = this;

            LocationStatus = new StatusBarPanel();
            CanvasSizeStatus = new StatusBarPanel();
            CurrentFilePath = string.Empty;
            SaveDialog = new SaveDialog();

            StatusBar = new StatusBar();
            StatusBar.ShowPanels = true;

            LocationStatus.Width = 119;
            CanvasSizeStatus.Width = 119;
            StatusBar.Panels.AddRange(new StatusBarPanel[] { LocationStatus, CanvasSizeStatus });

            EnableSetWallpaper = false;

            Controls.Add(StatusBar);

            MenuViewStatus.Checked = true;
            MenuToolbar.Checked = true;
            SaveDialog.Owner = this;

            #region MainMenu

            #region MenuFile

            // MenuFile and list menus in it
            MenuFile.Text = CommonLocalizedResources.MenuFile;
            MenuNew.Text = CommonLocalizedResources.MenuNew;
            MenuNew.Shortcut = Shortcut.CtrlN;
            MenuOpen.Text = CommonLocalizedResources.MenuOpen;
            MenuOpen.Shortcut = Shortcut.CtrlO;
            MenuSave.Text = CommonLocalizedResources.MenuSave;
            MenuSave.Shortcut = Shortcut.CtrlS;
            MenuSaveAs.Text = CommonLocalizedResources.MenuSaveAs;
            MenuLine1.Text = MenuLine;
            MenuExit.Text = CommonLocalizedResources.MenuExit;
            MenuExit.Shortcut = Shortcut.AltF4;

            #endregion

            #region MenuEdit

            // MenuEdit and list menus in it
            MenuEdit.Text = CommonLocalizedResources.MenuEdit;
            MenuUndo.Text = CommonLocalizedResources.MenuUndo;
            MenuUndo.Shortcut = Shortcut.CtrlZ;
            MenuRedo.Text = CommonLocalizedResources.MenuRedo;
            MenuRedo.Shortcut = Shortcut.CtrlY;
            MenuLine2.Text = MenuLine;
            MenuCut.Text = CommonLocalizedResources.MenuCut;
            MenuCut.Shortcut = Shortcut.CtrlX;
            MenuCopy.Text = CommonLocalizedResources.MenuCopy;
            MenuCopy.Shortcut = Shortcut.CtrlC;
            MenuPaste.Text = CommonLocalizedResources.MenuPaste;
            MenuPaste.Shortcut = Shortcut.CtrlV;
            MenuDeleteSelection.Text = CommonLocalizedResources.MenuDeleteSelection;
            MenuDeleteSelection.Shortcut = Shortcut.Del;
            MenuSelectAll.Text = CommonLocalizedResources.MenuSelectAll;
            MenuSelectAll.Shortcut = Shortcut.CtrlA;

            #endregion

            #region MenuView

            // MenuView and list menus in it
            MenuView.Text = CommonLocalizedResources.MenuView;
            MenuToolbar.Text = CommonLocalizedResources.MenuViewToolbar;
            MenuViewStatus.Text = CommonLocalizedResources.MenuViewStatus;
            MenuLine3.Text = MenuLine;
            MenuFullScreen.Text = CommonLocalizedResources.MenuViewFullScreen;
            MenuFullScreen.Shortcut = Shortcut.CtrlF;
            MenuZoom.Text = CommonLocalizedResources.MenuZoom;

            #endregion

            #region MenuImage

            // MenuImage and list menus in it
            MenuImage.Text = CommonLocalizedResources.MenuImage;
            MenuRotate.Text = CommonLocalizedResources.MenuRotate;
            MenuResize.Text = CommonLocalizedResources.MenuResize;
            MenuRotateRight90Deg.Text = CommonLocalizedResources.MenuRotateRight90;
            MenuRotateLeft90Deg.Text = CommonLocalizedResources.MenuRotateLeft90;
            MenuRotate180Deg.Text = CommonLocalizedResources.MenuRotate180;
            MenuRotateFlipH.Text = CommonLocalizedResources.MenuRotateFlipH;
            MenuRotateFlipV.Text = CommonLocalizedResources.MenuRotateFlipV;

            #endregion

            #region Menu invisible

            MenuSetAsWallpaperTitled.Text = string.Empty;
            MenuSetAsWallpaperCenterd.Text = string.Empty;
            MenuSetForBeijing.Text = string.Empty;
            MenuMostRecentlyUsedFiles.Text = string.Empty;
            MenuReadRecent1.Visible = false;
            MenuReadRecent2.Visible = false;
            MenuReadRecent3.Visible = false;
            MenuReadRecent4.Visible = false;

            #endregion

            MenuPaint.MenuItems.Add(MenuFile);
            MenuPaint.MenuItems.Add(MenuEdit);
            MenuPaint.MenuItems.Add(MenuView);
            MenuPaint.MenuItems.Add(MenuImage);

            Menu = MenuPaint;
            MenuFile.MenuItems.AddRange(new MenuItem[] { MenuNew, MenuOpen, MenuSave, MenuSaveAs, MenuLine1, MenuExit });
            MenuEdit.MenuItems.AddRange(new MenuItem[] { MenuUndo, MenuRedo, MenuLine2, MenuCut, MenuCopy, MenuPaste, MenuDeleteSelection, MenuSelectAll });
            MenuView.MenuItems.AddRange(new MenuItem[] { MenuToolbar, MenuViewStatus, MenuLine3, MenuFullScreen, MenuZoom });
            MenuImage.MenuItems.AddRange(new MenuItem[] { MenuRotate, MenuResize });
            MenuRotate.MenuItems.AddRange(new MenuItem[] { MenuRotateRight90Deg, MenuRotateLeft90Deg, MenuRotate180Deg, MenuRotateFlipH, MenuRotateFlipV });

            #region Menu click event

            #region MenuFile

            MenuNew.Click += new EventHandler(MenuNew_Click);
            MenuOpen.Click += new EventHandler(MenuOpen_Click);
            MenuSave.Click += new EventHandler(MenuSave_Click);
            MenuSaveAs.Click += new EventHandler(MenuSaveAs_Click);
            MenuExit.Click += new EventHandler(MenuExit_Click);

            #endregion

            #region MenuEdit

            MenuEdit.Popup += new EventHandler(MenuEdit_Popup);

            MenuUndo.Click += new EventHandler(MenuUndo_Click);
            MenuRedo.Click += new EventHandler(MenuRedo_Click);

            MenuCut.Click += new EventHandler(MenuCut_Click);
            MenuCopy.Click += new EventHandler(MenuCopy_Click);
            MenuPaste.Click += new EventHandler(MenuPaste_Click);
            MenuDeleteSelection.Click += new EventHandler(MenuDeleteSelection_Click);
            MenuSelectAll.Click += new EventHandler(MenuSelectAll_Click);

            #endregion

            #region MenuView

            MenuToolbar.Click += new EventHandler(MenuToolbar_Click);
            MenuViewStatus.Click += new EventHandler(MenuViewStatus_Click);
            MenuFullScreen.Click += new EventHandler(MenuFullScreen_Click);
            MenuZoom.Click += new EventHandler(MenuZoom_Click);

            #endregion

            #region MenuImage

            MenuRotateRight90Deg.Click += new EventHandler(MenuRotateRight90Deg_Click);
            MenuRotateLeft90Deg.Click += new EventHandler(MenuRotateLeft90Deg_Click);
            MenuRotate180Deg.Click += new EventHandler(MenuRotate180Deg_Click);
            MenuRotateFlipH.Click += new EventHandler(MenuRotateFlipH_Click);
            MenuRotateFlipV.Click += new EventHandler(MenuRotateFlipV_Click);
            MenuResize.Click += new EventHandler(MenuResize_Click);

            #endregion

            #endregion

            #endregion
        }

        /// <summary>
        /// Load guiPaint with selected image from RichTextBoxExtended
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuiPaint_Load(object sender, EventArgs e)
        {

            Image img = Clipboard.GetImage();
            Clipboard.Clear();
            if (img != null)
            {
                Bitmap bitmap = new Bitmap(img);
                canvas1.ChangeBackgroundImage(bitmap);
            }
        }

        #region MainMenuEvent

        #region topmenu

        /// <summary>
        /// Set default value for menus in menu edit when menu edit pop up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuEdit_Popup(object sender, EventArgs e)
        {
            MenuUndo.Enabled = canvas1.DrawShape.CanUndo;
            MenuRedo.Enabled = canvas1.DrawShape.CanRedo;
            MenuCut.Enabled = canvas1.IsValidSelectionArea();
            MenuDeleteSelection.Enabled = canvas1.IsValidSelectionArea();
            MenuPaste.Enabled = Clipboard.ContainsImage();
        }

        /// <summary>
        /// Set default value for menus in menu view when menu view pop up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuView_Popup(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Set default value for menus in menu image when menu image pop up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuImage_Popup(object sender, EventArgs e)
        {

        }

        #endregion

        #region MenuFile

        /// <summary>
        /// Crate new paint paper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuNew_Click(object sender, EventArgs e)
        {
            string text = Text;
            DialogResult dr = DialogResult.Cancel;
            if (!canvas1.DrawShape.Saved)
            {
                if (SaveDialog.IsDisposed)
                    SaveDialog = new SaveDialog();
                dr = SaveDialog.ShowDialog();
            }
            if (dr == DialogResult.OK || canvas1.DrawShape.Saved)
            {
                canvas1.Initial();
                PaintColor.PenColor = Color.Black;
                PaintColor.BrushColor = Color.White;
                CurrentFilePath = string.Empty;
            }
            else
                Text = text;
        }

        /// <summary>
        /// Open an image on disk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuOpen_Click(object sender, EventArgs e)
        {
            string text = Text;
            DialogResult dr = DialogResult.Cancel;
            if (!canvas1.DrawShape.Saved)
            {
                if (SaveDialog.IsDisposed)
                    SaveDialog = new SaveDialog();
                dr = SaveDialog.ShowDialog();
            }
            if (dr == DialogResult.OK || canvas1.DrawShape.Saved)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    WriteRecent(openFileDialog1.FileName);
                    canvas1.ChangeBackgroundImage(openFileDialog1.FileName);
                    Text = Path.GetFileName(openFileDialog1.FileName) + ImageNameBehind;
                    EnableSetWallpaper = true;
                    CurrentFilePath = openFileDialog1.FileName;
                }
            }
            else
                Text = text;
        }

        /// <summary>
        /// Write a recent file
        /// </summary>
        /// <param name="name"></param>
        public void WriteRecent(string name)
        {
            List<String> list = new List<string>();
            list.AddRange((string[])FileList.ToArray().Clone());
            string filepath = Path.GetDirectoryName(Application.ExecutablePath) + FilePathConfigName;
            if (list.Count == 4)
                list.RemoveAt(0);
            if (list.IndexOf(name) == -1)
                list.Add(name);
            string fileName = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                fileName += list[i].ToString() + ";";
            }
            if (fileName != string.Empty)
                fileName = fileName.Substring(0, fileName.Length - 1);
            Accessory.WritePrivateProfileSection("RECENT", string.Format("filenames={0}", fileName), filepath);
            ReadRecent();
        }

        /// <summary>
        /// Read the most recently used files
        /// </summary>
        /// <returns></returns>
        public List<String> ReadRecent()
        {
            List<String> list = new List<String>();
            string filepath = Path.GetDirectoryName(Application.ExecutablePath) + FilePathConfigName;
            if (File.Exists(filepath))
            {
                list.AddRange(Accessory.GetPrivateProfileString("RECENT", "filenames", filepath).Split(';'));
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (!File.Exists(list[i]))
                        list.RemoveAt(i);
                }
            }
            else
                return list;
            FileList.Clear();
            FileList.AddRange((string[])list.ToArray().Clone());
            if (list.Count > 0)
            {
                MenuMostRecentlyUsedFiles.Visible = false;
                Graphics g = CreateGraphics();
                int width = 200;
                if (g.MeasureString(list[0].ToString(), SystemFonts.MenuFont).Width > width)
                    list[0] = Path.GetFileName(list[0].ToString());
                MenuReadRecent1.Text = "1 " + list[0].ToString();
                MenuReadRecent1.Visible = true;
                if (list.Count > 1)
                {
                    if (g.MeasureString(list[1].ToString(), SystemFonts.MenuFont).Width > width)
                        list[1] = Path.GetFileName(list[1].ToString());
                    MenuReadRecent2.Text = "2 " + list[1].ToString();
                    //MenuReadRecent2.Visible = true;
                }
                if (list.Count > 2)
                {
                    if (g.MeasureString(list[2].ToString(), SystemFonts.MenuFont).Width > width)
                        list[2] = Path.GetFileName(list[2].ToString());
                    MenuReadRecent3.Text = "3 " + list[2].ToString();
                    //MenuReadRecent3.Visible = true;
                }
                if (list.Count > 3)
                {
                    if (g.MeasureString(list[3].ToString(), SystemFonts.MenuFont).Width > width)
                        list[3] = Path.GetFileName(list[3].ToString());
                    MenuReadRecent4.Text = "4 " + list[3].ToString();
                    //MenuReadRecent4.Visible = true;
                }
                g.Dispose();
            }
            else
                MenuMostRecentlyUsedFiles.Visible = true;
            return list;
        }

        /// <summary>
        /// Save image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuSave_Click(object sender, EventArgs e)
        {
            DeSelect();
            if (saveFileDialog1.FileName == string.Empty)
            {
                MenuSaveAs_Click(null, null);
            }
            else
            {
                if (!canvas1.DrawShape.Saved)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        switch (saveFileDialog1.FilterIndex)
                        {
                            case 0:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 1:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 2:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 3:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 4:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case 5:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            case 6:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                                break;
                            case 7:
                                canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                        MenuSetAsWallpaperTitled.Enabled = true;
                        MenuSetAsWallpaperCenterd.Enabled = true;
                        MenuSetForBeijing.Enabled = true;
                        WriteRecent(saveFileDialog1.FileName);
                        canvas1.DrawShape.Saved = true;
                        Text = Path.GetFileName(saveFileDialog1.FileName) + ImageNameBehind;
                        CurrentFilePath = saveFileDialog1.FileName;
                    }
                }
                else
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 0:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 1:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 2:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 3:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 4:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 5:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 6:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case 7:
                            canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                    CurrentFilePath = saveFileDialog1.FileName;
                }
            }
        }

        /// <summary>
        /// Save As image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuSaveAs_Click(object sender, EventArgs e)
        {
            DeSelect();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 0:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 1:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 2:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 4:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 5:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 6:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case 7:
                        canvas1.PaintImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                MenuSetAsWallpaperTitled.Enabled = true;
                MenuSetAsWallpaperCenterd.Enabled = true;
                MenuSetForBeijing.Enabled = true;
                WriteRecent(saveFileDialog1.FileName);
                canvas1.DrawShape.Saved = true;
                SaveDialog.SaveClick = true;
                CurrentFilePath = saveFileDialog1.FileName;
            }
            else
                Text = Path.GetFileName(saveFileDialog1.FileName) + ImageNameBehind;
        }

        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region Edit

        /// <summary>
        /// Undo action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuUndo_Click(object sender, EventArgs e)
        {
            canvas1.DrawShape.Undo();
        }

        /// <summary>
        /// Redo action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRedo_Click(object sender, EventArgs e)
        {
            canvas1.DrawShape.Redo();
        }

        /// <summary>
        /// Cut image in selection area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuCut_Click(object sender, EventArgs e)
        {
            canvas1.CutSelectionArea();
        }

        /// <summary>
        /// Copy image in selection area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuCopy_Click(object sender, EventArgs e)
        {
            canvas1.CopySelectionArea();
        }

        /// <summary>
        /// paste image from clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPaste_Click(object sender, EventArgs e)
        {
            canvas1.PasteSelectionArea();
        }

        /// <summary>
        /// Delete image in selection area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuDeleteSelection_Click(object sender, EventArgs e)
        {
            canvas1.DeleteSelectionArea();
        }

        /// <summary>
        /// Select all area of image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSelectAll_Click(object sender, EventArgs e)
        {
            //ts_btnSelect_Click(null, null);
            fld_barBtnSelect_ItemClick(null, null);
            canvas1.SelectAllImage();
        }

        #endregion

        #region View

        /// <summary>
        /// View tool bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuToolbar_Click(object sender, EventArgs e)
        {
            MenuToolbar.Checked = !MenuToolbar.Checked;
            if (!MenuToolbar.Checked)
            {
                bar1.Visible = false;
                bar2.Visible = false;
                bar3.Visible = false;
                bar4.Visible = false;
            }
            else
            {
                bar4.Visible = true;
                bar3.Visible = true;
                bar2.Visible = true;
                bar1.Visible = true;
            }
        }

        /// <summary>
        /// Zoom image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuZoom_Click(object sender, EventArgs e)
        {
            fld_barBtnZoom_ItemClick(null, null);
        }

        /// <summary>
        /// View Status bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuViewStatus_Click(object sender, EventArgs e)
        {
            MenuViewStatus.Checked = !MenuViewStatus.Checked;
            if (!MenuViewStatus.Checked)
            {
                StatusBar.Visible = false;
                canvas1.Size = new Size(canvas1.Size.Width, canvas1.Size.Height + 23);
            }
            else
            {
                StatusBar.Visible = true;
                canvas1.Size = new Size(canvas1.Size.Width, canvas1.Size.Height - 23);
            }
        }

        /// <summary>
        /// View image in full screen mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuFullScreen_Click(object sender, EventArgs e)
        {
            Form fullScreen = new Form();
            fullScreen.FormBorderStyle = FormBorderStyle.None;
            fullScreen.BackgroundImage = DrawShape.CombineBitmap(DrawShape.CreateBitmap(Screen.PrimaryScreen.Bounds.Size, Color.Black), canvas1.PaintImage, (Screen.PrimaryScreen.Bounds.Size.Width - canvas1.PaintImage.Width) / 2, (Screen.PrimaryScreen.Bounds.Size.Height - canvas1.PaintImage.Height) / 2);
            fullScreen.WindowState = FormWindowState.Maximized;
            fullScreen.Click += new EventHandler(VewImage);
            fullScreen.Show();
        }

        /// <summary>
        /// View image in normal mode when user click on screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VewImage(object sender, EventArgs e)
        {
            ((Form)sender).Dispose();
        }

        #endregion

        #region Image

        /// <summary>
        /// Resize the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuResize_Click(object sender, EventArgs e)
        {
            fld_barBtnResizeImg_ItemClick(null, null);
        }

        /// <summary>
        /// Rotate and flip vertical the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRotateFlipV_Click(object sender, EventArgs e)
        {
            fld_barBtnFlipV_ItemClick(null, null);
        }

        /// <summary>
        /// Rotate and flip horizontal the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRotateFlipH_Click(object sender, EventArgs e)
        {
            fld_barBtnFlipH_ItemClick(null, null);
        }

        /// <summary>
        /// Rotate 180 degree the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRotate180Deg_Click(object sender, EventArgs e)
        {
            fld_barBtnRotate180_ItemClick(null, null);
        }

        /// <summary>
        /// Rotate left 90 degree the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRotateLeft90Deg_Click(object sender, EventArgs e)
        {
            fld_barBtnRotateLeft_ItemClick(null, null);
        }

        /// <summary>
        /// Rotate right 90 degree the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuRotateRight90Deg_Click(object sender, EventArgs e)
        {
            //tsmRotateRight90_Click(null, null);
            fld_barBtnRotateRight_ItemClick(null, null);
        }

        #endregion

        #endregion

        #region Paint event methods

        private void GuiPaint_KeyDown(object sender, KeyEventArgs e)
        {
            //Hold down the Shift key to determine whether, if the hold, then draw the polygon graphics are positive
            canvas1.DrawShape.Shift = e.Shift;
        }

        private void GuiPaint_KeyUp(object sender, KeyEventArgs e)
        {
            // release the Shift key
            canvas1.DrawShape.Shift = false;
        }

        private void GuiPaint_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// Drag enter paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuiPaint_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        /// <summary>
        /// Drag and drop on paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuiPaint_DragDrop(object sender, DragEventArgs e)
        {
            string text = Text;
            DialogResult dr = DialogResult.Cancel;
            if (!canvas1.DrawShape.Saved)
            {
                if (SaveDialog.IsDisposed)
                    SaveDialog = new SaveDialog();
                dr = SaveDialog.ShowDialog();
            }
            if (dr == DialogResult.OK)
            {
                string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                canvas1.ChangeBackgroundImage(path);
            }
            else
                Text = text;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //Determine the ESC key to cancel the unfinished drawing curves or polygons
            if (e.KeyValue == 27)
            {
                canvas1.CancelDraw();
            }
            base.OnKeyDown(e);
        }

        #endregion

        #region Toolbar

        #region Main tool bars

        /// <summary>
        /// Select an area on image to do something
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrentShapeType = DrawShape.ShapeType.Select;
            SetCanvasShapeType(DrawShape.ShapeType.Select);
        }

        /// <summary>
        /// Edit text on image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            SetCanvasShapeType(DrawShape.ShapeType.Text);
        }

        /// <summary>
        /// Eraser tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnEraser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Eraser;
            SetCanvasShapeType(DrawShape.ShapeType.Eraser);
        }

        /// <summary>
        /// Pencil tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnPencil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Pencil;
            SetCanvasShapeType(DrawShape.ShapeType.Pencil);
        }

        /// <summary>
        /// Zoom in image if user mouse-left click and zoom out if user mouse-right click on image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnZoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            OriginalImage = canvas1.PaintImage;
            CurrentShapeType = DrawShape.ShapeType.Zoom;
            SetCanvasShapeType(DrawShape.ShapeType.Zoom);
        }

        /// <summary>
        /// Fill color on image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnFillColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.FillWithColor;
            SetCanvasShapeType(DrawShape.ShapeType.FillWithColor);
        }

        #endregion

        #region Draw shape

        /// <summary>
        /// Draw straingt line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Line;
            SetCanvasShapeType(DrawShape.ShapeType.Line);
        }

        /// <summary>
        /// Draw curve line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnCurve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Curve;
            SetCanvasShapeType(DrawShape.ShapeType.Curve);
        }

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnRectangle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Rectangle;
            SetCanvasShapeType(DrawShape.ShapeType.Rectangle);
        }

        /// <summary>
        /// Draw round rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnRoundRect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.RoundedRectangle;
            SetCanvasShapeType(DrawShape.ShapeType.RoundedRectangle);
        }

        /// <summary>
        /// Draw polygon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnPolygon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Polygon;
            SetCanvasShapeType(DrawShape.ShapeType.Polygon);
        }

        /// <summary>
        /// Draw ellipse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnElip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            CurrentShapeType = DrawShape.ShapeType.Ellipse;
            SetCanvasShapeType(DrawShape.ShapeType.Ellipse);
        }

        #endregion

        #region Change size

        /// <summary>
        /// Small size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnSize1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetEraserOrLineSize(CurrentShapeType, 1);
        }

        /// <summary>
        /// Medium size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnSize2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetEraserOrLineSize(CurrentShapeType, 2);
        }

        /// <summary>
        /// Large size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnSize3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetEraserOrLineSize(CurrentShapeType, 3);
        }

        /// <summary>
        /// Extra large size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnSize4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetEraserOrLineSize(CurrentShapeType, 4);
        }

        #endregion

        #region Change color

        /// <summary>
        /// Change color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            PaintColor.ShowColor();
            canvas1.PenColor = PaintColor.PenColor;
            canvas1.BrushColor = PaintColor.BrushColor;
        }

        #endregion

        #region Rotate image

        /// <summary>
        /// Rotate right 90 degree image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnRotateRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentShapeType == DrawShape.ShapeType.Select && canvas1.IsValidSelectionArea())
            {
                canvas1.RotateSelectionArea(90);
            }
            else
            {
                SetCanvasShapeType(DrawShape.ShapeType.Rotate);
                Image imgRotated = (Image)DrawShape.RotateWise((Bitmap)canvas1.PaintImage, 90, Color.White);
                canvas1.ChangeBackgroundImage((Bitmap)imgRotated);
            }
        }

        /// <summary>
        /// Rotate left 90 degree image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnRotateLeft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentShapeType == DrawShape.ShapeType.Select && canvas1.IsValidSelectionArea())
            {
                canvas1.RotateSelectionArea(-90);
            }
            else
            {
                SetCanvasShapeType(DrawShape.ShapeType.Rotate);
                Image imgRotated = (Image)DrawShape.RotateWise((Bitmap)canvas1.PaintImage, -90, Color.White);
                canvas1.ChangeBackgroundImage((Bitmap)imgRotated);
            }
        }

        /// <summary>
        /// Rotate 180 degree image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnRotate180_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentShapeType == DrawShape.ShapeType.Select && canvas1.IsValidSelectionArea())
            {
                canvas1.RotateSelectionArea(90);
                canvas1.RotateSelectionArea(90);
            }
            else
            {
                SetCanvasShapeType(DrawShape.ShapeType.Rotate);
                Image imgRotated = (Image)DrawShape.RotateWise((Bitmap)canvas1.PaintImage, 180, Color.White);
                canvas1.ChangeBackgroundImage((Bitmap)imgRotated);
            }
        }

        /// <summary>
        /// Flip vertical image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnFlipV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentShapeType == DrawShape.ShapeType.Select && canvas1.IsValidSelectionArea())
            {
                canvas1.FlipSelectionArea(DrawShape.FlipType.Vertical);
            }
            else
            {
                SetCanvasShapeType(DrawShape.ShapeType.Rotate);
                canvas1.PaintImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                canvas1.ChangeBackgroundImage((Bitmap)canvas1.PaintImage);
            }
        }

        /// <summary>
        /// Flip Horizontol image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnFlipH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrentShapeType == DrawShape.ShapeType.Select && canvas1.IsValidSelectionArea())
            {
                canvas1.FlipSelectionArea(BOSERP.Utilities.Paint.DrawShape.FlipType.Horizontal);
            }
            else
            {
                SetCanvasShapeType(DrawShape.ShapeType.Rotate);
                canvas1.PaintImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                canvas1.ChangeBackgroundImage((Bitmap)canvas1.PaintImage);
            }
        }

        #endregion

        #region Resize, update image

        /// <summary>
        /// Resize image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnResizeImg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            guiResizeImage guiResize = new guiResizeImage();
            guiResize.Tag = string.Format("{0}_{1}", canvas1.PaintImage.Width, canvas1.PaintImage.Height);
            if (guiResize.ShowDialog() == DialogResult.OK)
            {
                if (guiResize.Tag != null)
                {
                    string[] resizeValue = guiResize.Tag.ToString().Split('_');
                    int resizeType = Convert.ToInt32(resizeValue[0]);
                    int width = 0;
                    int height = 0;
                    // resizeType is pixels
                    if (resizeType == 1)
                    {
                        width = resizeValue[1] != string.Empty ? Convert.ToInt32(resizeValue[1]) : -1;
                        height = resizeValue[2] != string.Empty ? Convert.ToInt32(resizeValue[2]) : -1;
                    }
                    // resizeType is percentage
                    if (resizeType == 2)
                    {
                        width = resizeValue[1] != string.Empty ? (int)(canvas1.PaintImage.Width * Convert.ToInt32(resizeValue[1]) / 100) : -1;
                        height = resizeValue[2] != string.Empty ? (int)(canvas1.PaintImage.Height * Convert.ToInt32(resizeValue[2]) / 100) : -1;
                    }
                    if (width > 0 && height > 0)
                    {
                        Bitmap imgResized = new Bitmap(canvas1.ResizeImage(canvas1.PaintImage, width, height));
                        canvas1.ChangeBackgroundImage(imgResized);
                    }
                    else
                    {
                        MessageBox.Show(CommonLocalizedResources.CheckValueResizedMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Update image into template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnUpdateImg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeSelect();
            Clipboard.SetImage(canvas1.PaintImage);
            Tag = CommonLocalizedResources.MenuUpdateImage;
            Dispose();
        }

        #endregion

        #region Text toolbar

        /// <summary>
        /// Show text toolbar if has an input text
        /// </summary>
        /// <param name="checkInput">true if has an input, othewise: false</param>
        public void ShowTextToolbar(bool checkInput)
        {
            bar5.Visible = checkInput;
            fld_barEditTextSize.EditValue = 8;
        }

        /// <summary>
        /// Change font style is bold
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnTextBold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            canvas1.ChangeFontStyle(FontStyle.Bold, !canvas1.IsBold);
        }

        /// <summary>
        /// Change font style is italic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnTextItalic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            canvas1.ChangeFontStyle(FontStyle.Italic, !canvas1.IsItalic);
        }

        /// <summary>
        /// Change font style is underline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnTextUnderline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            canvas1.ChangeFontStyle(FontStyle.Underline, !canvas1.IsUnderline);
        }

        /// <summary>
        /// Change font color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_barBtnTextColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PaintColor.ShowColor();
            TextColor = new SolidBrush(PaintColor.PenColor);
            canvas1.ChangeFontColor(PaintColor.PenColor);
        }

        private void fld_barEditTextSize_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem textSizeBar = (BarEditItem)sender;
            float size = Convert.ToSingle(textSizeBar.EditValue);
            canvas1.ChangeFontSize(size);
        }

        public void UpdateToolBar(bool bold, bool italic, bool underline)
        {
            fld_barBtnTextBold.Border = bold ? DevExpress.XtraEditors.Controls.BorderStyles.Style3D : DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            fld_barBtnTextItalic.Border = italic ? DevExpress.XtraEditors.Controls.BorderStyles.Style3D : DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            fld_barBtnTextUnderline.Border = underline ? DevExpress.XtraEditors.Controls.BorderStyles.Style3D : DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        #endregion

        #region sub methods

        /// <summary>
        /// Dispose the selection area
        /// </summary>
        private void DeSelect()
        {
            if (CurrentShapeType == DrawShape.ShapeType.Select)
            {
                canvas1.DrawShape.DeSelectArea();
                canvas1.PaintImage = canvas1.DrawShape.ImageDrew;
            }
        }

        /// <summary>
        /// Set ShapeType for canvas paint
        /// </summary>
        /// <param name="shapeType"></param>
        private void SetCanvasShapeType(DrawShape.ShapeType shapeType)
        {
            canvas1.ShapeType = shapeType;
            canvas1.GetCursorStyle(shapeType);
        }

        /// <summary>
        /// Set size of eraser or shape's line
        /// </summary>
        /// <param name="shapeType">the shape type</param>
        /// <param name="size">Size value</param>
        private void SetEraserOrLineSize(DrawShape.ShapeType shapeType, int size)
        {
            // Set size of eraser
            if (shapeType == DrawShape.ShapeType.Eraser)
            {
                canvas1.DrawShape.EraserSize = 4 * size;
            }
            // Set size of line
            if (shapeType == DrawShape.ShapeType.Line ||
                shapeType == DrawShape.ShapeType.Curve ||
                shapeType == DrawShape.ShapeType.Rectangle ||
                shapeType == DrawShape.ShapeType.RoundedRectangle ||
                shapeType == DrawShape.ShapeType.Ellipse ||
                shapeType == DrawShape.ShapeType.Polygon ||
                shapeType == DrawShape.ShapeType.Pencil)
            {
                canvas1.DrawShape.Pen.Width = size;
            }
        }

        #endregion

        #endregion
    }
}