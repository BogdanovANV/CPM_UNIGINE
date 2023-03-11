using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Unigine;
[Component(PropertyGuid = "e2fcc783f68e4706618af2ad401334283c188967")]
public class GetStor1Data : DbContext
{
    public DbSet<str1> table_storage1 { get; set; }
   
    public GetStor1Data()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=13092001");
    }
}
public class str1
{

    public int id { get; set; }
    public int amount { get; set; }
	public string name { get; set; }

}


public class GetStor2Data : DbContext
{
    public DbSet<str2> table_storage2 { get; set; }
   
    public GetStor2Data()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=13092001");
    }
}
public class str2
{

    public int id { get; set; }
    public int amount { get; set; }
	public string name { get; set; }

}

public class GUI : Component
{
	private WidgetWindow window;
    private WidgetButton button_0;
    private WidgetButton button_1;
    private WidgetEditLine editLine_0;
    private WidgetButton button_2;

    private WidgetDialogMessage dialog_message;

	
	public string tts;
    public string tts2;
    public float time = 0;
	private void Init()
	{
		// write here code to be called on component initialization
		window = new WidgetWindow("Данные", 160, 80);

        button_0 = new WidgetButton("Склад №1");
        button_0.Height = 70; button_0.Width = 70; button_0.SetPosition(0, 40);
		using (GetStor1Data db = new GetStor1Data())
            {
                
                var strf = db.table_storage1.ToList();

                foreach (str1 u in strf)
                {
                    tts = tts + u.name + " : " + u.amount + "\n";
                    
                }
            }
        button_0.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => button_message_clicked("Склад 1: Информация", tts));
        window.AddChild(button_0, Gui.ALIGN_OVERLAP);

        button_1 = new WidgetButton("Склад №2");
        button_1.Height = 70; button_1.Width = 70; button_1.SetPosition(button_0.Width + 30, 40);
        using (GetStor2Data db = new GetStor2Data())
            {
                
                var strt = db.table_storage2.ToList();

                foreach (str2 u in strt)
                {
                    tts2 = tts2 + u.name + " : " + u.amount + "\n";
                    
                }
            }
        button_1.AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => button_message_clicked("Склад 2: Информация", tts2));
        window.AddChild(button_1, Gui.ALIGN_OVERLAP);

        editLine_0 = new WidgetEditLine();
        editLine_0.Height = 30; editLine_0.Width = 150;
        window.AddChild(editLine_0, Gui.ALIGN_OVERLAP);

        button_2 = new WidgetButton("Поиск");
        button_2.Height = 30; button_2.Width = 30; button_2.SetPosition(editLine_0.Width + 5, 0);
        window.AddChild(button_2, Gui.ALIGN_OVERLAP | Gui.ALIGN_TOP);

        window.Arrange();
        Gui.GetCurrent().AddChild(window, Gui.ALIGN_OVERLAP | Gui.ALIGN_RIGHT | Gui.ALIGN_TOP);
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
        time += Game.IFps;
        if (time > 5){
        tts = "";
        tts2 = "";
        using (GetStor1Data db = new GetStor1Data())
            {
                
                var strf = db.table_storage1.ToList();

                foreach (str1 u in strf)
                {
                    tts = tts + u.name + " " + u.amount + "\n";
                    
                }
            }

		using (GetStor2Data db = new GetStor2Data())
            {
                
                var strt = db.table_storage2.ToList();

                foreach (str2 u in strt)
                {
                    tts2 = tts2 + u.name + " " + u.amount + "\n";
                    
                }
            }
            time = 0;
        }
	}

	private void dialog_ok_clicked(WidgetDialog dialog, int type) // Кнопка ОК
    {
        Log.Message("{0} ok clicked\n", dialog.Text);
        if (type == 1)
            Log.Message("{0}\n", (dialog as WidgetDialogFile).File);
        if (type == 2)
            Log.Message("{0}\n", (dialog as WidgetDialogColor).WebColor);
        Gui.GetCurrent().RemoveChild(dialog);
    }

    private void dialog_cancel_clicked(Widget widget, WidgetDialog dialog) // Кнопка Cancel
    {
        Log.Message("{0} cancel clicked\n", dialog.Text);
        Gui.GetCurrent().RemoveChild(dialog);
    }

    private void dialog_show(WidgetDialog dialog, int type)
    {
        dialog.GetOkButton().AddCallback(Gui.CALLBACK_INDEX.CLICKED, () => dialog_ok_clicked(dialog, type));
        dialog.GetCancelButton().AddCallback(Gui.CALLBACK_INDEX.CLICKED, widget => dialog_cancel_clicked(widget, dialog));
        Gui.GetCurrent().AddChild(dialog, Gui.ALIGN_OVERLAP | Gui.ALIGN_CENTER);
        dialog.SetPermanentFocus();
    }

    private void button_message_clicked(string str, string message)
    {
        dialog_message = new WidgetDialogMessage(Gui.GetCurrent(), str);
        dialog_message.MessageText = message;
        dialog_show(dialog_message, 0);
    }
}