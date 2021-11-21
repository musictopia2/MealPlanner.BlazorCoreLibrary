namespace MealPlanner.BlazorCoreLibrary;
public partial class RecipesShellComponent
{
    [Inject]
    [AllowNull]
    private RecipesViewModel DataContext { get; set; }
    protected override void OnInitialized()
    {
        DataContext.StateChanged = StateHasChanged;
        base.OnInitialized();
    }
}