namespace MealPlanner.BlazorCoreLibrary;
public partial class MealPlannerCreaterComponent
{
    private AutoCompleteStyleModel _comboModel = new();
    protected override void OnInitialized()
    {
        DataContext!.FocusFirst = FocusAsync;
        _comboModel.Height = "300px";
        _comboModel.Width = "100%";
        DataContext.StateHasChanged = () => InvokeAsync(StateHasChanged);
        _comboBox = null;
    }
    private ComboBoxStringList? _comboBox;
    private BasicList<string> _listForCombo => DataContext!.CurrentList.Select(xx => xx.MainCourse).ToBasicList();
    [Inject]
    private ShellViewModel? DataContext { get; set; }
    private void ChangeData(string value)
    {
        DataContext!.EnteredSoFar = value;
        DataContext.UpdateFoodSelected();
    }
    private async Task ComboPressedAsync()
    {
        var item = DataContext!.CurrentList.SingleOrDefault(xx => xx.MainCourse == DataContext.EnteredSoFar);
        await DataContext.SaveNonSkippedMealAsync(item);
    }
    private bool _firsts = true;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_firsts && _comboBox is not null)
        {
            await _comboBox.GetTextBox!.Value.FocusAsync();
        }
    }
    private string SecondGridRows => $"{rr.MinContent} {rr.MaxContent} {rr.MinContent} 1fr";
    private string SecondGridColumns => $"7fr 2fr {rr.MinContent}";
    private async void FocusAsync()
    {
        if (_comboBox is null)
        {
            return;
        }
        await _comboBox.GetTextBox!.Value.FocusAsync();
    }
    protected override async Task OnInitializedAsync()
    {
        await DataContext!.InitAsync();
    }
}