using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Categories;

public partial class GetAllCategoriesPage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public List<Category> Categories { get; set; } = [];
    //public string SearchTerm { get; set; } = string.Empty;

    #endregion Properties

    #region Services

    [Inject]
    public ICategoryHandler Handler { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion Services

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            GetAllCategoriesRequest request = new();
            PagedResponse<List<Category>?> result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Categories = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion Overrides
}
