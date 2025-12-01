using Shop.View;

namespace Shop.UI
{
    public interface IResourceBarView
    {
        IResourceItemView CreateResourceItemView(string resourceName, string resourceValue);
    }
}