using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Collections;


public class MyExtendLabel : System.Windows.Forms.Label
{
    public MyExtendLabel()
    {
        this.Font = defaultFont;
    }
    private static Font defaultFont = new Font("ËÎÌו", 15, FontStyle.Bold | FontStyle.Italic);

    public override System.Drawing.Font Font
    {
        get
        {
            return (base.Font);
        }
        set
        {
            if (value == null)
                base.Font = defaultFont;
            else
            {
                if (value.Equals(System.Windows.Forms.Control.DefaultFont))
                    base.Font = defaultFont;
                else
                    base.Font = value;
            }
        }
    }

    public override void ResetFont()
    {
        Font = null;
    }



    private bool ShouldSerializeFont()
    {
        return (!Font.Equals(defaultFont));
    }
}
