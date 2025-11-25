using System;

namespace ShopDomain.View
{
    public interface IResourceItemView
    {
        event Action AddButtonClicked;

        void SetName(string resourceName);

        void UpdateText(string value);
    }
}