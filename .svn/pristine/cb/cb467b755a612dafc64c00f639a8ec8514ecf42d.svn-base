using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Localization;

namespace BOSERP
{
    /// <summary>
    /// GroupBox control that provides functionality to 
    /// allow it to be collapsed.
    /// </summary>
    [ToolboxBitmap(typeof(CollapsibleGroupBox))]
    public partial class CollapsibleGroupBox : GroupBox
    {
        #region Fields
        /// <summary>
        /// Toggle rectangle
        /// </summary>
        private Rectangle ToggleRect = new Rectangle(8, 2, 11, 11);

        /// <summary>
        /// Close group box if collapsed is true,otherwise true
        /// </summary>
        private Boolean Collapsed = false;

        /// <summary>
        /// False if resizing from collapse of groupbox is false else true
        /// </summary>
        private Boolean ResizingFromCollapse = false;

        private const int m_collapsedHeight = 20;

        /// <summary>
        /// Full size of group box
        /// </summary>
        public Size FullSize = Size.Empty;

        #endregion

        #region Events & Delegates

        /// <summary>Fired when the Collapse Toggle button is pressed</summary>
        public delegate void CollapseBoxClickedEventHandler(object sender);
        public event CollapseBoxClickedEventHandler CollapseBoxClickedEvent;

        #endregion

        #region Constructor

        public CollapsibleGroupBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets full height of group box
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FullHeight
        {
            get { return FullSize.Height; }
        }

        /// <summary>
        /// Gets or sets IsCollapsed of group box
        /// </summary>
        [DefaultValue(false), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCollapsed
        {
            get { return Collapsed; }
            set
            {
                if (value != Collapsed)
                {
                    Collapsed = value;

                    if (!value)
                        // Expand
                        this.Size = FullSize;
                    else
                    {
                        // Collapse
                        ResizingFromCollapse = true;
                        this.Height = m_collapsedHeight;
                        ResizingFromCollapse = false;
                    }

                    foreach (Control c in Controls)
                        c.Visible = !value;

                    Invalidate();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CollapsedHeight
        {
            get { return m_collapsedHeight; }
        }                                                                                                           

        #endregion

        #region Overrides

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.FullSize = this.Size;
            this.ToggleCollapsed();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (ToggleRect.Contains(e.Location))
                ToggleCollapsed();
            else
                base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            HandleResize();
            DrawGroupBox(e.Graphics);
            DrawToggleButton(e.Graphics);
        }

        #endregion

        #region Implimentation

        /// <summary>
        /// Draw group box 
        /// </summary>
        /// <param name="g"></param>
        private void DrawGroupBox(Graphics g)
        {
            // Get windows to draw the GroupBox
            Rectangle bounds = new Rectangle(ClientRectangle.X, ClientRectangle.Y + 6, ClientRectangle.Width, ClientRectangle.Height - 6);
           //// Rectangle bounds = new Rectangle(0,0,0,0);
            
          // GroupBoxRenderer.DrawGroupBox(g, bounds, Enabled ? GroupBoxState.Disabled : GroupBoxState.Disabled);

           // // Text Formating positioning & Size
            StringFormat sf = new StringFormat();
            int i_textPos = (bounds.X + 8) + ToggleRect.Width + 2;
            int i_textSize = (int)g.MeasureString(Text, this.Font).Width;
            i_textSize = i_textSize < 1 ? 1 : i_textSize;
            int i_endPos = i_textPos + i_textSize + 1;

           // // Draw a line to cover the GroupBox border where the text will sit
            g.DrawLine(SystemPens.Control, i_textPos, bounds.Y, i_endPos, bounds.Y);

           // // Draw the GroupBox text
            using (SolidBrush drawBrush = new SolidBrush(Color.FromArgb(0, 70, 213)))
                g.DrawString(Text, this.Font, drawBrush, i_textPos, 0);
        }
       
        /// <summary>
        /// Draw toggle button
        /// </summary>
        /// <param name="g"></param>
        private void DrawToggleButton(Graphics g)
        {
            if(IsCollapsed)
                g.DrawImage(CommonLocalizedResources.plus, ToggleRect);
            else
                g.DrawImage(CommonLocalizedResources.minus, ToggleRect);
        }

        /// <summary>
        /// Toggle collapsed
        /// </summary>
        private void ToggleCollapsed()
        {
            IsCollapsed = !IsCollapsed;

            if (CollapseBoxClickedEvent != null)
                CollapseBoxClickedEvent(this);
        }

        /// <summary>
        /// Handle resize
        /// </summary>
        private void HandleResize()
        {
            if (!ResizingFromCollapse && !Collapsed)
                FullSize = this.Size;
        }

        #endregion
    }
}