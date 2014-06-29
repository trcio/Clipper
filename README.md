Clipper
=======

Easily hook onto Window's clipboard in an easy, event-driven fashion.


###Use
Example form with a textbox that automatically shows the clipboard whenever it changes.
```c#
using Clipper;
using Clipper.Entities;

public partial class ExampleForm : Form
{
    public ExampleForm()
    {
        InitializeComponent();
        ClipperGlobal.ClipperTextChanged += ClipperGlobal_ClipperTextChanged;
        ClipperGlobal.Initialize();
    }

    private void ClipperGlobal_ClipperTextChanged(ClipperEventArgs e)
    {
        textBox1.Text = e.ClipboardText;
    }
}
```
