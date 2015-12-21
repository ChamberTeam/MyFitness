namespace MyFitness.Universal.ViewModels
{
    public interface IPageViewModel
    {
        //No 'set' because it won't change in time
        string Title { get; }

        IContentViewModel ContentViewModel { get; set; }
    }
}
