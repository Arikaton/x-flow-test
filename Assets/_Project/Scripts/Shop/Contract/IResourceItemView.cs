using System;

namespace Shop.View
{
    public interface IResourceItemView
    {
        event Action AddButtonClicked;

        void SetName(string resourceName);

        void UpdateValue(string value);
    }
}