using System;

namespace Shop.View
{
    public interface IDetailCardView
    {
        event Action BackButtonClicked;

        IBundleCardView BundleCardView { get; }
    }
}