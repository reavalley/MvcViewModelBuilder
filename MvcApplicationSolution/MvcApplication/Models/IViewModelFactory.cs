﻿namespace MvcApplication.Models
{
    public interface IViewModelFactory
    {
        //T CreateViewModel<T>() where T : IViewModel;
        IViewModel GetViewModel(ViewModelType viewModelType);
    }
}