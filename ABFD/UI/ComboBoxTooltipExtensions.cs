using System;
using System.Drawing;
using System.Windows.Forms;

namespace ABetterFaviconDownloader.UI
{
    internal static class ComboBoxTooltipExtensions
    {
        public static void EnableItemToolTips(this ComboBox comboBox, Func<object, string> tooltipProvider)
        {
            if (comboBox == null || tooltipProvider == null) return;

            // Initialize a single ToolTip component for this specific ComboBox
            ToolTip itemToolTip = new ToolTip();

            // Track the last hovered index to prevent the tooltip from flickering
            int lastHoveredIndex = -1;

            // Calculate the exact width of the widest text string
            int maxItemWidth = MaxDropDownItemWidth(comboBox);

            // Enforce the owner draw mode required to detect item highlights
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;

            comboBox.DrawItem += (sender, e) =>
            {
                if (e.Index < 0) return;

                // Draw the standard item background and text
                e.DrawBackground();
                string itemText = comboBox.GetItemText(comboBox.Items[e.Index]);

                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
                }

                // Check if the item is currently highlighted/hovered in the dropdown list
                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                if (isSelected && comboBox.DroppedDown)
                {
                    if (e.Index != lastHoveredIndex)
                    {
                        lastHoveredIndex = e.Index;
                        string tooltipText = tooltipProvider(comboBox.Items[e.Index]);

                        if (!string.IsNullOrEmpty(tooltipText))
                        {
                            //// Calculate the exact width of the rendered text string
                            //Size textSize = TextRenderer.MeasureText(itemText, e.Font);

                            //// Add the left boundary offset where the text starts rendering
                            //int textEndX = e.Bounds.Left + textSize.Width;
                            int textEndX = e.Bounds.Left + maxItemWidth;

                            // Prevent the tooltip from exceeding the control's right margin
                            // (Keeps alignment clean if text happens to be short)
                            int tooltipX = Math.Max(textEndX + 5, e.Bounds.Left + 20);

                            // Show the tooltip relative to the actual end of the text string
                            itemToolTip.Show(tooltipText, comboBox, tooltipX, e.Bounds.Top);
                        }
                        else
                        {
                            itemToolTip.Hide(comboBox);
                        }
                    }
                }
                e.DrawFocusRectangle();
            };

            // Reset and hide tracking states when the dropdown collapses
            comboBox.DropDownClosed += (sender, e) =>
            {
                itemToolTip.Hide(comboBox);
                lastHoveredIndex = -1;
            };
        }
        
        static int MaxDropDownItemWidth(ComboBox comboBox)
        {
            int maxWidth = 0, itemWidth;
            foreach (var item in comboBox.Items)
            {
                // Calculate the exact width of the rendered text string
                Size textSize = TextRenderer.MeasureText(item.ToString(), comboBox.Font);
                itemWidth = textSize.Width;
                if (itemWidth > maxWidth)
                {
                    maxWidth = itemWidth;
                }
            }
            return maxWidth;
        }
    }
}