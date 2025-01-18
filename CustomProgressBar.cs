using System.Drawing;
using System.Windows.Forms;

public class CustomProgressBar : ProgressBar
{
    public bool IsPlayerUnit { get; set; } = true; // Determines if it's a player or enemy unit

    public CustomProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true); // Enable custom painting
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Calculate the fill percentage
        float percentage = (float)(this.Value - this.Minimum) / (this.Maximum - this.Minimum);

        // Determine the color
        Color fillColor;
        if (percentage >= 0.5f)
            fillColor = IsPlayerUnit ? Color.Green : Color.Blue;
        else if (percentage >= 0.2f)
            fillColor = Color.Orange;
        else if (percentage > 0f)
            fillColor = Color.Red;
        else
            fillColor = Color.Gray; // Default color if value is 0

        // Draw the background
        using (Brush backgroundBrush = new SolidBrush(Color.LightGray))
        {
            e.Graphics.FillRectangle(backgroundBrush, this.ClientRectangle);
        }

        // Draw the filled part
        int fillWidth = (int)(percentage * this.Width);
        using (Brush fillBrush = new SolidBrush(fillColor))
        {
            e.Graphics.FillRectangle(fillBrush, 0, 0, fillWidth, this.Height);
        }

        // Draw the border
        e.Graphics.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
    }
}
