namespace ShopDomain.View
{
    public interface IShopView
    {
        void ClearCards();

        IBundleCardView CreateCardView();
    }
}
