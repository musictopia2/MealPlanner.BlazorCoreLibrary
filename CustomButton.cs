namespace MealPlanner.BlazorCoreLibrary;
public class CustomButton : ButtonComponentBase
{
    public override string BackColor => cc.Navy.ToWebColor();
    public override string TextColor => cc.Aqua.ToWebColor();
    public override string DisabledColor => cc.LightGray.ToWebColor(); //hopefully no problem for disabled color.
    public override string FontSize => "40px";
}