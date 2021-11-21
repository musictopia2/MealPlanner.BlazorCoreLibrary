namespace MealPlanner.BlazorCoreLibrary;
public partial class LastHaveComponent
{
    [Parameter]
    public string CurrentFood { get; set; } = "";
    [Parameter]
    public string CurrentDisplayDate { get; set; } = "";
}