using Core;
using ShopDomain.View;

namespace ShopDomain
{
    public class ResourceItemPresenter<T>
    {
        private T _data;
        private readonly IResourceItemView _resourceItemView;

        public ResourceItemPresenter(T data, IResourceItemView resourceItemView)
        {
            _data = data;
            _resourceItemView = resourceItemView;
        }

        public void Initialize()
        {
        }
    }
}