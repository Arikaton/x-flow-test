using Gold;
using Health;
using Shop.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vip;
using LocationService = Location.LocationService;

namespace Shop
{
    public class ShopService : MonoBehaviour
    {
        public static ShopService Instance { get; private set; }

        public BundleSo SelectedBundle { get; private set; }
        public IPurchasingManager PurchasingManager => _purchasingManager;

        [SerializeField]
        private ShopConfigSo _shopConfig;
        [SerializeField]
        private ShopView _shopView;
        [SerializeField]
        private ResourceBarView _resourceBarView;

        [SerializeField]
        private string _bundleDetailSceneName;

        private ShopPresenter _shopPresenter;
        private IPurchasingManager _purchasingManager;

        private void Awake()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }

            Destroy(gameObject);
        }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _purchasingManager = new PurchasingManager();
            _shopPresenter = new ShopPresenter(_shopView, _shopConfig.Bundles, _purchasingManager);

            var resourceBarPresenter = new ResourceBarPresenter(_resourceBarView,
                GoldService.Instance,
                HealthService.Instance,
                LocationService.Instance,
                VipService.Instance,
                _shopConfig);

            _shopPresenter.BundleInfoClicked += LoadDetailScene;
        }

        private void LoadDetailScene(BundleSo selectedBundle)
        {
            SelectedBundle = selectedBundle;
            SceneManager.LoadScene(_bundleDetailSceneName, LoadSceneMode.Additive);
        }

        public void CloseDetailScene()
        {
            SelectedBundle = null;
            SceneManager.UnloadSceneAsync(_bundleDetailSceneName);
        }

        private void Update()
        {
            _shopPresenter.Refresh();
        }
    }
}